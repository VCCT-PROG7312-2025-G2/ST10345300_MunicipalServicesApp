using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.IO;
using MunicipalServicesAppPoe3.Services;

namespace MunicipalServicesAppPoe3
{
    public partial class ServiceStatusForm : Form
    {
        private readonly Color BackgroundTop = Color.FromArgb(18, 18, 18);
        private readonly Color BackgroundBottom = Color.FromArgb(32, 32, 32);
        private readonly Color HeaderGlass = Color.FromArgb(200, 25, 25, 28);
        private readonly Color CardGlass = Color.FromArgb(200, 40, 40, 45);
        private readonly Color Accent = Color.FromArgb(0, 120, 215);

        private int currentPage = 0;
        private const int IssuesPerPage = 3;

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect, int nTopRect, int nRightRect, int nBottomRect,
            int nWidthEllipse, int nHeightEllipse);

        public ServiceStatusForm()
        {
            InitializeComponent();
            BuildUI();
        }

        private void BuildUI()
        {
            Text = "Track My Requests";
            Size = new Size(900, 700);
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.None;
            DoubleBuffered = true;
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

            Paint += (s, e) =>
            {
                using (LinearGradientBrush brush = new LinearGradientBrush(ClientRectangle, BackgroundTop, BackgroundBottom, 90f))
                    e.Graphics.FillRectangle(brush, ClientRectangle);
            };

            Controls.Clear();

            // === Header ===
            var header = new Panel { Dock = DockStyle.Top, Height = 130, BackColor = HeaderGlass };
            var title = new Label
            {
                Text = "Track My Requests",
                Dock = DockStyle.Top,
                Font = new Font("Segoe UI Semibold", 22, FontStyle.Bold),
                ForeColor = Color.White,
                Height = 60,
                TextAlign = ContentAlignment.BottomCenter
            };
            var subtitle = new Label
            {
                Text = "View all your submitted issues and their current status below.",
                Dock = DockStyle.Bottom,
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.LightGray,
                Height = 35,
                TextAlign = ContentAlignment.TopCenter
            };
            header.Controls.Add(subtitle);
            header.Controls.Add(title);
            Controls.Add(header);

            // === Load Issues ===
            var issues = IssueManager.Issues;
            if (issues.Count == 0)
            {
                Controls.Add(new Label
                {
                    Text = "No issues submitted yet.",
                    Font = new Font("Segoe UI", 12, FontStyle.Italic),
                    ForeColor = Color.Gray,
                    AutoSize = true,
                    Location = new Point((ClientSize.Width / 2) - 130, 300)
                });
            }
            else
            {
                int startY = 160;
                int spacing = 115;
                int startIndex = currentPage * IssuesPerPage;
                int endIndex = Math.Min(startIndex + IssuesPerPage, issues.Count);

                for (int i = startIndex; i < endIndex; i++)
                {
                    var issue = issues[i];
                    var card = new Panel
                    {
                        Size = new Size(750, 100),
                        Location = new Point((ClientSize.Width - 750) / 2, startY + ((i - startIndex) * spacing)),
                        BackColor = CardGlass
                    };
                    card.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, card.Width, card.Height, 15, 15));

                    var lbl = new Label
                    {
                        Text = $"#{issue.Id} - {issue.Category} | {issue.Location}",
                        Font = new Font("Segoe UI Semibold", 11, FontStyle.Bold),
                        ForeColor = Color.White,
                        Location = new Point(25, 20),
                        AutoSize = true
                    };

                    var desc = new Label
                    {
                        Text = issue.Description.Length > 80 ? issue.Description.Substring(0, 80) + "..." : issue.Description,
                        Font = new Font("Segoe UI", 9),
                        ForeColor = Color.Gainsboro,
                        Location = new Point(25, 50),
                        AutoSize = true
                    };

                    // === View Image Button ===
                    if (!string.IsNullOrEmpty(issue.AttachmentPath) && File.Exists(issue.AttachmentPath))
                    {
                        var btnViewImage = new Button
                        {
                            Text = "📷 View",
                            Width = 80,
                            Height = 30,
                            Font = new Font("Segoe UI", 9, FontStyle.Bold),
                            ForeColor = Color.White,
                            BackColor = Color.FromArgb(60, 60, 60),
                            FlatStyle = FlatStyle.Flat,
                            Location = new Point(card.Width - 280, 35)
                        };
                        btnViewImage.FlatAppearance.BorderColor = Color.Gray;
                        btnViewImage.FlatAppearance.MouseOverBackColor = Accent;
                        btnViewImage.Click += (s, e) =>
                        {
                            try
                            {
                                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                                {
                                    FileName = issue.AttachmentPath,
                                    UseShellExecute = true
                                });
                            }
                            catch
                            {
                                MessageBox.Show("Could not open image file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        };
                        card.Controls.Add(btnViewImage);
                    }

                    // === Status Button ===
                    var statusBtn = new Button
                    {
                        Text = issue.Status,
                        Width = 120,
                        Height = 35,
                        Font = new Font("Segoe UI", 9, FontStyle.Bold),
                        ForeColor = Color.White,
                        BackColor = issue.Status == "Pending" ? Color.FromArgb(200, 120, 50)
                                  : issue.Status == "In Progress" ? Color.FromArgb(200, 170, 60)
                                  : Color.FromArgb(60, 160, 90),
                        FlatStyle = FlatStyle.Flat,
                        Location = new Point(card.Width - 150, 33)
                    };
                    statusBtn.FlatAppearance.BorderColor = Color.Gray;
                    statusBtn.Click += (s, e) =>
                    {
                        string newStatus = issue.Status == "Pending" ? "In Progress"
                                           : issue.Status == "In Progress" ? "Completed" : "Pending";
                        IssueManager.UpdateStatus(issue.Id, newStatus);
                        BuildUI();
                    };

                    card.Controls.Add(lbl);
                    card.Controls.Add(desc);
                    card.Controls.Add(statusBtn);
                    Controls.Add(card);
                }

                // === Pagination buttons ===
                if (issues.Count > IssuesPerPage)
                {
                    var btnNext = CreateNavButton("Next ▶", 720, 620, () =>
                    {
                        if ((currentPage + 1) * IssuesPerPage < issues.Count)
                        {
                            currentPage++;
                            BuildUI();
                        }
                    });

                    var btnPrev = CreateNavButton("◀ Prev", 560, 620, () =>
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

            // === Exit button ===
            var btnExit = CreateNavButton("✖ Exit", 60, 620, () => Close());
            Controls.Add(btnExit);
        }

        private Button CreateNavButton(string text, int x, int y, Action onClick)
        {
            var b = new Button
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
            b.FlatAppearance.BorderColor = Color.Gray;
            b.FlatAppearance.MouseOverBackColor = Accent;
            b.Click += (s, e) => onClick();
            return b;
        }
    }
}
