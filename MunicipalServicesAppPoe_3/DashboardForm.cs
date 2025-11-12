using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using MunicipalServicesAppPoe3.Services;

namespace MunicipalServicesAppPoe3
{
    public partial class DashboardForm : Form
    {
        private readonly Color BackgroundTop = Color.FromArgb(18, 18, 18);
        private readonly Color BackgroundBottom = Color.FromArgb(32, 32, 32);
        private readonly Color HeaderGlass = Color.FromArgb(200, 25, 25, 28);
        private readonly Color CardGlass = Color.FromArgb(200, 40, 40, 45);
        private readonly Color Accent = Color.FromArgb(0, 120, 215);

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect, int nTopRect,
            int nRightRect, int nBottomRect,
            int nWidthEllipse, int nHeightEllipse);

        public DashboardForm()
        {
            InitializeComponent();
            BuildUI();
        }

        private void BuildUI()
        {
            Text = "Municipal Service Dashboard";
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
            var header = new Panel
            {
                Dock = DockStyle.Top,
                Height = 120,
                BackColor = HeaderGlass
            };

            var title = new Label
            {
                Text = "📊 Municipal Service Dashboard",
                Dock = DockStyle.Top,
                Font = new Font("Segoe UI Semibold", 22, FontStyle.Bold),
                ForeColor = Color.White,
                Height = 70,
                TextAlign = ContentAlignment.MiddleCenter
            };

            var subtitle = new Label
            {
                Text = "Visual summary of municipal issues by category and status",
                Dock = DockStyle.Top,
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.LightGray,
                Height = 30,
                TextAlign = ContentAlignment.MiddleCenter
            };

            // Correct order: add title first, then subtitle
            header.Controls.Add(subtitle);
            header.Controls.Add(title);
            Controls.Add(header);

            // === Charts ===
            if (IssueManager.Issues.Count == 0)
            {
                Controls.Add(new Label
                {
                    Text = "No issues available to display graphs.",
                    Font = new Font("Segoe UI", 12, FontStyle.Italic),
                    ForeColor = Color.Gray,
                    AutoSize = true,
                    Location = new Point((ClientSize.Width / 2) - 150, 350)
                });
                AddButtons();
                return;
            }

            // === Charts Panel ===
            var chartsPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 500, // keeps space for footer buttons
                BackColor = Color.Transparent
            };
            Controls.Add(chartsPanel);

            // === Chart 1: Issues by Category ===
            var chartCategory = CreateChart("Issues by Category");
            var seriesCategory = new Series("IssuesPerCategory")
            {
                ChartType = SeriesChartType.Column,
                Color = Accent,
                Font = new Font("Segoe UI", 9, FontStyle.Bold)
            };
            var issuesByCategory = IssueManager.Issues
                .GroupBy(i => i.Category)
                .Select(g => new { Category = g.Key, Count = g.Count() })
                .ToList();

            foreach (var c in issuesByCategory)
                seriesCategory.Points.AddXY(c.Category, c.Count);

            chartCategory.Series.Add(seriesCategory);

            // === Chart 2: Issues by Status ===
            var chartStatus = CreateChart("Issues by Status");
            var seriesStatus = new Series("IssuesPerStatus")
            {
                ChartType = SeriesChartType.Pie,
                Font = new Font("Segoe UI", 9, FontStyle.Bold)
            };
            var issuesByStatus = IssueManager.Issues
                .GroupBy(i => i.Status)
                .Select(g => new { Status = g.Key, Count = g.Count() })
                .ToList();

            foreach (var s in issuesByStatus)
            {
                int pointIndex = seriesStatus.Points.AddY(s.Count);
                var point = seriesStatus.Points[pointIndex];
                point.LegendText = s.Status;
                point.Label = s.Count.ToString();
            }

            seriesStatus["PieLabelStyle"] = "Outside";
            seriesStatus["PieLineColor"] = "LightGray";
            chartStatus.Series.Add(seriesStatus);
            chartStatus.Legends.Add(new Legend { Docking = Docking.Bottom, ForeColor = Color.White });

            // === Center Charts ===
            chartCategory.Size = new Size(380, 350);
            chartStatus.Size = new Size(380, 350);
            int spacing = 40;
            int totalWidth = chartCategory.Width + chartStatus.Width + spacing;
            int startX = (ClientSize.Width - totalWidth) / 2;
            chartCategory.Location = new Point(startX, 130);
            chartStatus.Location = new Point(startX + chartCategory.Width + spacing, 130);

            chartsPanel.Controls.Add(chartCategory);
            chartsPanel.Controls.Add(chartStatus);

            // === Buttons at Bottom ===
            AddButtons();
        }

        private Chart CreateChart(string titleText)
        {
            var chart = new Chart
            {
                BackColor = CardGlass
            };
            chart.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, 380, 350, 15, 15));
            chart.ChartAreas.Add(new ChartArea("Main"));
            chart.ChartAreas[0].BackColor = Color.Transparent;
            chart.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.White;
            chart.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.White;
            chart.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.DimGray;
            chart.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.DimGray;
            chart.Titles.Add(new Title(titleText, Docking.Top, new Font("Segoe UI", 12, FontStyle.Bold), Color.White));
            return chart;
        }

        private void AddButtons()
        {
            var btnBack = CreateButton("⬅ Back", 60, 620, Accent, () => Close());
            var btnExit = CreateButton("✖ Exit", 720, 620, Color.FromArgb(80, 0, 0), () => Application.Exit());

            // Anchor buttons to bottom corners
            btnBack.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnExit.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            Controls.Add(btnBack);
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
