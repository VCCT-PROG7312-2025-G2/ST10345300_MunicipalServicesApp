namespace MunicipalServicesApp
{
    partial class ReportIssuesForm
    {
        private System.ComponentModel.IContainer components = null;

        private Panel headerPanel;
        private Label lblHeaderTitle;
        private Label lblHeaderSubtitle;

        private Label lblLocation;
        private TextBox txtLocation;

        private Label lblCategory;
        private ComboBox cmbCategory;

        private Label lblDescription;
        private RichTextBox rtbDescription;

        private Label lblAttachment;
        private Button btnAttachFile;
        private TextBox txtMediaPath;   // ✅ declare it here

        private ProgressBar progressBar;
        private Button btnSubmit;
        private Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.headerPanel = new Panel();
            this.lblHeaderTitle = new Label();
            this.lblHeaderSubtitle = new Label();

            this.lblLocation = new Label();
            this.txtLocation = new TextBox();

            this.lblCategory = new Label();
            this.cmbCategory = new ComboBox();

            this.lblDescription = new Label();
            this.rtbDescription = new RichTextBox();

            this.lblAttachment = new Label();
            this.btnAttachFile = new Button();
            this.txtMediaPath = new TextBox(); // ✅ initialize

            this.progressBar = new ProgressBar();
            this.btnSubmit = new Button();
            this.btnCancel = new Button();

            this.SuspendLayout();

            // --- Header Panel ---
            this.headerPanel.BackColor = Color.DimGray;
            this.headerPanel.Dock = DockStyle.Top;
            this.headerPanel.Height = 80;

            this.lblHeaderTitle.Text = "Submit a Service Concern";
            this.lblHeaderTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblHeaderTitle.ForeColor = Color.White;
            this.lblHeaderTitle.Location = new Point(20, 10);
            this.lblHeaderTitle.AutoSize = true;

            this.lblHeaderSubtitle.Text = "Provide details about the issue to help us respond quickly.";
            this.lblHeaderSubtitle.Font = new Font("Segoe UI", 9F);
            this.lblHeaderSubtitle.ForeColor = Color.WhiteSmoke;
            this.lblHeaderSubtitle.Location = new Point(22, 40);
            this.lblHeaderSubtitle.AutoSize = true;

            this.headerPanel.Controls.Add(this.lblHeaderTitle);
            this.headerPanel.Controls.Add(this.lblHeaderSubtitle);

            // --- Location ---
            this.lblLocation.Text = "Location:";
            this.lblLocation.ForeColor = Color.White;
            this.lblLocation.Location = new Point(30, 100);
            this.lblLocation.AutoSize = true;

            this.txtLocation.Location = new Point(120, 95);
            this.txtLocation.Size = new Size(300, 27);

            // --- Category ---
            this.lblCategory.Text = "Category:";
            this.lblCategory.ForeColor = Color.White;
            this.lblCategory.Location = new Point(30, 150);
            this.lblCategory.AutoSize = true;

            this.cmbCategory.Location = new Point(120, 145);
            this.cmbCategory.Size = new Size(300, 28);
            this.cmbCategory.Items.AddRange(new object[]
            {
                "Roads & Transport",
                "Water & Sanitation",
                "Electricity",
                "Waste Management",
                "Other"
            });

            // --- Description ---
            this.lblDescription.Text = "Description:";
            this.lblDescription.ForeColor = Color.White;
            this.lblDescription.Location = new Point(30, 200);
            this.lblDescription.AutoSize = true;

            this.rtbDescription.Location = new Point(120, 195);
            this.rtbDescription.Size = new Size(300, 100);

            // --- Attachment ---
            this.lblAttachment.Text = "Attach File:";
            this.lblAttachment.ForeColor = Color.White;
            this.lblAttachment.Location = new Point(30, 310);
            this.lblAttachment.AutoSize = true;

            this.btnAttachFile.Text = "Choose File";
            this.btnAttachFile.BackColor = Color.Gray;
            this.btnAttachFile.ForeColor = Color.White;
            this.btnAttachFile.FlatStyle = FlatStyle.Flat;
            this.btnAttachFile.Location = new Point(120, 305);
            this.btnAttachFile.Size = new Size(120, 30);
            this.btnAttachFile.Click += new EventHandler(this.btnAttachFile_Click);

            // --- Media Path TextBox ---
            this.txtMediaPath.Location = new Point(250, 305);
            this.txtMediaPath.Size = new Size(250, 27);
            this.txtMediaPath.ReadOnly = true;

            // --- Progress Bar ---
            this.progressBar.Location = new Point(30, 350);
            this.progressBar.Size = new Size(500, 15);

            // --- Submit Button ---
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.BackColor = Color.Gray;
            this.btnSubmit.ForeColor = Color.White;
            this.btnSubmit.FlatStyle = FlatStyle.Flat;
            this.btnSubmit.Location = new Point(320, 380);
            this.btnSubmit.Size = new Size(100, 35);
            this.btnSubmit.Click += new EventHandler(this.btnSubmit_Click);

            // --- Cancel Button ---
            this.btnCancel.Text = "Cancel";
            this.btnCancel.BackColor = Color.DimGray;
            this.btnCancel.ForeColor = Color.White;
            this.btnCancel.FlatStyle = FlatStyle.Flat;
            this.btnCancel.Location = new Point(440, 380);
            this.btnCancel.Size = new Size(100, 35);
            this.btnCancel.Click += new EventHandler(this.btnCancel_Click);

            // --- ReportIssuesForm ---
            this.BackColor = Color.Black;
            this.ClientSize = new Size(600, 450);
            this.Controls.Add(this.headerPanel);
            this.Controls.Add(this.lblLocation);
            this.Controls.Add(this.txtLocation);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.rtbDescription);
            this.Controls.Add(this.lblAttachment);
            this.Controls.Add(this.btnAttachFile);
            this.Controls.Add(this.txtMediaPath); // ✅ add textbox to form
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Submit a Service Concern";

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
