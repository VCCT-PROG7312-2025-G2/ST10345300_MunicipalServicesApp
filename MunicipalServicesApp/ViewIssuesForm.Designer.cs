namespace MunicipalServicesApp
{
    partial class ViewIssuesForm
    {
        private System.ComponentModel.IContainer components = null;

        private Panel headerPanel;
        private Label lblHeaderTitle;
        private Label lblHeaderSubtitle;

        private DataGridView dgvIssues;   // ✅ added
        private Button btnClose;
        private Button btnRemoveOldest;   // ✅ added

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
            this.dgvIssues = new DataGridView();
            this.btnClose = new Button();
            this.btnRemoveOldest = new Button();

            this.SuspendLayout();

            // --- Header ---
            this.headerPanel.BackColor = Color.DimGray;
            this.headerPanel.Dock = DockStyle.Top;
            this.headerPanel.Height = 80;

            this.lblHeaderTitle.Text = "Submitted Issues";
            this.lblHeaderTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblHeaderTitle.ForeColor = Color.White;
            this.lblHeaderTitle.Location = new Point(20, 10);
            this.lblHeaderTitle.AutoSize = true;

            this.lblHeaderSubtitle.Text = "Here are the reports currently in the queue.";
            this.lblHeaderSubtitle.Font = new Font("Segoe UI", 9F);
            this.lblHeaderSubtitle.ForeColor = Color.WhiteSmoke;
            this.lblHeaderSubtitle.Location = new Point(22, 40);
            this.lblHeaderSubtitle.AutoSize = true;

            this.headerPanel.Controls.Add(this.lblHeaderTitle);
            this.headerPanel.Controls.Add(this.lblHeaderSubtitle);

            // --- DataGridView ---
            this.dgvIssues.Location = new Point(30, 100);
            this.dgvIssues.Size = new Size(740, 280);
            this.dgvIssues.BackgroundColor = Color.Black;
            this.dgvIssues.ForeColor = Color.White;
            this.dgvIssues.GridColor = Color.Gray;
            this.dgvIssues.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvIssues.ColumnHeadersDefaultCellStyle.BackColor = Color.DimGray;
            this.dgvIssues.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dgvIssues.EnableHeadersVisualStyles = false;

            // --- Remove Oldest Button ---
            this.btnRemoveOldest.Text = "🗑 Remove Oldest Issue";
            this.btnRemoveOldest.BackColor = Color.DarkRed;
            this.btnRemoveOldest.ForeColor = Color.White;
            this.btnRemoveOldest.FlatStyle = FlatStyle.Flat;
            this.btnRemoveOldest.Location = new Point(30, 400);
            this.btnRemoveOldest.Size = new Size(200, 35);
            this.btnRemoveOldest.Click += new EventHandler(this.btnRemoveOldest_Click);

            // --- Close Button ---
            this.btnClose.Text = "Close";
            this.btnClose.BackColor = Color.DimGray;
            this.btnClose.ForeColor = Color.White;
            this.btnClose.FlatStyle = FlatStyle.Flat;
            this.btnClose.Location = new Point(670, 400);
            this.btnClose.Size = new Size(100, 35);
            this.btnClose.Click += new EventHandler(this.btnClose_Click);

            // --- Form ---
            this.BackColor = Color.Black;
            this.ClientSize = new Size(800, 460);
            this.Controls.Add(this.headerPanel);
            this.Controls.Add(this.dgvIssues);
            this.Controls.Add(this.btnRemoveOldest);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "View Submitted Issues";

            this.ResumeLayout(false);
        }
    }
}
