using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace MunicipalServicesAppPoe3
{
    public partial class MainMenuForm : Form
    {
        private readonly Color BackgroundTop = Color.FromArgb(18, 18, 18);
        private readonly Color BackgroundBottom = Color.FromArgb(32, 32, 32);
        private readonly Color HeaderGlass = Color.FromArgb(200, 25, 25, 28);
        private readonly Color Accent = Color.FromArgb(0, 120, 215);
        private readonly Color ButtonGlass = Color.FromArgb(40, 40, 45);

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect,
            int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

        public MainMenuForm()
        {
            InitializeComponent();
            BuildUI();
        }

        private void BuildUI()
        {
            Text = "Municipal Services App";
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
                Text = "Municipal Services Portal",
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI Semibold", 22, FontStyle.Bold),
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleCenter
            };
            header.Controls.Add(title);
            Controls.Add(header);

            // === Buttons ===
            int startY = 220;
            int spacing = 80;

            Controls.Add(CreateMenuButton("📝 Report an Issue", startY, () => new ReportIssuesForm().ShowDialog()));
            Controls.Add(CreateMenuButton("📊 Track My Requests", startY + spacing, () => new ServiceStatusForm().ShowDialog()));
            Controls.Add(CreateMenuButton("📅 Community Events", startY + spacing * 2, () => new EventsForm().ShowDialog()));
            Controls.Add(CreateMenuButton("📈 Dashboard Analytics", startY + spacing * 3, () => new DashboardForm().ShowDialog()));

            // Exit button at bottom
            var btnExit = CreateMenuButton("✖ Exit", 600, () => Close());
            btnExit.BackColor = Color.FromArgb(50, 50, 50);
            Controls.Add(btnExit);
        }

        private Button CreateMenuButton(string text, int y, Action onClick)
        {
            var btn = new Button
            {
                Text = text,
                Width = 320,
                Height = 60,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = ButtonGlass,
                FlatStyle = FlatStyle.Flat,
                Location = new Point((ClientSize.Width - 320) / 2, y)
            };
            btn.FlatAppearance.BorderColor = Color.Gray;
            btn.FlatAppearance.MouseOverBackColor = Accent;
            btn.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn.Width, btn.Height, 15, 15));
            btn.Click += (s, e) => onClick();
            return btn;
        }
    }
}
