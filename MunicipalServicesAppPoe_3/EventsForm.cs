using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using MunicipalServicesAppPoe3.Services;

namespace MunicipalServicesAppPoe3
{
    public partial class EventsForm : Form
    {
        private readonly Color BackgroundTop = Color.FromArgb(18, 18, 18);
        private readonly Color BackgroundBottom = Color.FromArgb(32, 32, 32);
        private readonly Color HeaderGlass = Color.FromArgb(200, 25, 25, 28);
        private readonly Color CardGlass = Color.FromArgb(200, 40, 40, 45);
        private readonly Color Accent = Color.FromArgb(0, 120, 215);

        private int currentPage = 0;
        private const int EventsPerPage = 6;

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect, int nTopRect,
            int nRightRect, int nBottomRect,
            int nWidthEllipse, int nHeightEllipse);

        public EventsForm()
        {
            InitializeComponent();
            BuildUI();
        }

        private void BuildUI()
        {
            Text = "Community Events";
            Size = new Size(900, 700);
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.None;
            DoubleBuffered = true;
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

            Paint += (s, e) =>
            {
                using (LinearGradientBrush brush =
                    new LinearGradientBrush(ClientRectangle, BackgroundTop, BackgroundBottom, 90f))
                {
                    e.Graphics.FillRectangle(brush, ClientRectangle);
                }
            };

            Controls.Clear();

            // === Header ===
            var header = new Panel
            {
                Dock = DockStyle.Top,
                Height = 130,
                BackColor = HeaderGlass
            };
            var title = new Label
            {
                Text = "Community Events & Notices",
                Dock = DockStyle.Top,
                Font = new Font("Segoe UI Semibold", 22, FontStyle.Bold),
                ForeColor = Color.White,
                Height = 60,
                TextAlign = ContentAlignment.BottomCenter
            };
            var subtitle = new Label
            {
                Text = "Stay informed with upcoming community activities and initiatives.",
                Dock = DockStyle.Bottom,
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.LightGray,
                Height = 35,
                TextAlign = ContentAlignment.TopCenter
            };
            header.Controls.Add(subtitle);
            header.Controls.Add(title);
            Controls.Add(header);

            // === Grid Layout ===
            int startX = 80;
            int startY = 160;
            int cardWidth = 340;
            int cardHeight = 100;
            int spacingX = 40;
            int spacingY = 35;

            var events = EventManager.Events;

            if (events == null || events.Count == 0)
            {
                Controls.Add(new Label
                {
                    Text = "No community events found.",
                    Font = new Font("Segoe UI", 12, FontStyle.Italic),
                    ForeColor = Color.Gray,
                    AutoSize = true,
                    Location = new Point((ClientSize.Width / 2) - 130, 320)
                });
            }
            else
            {
                int startIndex = currentPage * EventsPerPage;
                int endIndex = Math.Min(startIndex + EventsPerPage, events.Count);

                for (int i = startIndex; i < endIndex; i++)
                {
                    int localIndex = i - startIndex;
                    int row = localIndex / 2;
                    int col = localIndex % 2;

                    var ev = events[i];
                    var card = new Panel
                    {
                        Size = new Size(cardWidth, cardHeight),
                        Location = new Point(startX + (col * (cardWidth + spacingX)), startY + (row * (cardHeight + spacingY))),
                        BackColor = CardGlass
                    };
                    card.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, card.Width, card.Height, 15, 15));

                    var lblTitle = new Label
                    {
                        Text = ev.Title,
                        Font = new Font("Segoe UI Semibold", 11, FontStyle.Bold),
                        ForeColor = Color.White,
                        Location = new Point(20, 10),
                        AutoSize = true
                    };

                    var lblDate = new Label
                    {
                        Text = ev.Date.ToString("dddd, dd MMM yyyy"),
                        Font = new Font("Segoe UI", 9, FontStyle.Italic),
                        ForeColor = Color.LightGray,
                        Location = new Point(20, 30),
                        AutoSize = true
                    };

                    var lblDesc = new Label
                    {
                        Text = ev.Description.Length > 45 ? ev.Description.Substring(0, 45) + "..." : ev.Description,
                        Font = new Font("Segoe UI", 9),
                        ForeColor = Color.Gainsboro,
                        Location = new Point(20, 50),
                        MaximumSize = new Size(card.Width - 120, 0), // ensures no overlap
                        AutoSize = true
                    };

                    var btnAttend = new Button
                    {
                        Text = ev.Attended ? "✔" : "+",
                        Width = 32, // much smaller button
                        Height = 28,
                        Font = new Font("Segoe UI", 10, FontStyle.Bold),
                        ForeColor = Color.White,
                        BackColor = ev.Attended ? Color.FromArgb(60, 150, 80) : Color.FromArgb(70, 70, 70),
                        FlatStyle = FlatStyle.Flat,
                        Location = new Point(card.Width - 50, 33)
                    };
                    btnAttend.FlatAppearance.BorderColor = Color.Gray;
                    btnAttend.FlatAppearance.MouseOverBackColor = Accent;
                    btnAttend.Cursor = Cursors.Hand;

                    // Tooltip for clarity
                    var toolTip = new ToolTip();
                    toolTip.SetToolTip(btnAttend, ev.Attended ? "Already attended" : "Mark as attended");

                    btnAttend.Click += (s, e) =>
                    {
                        EventManager.ToggleAttendance(ev.Title);
                        BuildUI();
                    };

                    card.Controls.Add(lblTitle);
                    card.Controls.Add(lblDate);
                    card.Controls.Add(lblDesc);
                    card.Controls.Add(btnAttend);
                    Controls.Add(card);
                }

                // === Pagination buttons ===
                if (events.Count > EventsPerPage)
                {
                    var btnNext = CreateButton("Next ▶", 720, 620, Accent, () =>
                    {
                        if ((currentPage + 1) * EventsPerPage < events.Count)
                        {
                            currentPage++;
                            BuildUI();
                        }
                    });

                    var btnPrev = CreateButton("◀ Prev", 560, 620, Accent, () =>
                    {
                        if (currentPage > 0)
                        {
                            currentPage--;
                            BuildUI();
                        }
                    });

                    Controls.Add(btnPrev);
                    Controls.Add(btnNext);
                }
            }

            // === Exit Button ===
            var btnExit = CreateButton("✖ Exit", 60, 620, Color.FromArgb(60, 60, 60), () => Close());
            Controls.Add(btnExit);
        }

        private Button CreateButton(string text, int x, int y, Color hoverColor, Action onClick)
        {
            var btn = new Button
            {
                Text = text,
                Width = 130,
                Height = 40,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.FromArgb(60, 60, 60),
                FlatStyle = FlatStyle.Flat,
                Location = new Point(x, y)
            };
            btn.FlatAppearance.BorderColor = Color.Gray;
            btn.FlatAppearance.MouseOverBackColor = hoverColor;
            btn.Click += (s, e) => onClick();
            return btn;
        }
    }
}

