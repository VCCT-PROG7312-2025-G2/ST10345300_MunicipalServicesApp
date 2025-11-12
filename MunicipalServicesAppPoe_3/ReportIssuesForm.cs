using MunicipalServicesAppPoe3.Models;
using MunicipalServicesAppPoe3.Services;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace MunicipalServicesAppPoe3
{
    public partial class ReportIssuesForm : Form
    {
        private readonly Color BackgroundTop = Color.FromArgb(18, 18, 18);
        private readonly Color BackgroundBottom = Color.FromArgb(32, 32, 32);
        private readonly Color HeaderGlass = Color.FromArgb(200, 25, 25, 28);
        private readonly Color CardGlass = Color.FromArgb(200, 40, 40, 45);
        private readonly Color Accent = Color.FromArgb(0, 120, 215);

        private string attachedImagePath = null; // ✅ New: stores image path

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect,
            int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

        public ReportIssuesForm()
        {
            InitializeComponent();
            BuildUI();
        }

        private void BuildUI()
        {
            Text = "Report an Issue";
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

            // Header
            var header = new Panel
            {
                Dock = DockStyle.Top,
                Height = 130,
                BackColor = HeaderGlass
            };
            var title = new Label
            {
                Text = "Report an Issue",
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI Semibold", 22, FontStyle.Bold),
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleCenter
            };
            header.Controls.Add(title);
            Controls.Add(header);

            // Card panel
            var card = new Panel
            {
                Size = new Size(750, 460),
                Location = new Point((ClientSize.Width - 750) / 2, 160),
                BackColor = CardGlass
            };
            card.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, card.Width, card.Height, 15, 15));
            Controls.Add(card);

            // Labels and Inputs
            var lblName = CreateLabel("Full Name:", 40);
            var txtName = CreateTextBox(40);

            var lblCategory = CreateLabel("Category:", 100);
            var cmbCategory = new ComboBox
            {
                Location = new Point(200, 100),
                Width = 500,
                Font = new Font("Segoe UI", 10),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbCategory.Items.AddRange(new string[] { "Water Leak", "Electricity", "Road Damage", "Waste Collection", "Other" });

            var lblLocation = CreateLabel("Location:", 160);
            var txtLocation = CreateTextBox(160);

            var lblDescription = CreateLabel("Description:", 220);
            var txtDescription = new RichTextBox
            {
                Location = new Point(200, 220),
                Width = 500,
                Height = 100,
                Font = new Font("Segoe UI", 10),
                BackColor = Color.FromArgb(50, 50, 55),
                ForeColor = Color.White,
                BorderStyle = BorderStyle.None
            };

            // === Attachment Section ===
            var lblAttach = CreateLabel("Attach Image (optional):", 340);
            var btnAttach = new Button
            {
                Text = "📎 Attach",
                Width = 100,
                Height = 35,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.FromArgb(60, 60, 60),
                FlatStyle = FlatStyle.Flat,
                Location = new Point(200, 340)
            };
            btnAttach.FlatAppearance.BorderColor = Color.Gray;
            btnAttach.FlatAppearance.MouseOverBackColor = Accent;

            // Preview image box
            var picPreview = new PictureBox
            {
                Size = new Size(100, 80),
                Location = new Point(320, 330),
                BorderStyle = BorderStyle.FixedSingle,
                SizeMode = PictureBoxSizeMode.Zoom
            };

            btnAttach.Click += (s, e) =>
            {
                using (OpenFileDialog dialog = new OpenFileDialog())
                {
                    dialog.Filter = "Image Files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        attachedImagePath = dialog.FileName;
                        picPreview.Image = Image.FromFile(dialog.FileName);
                    }
                }
            };

            // Submit button
            var btnSubmit = new Button
            {
                Text = "Submit Issue",
                Width = 200,
                Height = 40,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                BackColor = Color.FromArgb(60, 60, 60),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(280, 400)
            };
            btnSubmit.FlatAppearance.BorderColor = Color.Gray;
            btnSubmit.FlatAppearance.MouseOverBackColor = Accent;

            btnSubmit.Click += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtName.Text) ||
                    string.IsNullOrWhiteSpace(txtLocation.Text) ||
                    string.IsNullOrWhiteSpace(txtDescription.Text) ||
                    cmbCategory.SelectedIndex < 0)
                {
                    MessageBox.Show("Please fill in all fields before submitting.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var issue = new IssueReport
                {
                    ReporterName = txtName.Text,
                    Category = cmbCategory.SelectedItem.ToString(),
                    Location = txtLocation.Text,
                    Description = txtDescription.Text,
                    Status = "Pending",
                    DateReported = DateTime.Now,
                    AttachmentPath = attachedImagePath
                };

                IssueManager.AddIssue(issue);
                MessageBox.Show("Issue submitted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtName.Clear();
                txtLocation.Clear();
                txtDescription.Clear();
                cmbCategory.SelectedIndex = -1;
                picPreview.Image = null;
                attachedImagePath = null;
            };

            card.Controls.Add(lblName);
            card.Controls.Add(txtName);
            card.Controls.Add(lblCategory);
            card.Controls.Add(cmbCategory);
            card.Controls.Add(lblLocation);
            card.Controls.Add(txtLocation);
            card.Controls.Add(lblDescription);
            card.Controls.Add(txtDescription);
            card.Controls.Add(lblAttach);
            card.Controls.Add(btnAttach);
            card.Controls.Add(picPreview);
            card.Controls.Add(btnSubmit);

            // Exit button
            var btnExit = new Button
            {
                Text = "✖ Exit",
                Width = 130,
                Height = 40,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.FromArgb(60, 60, 60),
                FlatStyle = FlatStyle.Flat,
                Location = new Point(60, 620)
            };
            btnExit.FlatAppearance.BorderColor = Color.Gray;
            btnExit.FlatAppearance.MouseOverBackColor = Accent;
            btnExit.Click += (s, e) => Close();
            Controls.Add(btnExit);
        }

        private Label CreateLabel(string text, int y)
        {
            return new Label
            {
                Text = text,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10),
                Location = new Point(40, y),
                AutoSize = true
            };
        }

        private TextBox CreateTextBox(int y)
        {
            return new TextBox
            {
                Location = new Point(200, y),
                Width = 500,
                Font = new Font("Segoe UI", 10),
                BackColor = Color.FromArgb(50, 50, 55),
                ForeColor = Color.White,
                BorderStyle = BorderStyle.None
            };
        }
    }
}
