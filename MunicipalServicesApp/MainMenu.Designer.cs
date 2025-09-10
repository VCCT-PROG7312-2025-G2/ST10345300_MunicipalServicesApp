namespace MunicipalServicesApp
{
    partial class MainMenu
    {
        private System.ComponentModel.IContainer components = null;

        private Panel headerPanel;
        private Label lblHeaderTitle;
        private Label lblHeaderSubtitle;

        private GroupBox cardReport;
        private Label lblReportTitle;
        private Label lblReportDesc;
        private Button btnReportOpen;

        private GroupBox cardEvents;
        private Label lblEventsTitle;
        private Label lblEventsDesc;
        private Button btnEventsComingSoon;

        private GroupBox cardStatus;
        private Label lblStatusTitle;
        private Label lblStatusDesc;
        private Button btnStatusComingSoon;

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
            headerPanel = new Panel();
            lblHeaderTitle = new Label();
            lblHeaderSubtitle = new Label();
            cardReport = new GroupBox();
            lblReportTitle = new Label();
            lblReportDesc = new Label();
            btnReportOpen = new Button();
            cardEvents = new GroupBox();
            lblEventsTitle = new Label();
            lblEventsDesc = new Label();
            btnEventsComingSoon = new Button();
            cardStatus = new GroupBox();
            lblStatusTitle = new Label();
            lblStatusDesc = new Label();
            btnStatusComingSoon = new Button();
            headerPanel.SuspendLayout();
            cardReport.SuspendLayout();
            cardEvents.SuspendLayout();
            cardStatus.SuspendLayout();
            SuspendLayout();
            // 
            // headerPanel
            // 
            headerPanel.BackColor = Color.DimGray;
            headerPanel.Controls.Add(lblHeaderTitle);
            headerPanel.Controls.Add(lblHeaderSubtitle);
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Location = new Point(0, 0);
            headerPanel.Name = "headerPanel";
            headerPanel.Size = new Size(805, 100);
            headerPanel.TabIndex = 0;
            // 
            // lblHeaderTitle
            // 
            lblHeaderTitle.AutoSize = true;
            lblHeaderTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblHeaderTitle.ForeColor = Color.White;
            lblHeaderTitle.Location = new Point(20, 15);
            lblHeaderTitle.Name = "lblHeaderTitle";
            lblHeaderTitle.Size = new Size(365, 37);
            lblHeaderTitle.TabIndex = 0;
            lblHeaderTitle.Text = "Community Connect Portal";
            // 
            // lblHeaderSubtitle
            // 
            lblHeaderSubtitle.AutoSize = true;
            lblHeaderSubtitle.Font = new Font("Segoe UI", 10F);
            lblHeaderSubtitle.ForeColor = Color.WhiteSmoke;
            lblHeaderSubtitle.Location = new Point(22, 55);
            lblHeaderSubtitle.Name = "lblHeaderSubtitle";
            lblHeaderSubtitle.Size = new Size(470, 23);
            lblHeaderSubtitle.TabIndex = 1;
            lblHeaderSubtitle.Text = "Your gateway to municipal services and community updates.";
            // 
            // cardReport
            // 
            cardReport.BackColor = Color.Black;
            cardReport.Controls.Add(lblReportTitle);
            cardReport.Controls.Add(lblReportDesc);
            cardReport.Controls.Add(btnReportOpen);
            cardReport.ForeColor = Color.White;
            cardReport.Location = new Point(30, 120);
            cardReport.Name = "cardReport";
            cardReport.Size = new Size(703, 90);
            cardReport.TabIndex = 1;
            cardReport.TabStop = false;
            // 
            // lblReportTitle
            // 
            lblReportTitle.AutoSize = true;
            lblReportTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblReportTitle.ForeColor = Color.White;
            lblReportTitle.Location = new Point(15, 20);
            lblReportTitle.Name = "lblReportTitle";
            lblReportTitle.Size = new Size(240, 25);
            lblReportTitle.TabIndex = 0;
            lblReportTitle.Text = "Submit a Service Concern";
            // 
            // lblReportDesc
            // 
            lblReportDesc.AutoSize = true;
            lblReportDesc.Font = new Font("Segoe UI", 9F);
            lblReportDesc.ForeColor = Color.Gainsboro;
            lblReportDesc.Location = new Point(15, 50);
            lblReportDesc.Name = "lblReportDesc";
            lblReportDesc.Size = new Size(476, 20);
            lblReportDesc.TabIndex = 1;
            lblReportDesc.Text = "Log issues such as water leaks, road hazards or waste collection delays.";
            // 
            // btnReportOpen
            // 
            btnReportOpen.BackColor = Color.Gray;
            btnReportOpen.FlatStyle = FlatStyle.Flat;
            btnReportOpen.ForeColor = Color.White;
            btnReportOpen.Location = new Point(592, 40);
            btnReportOpen.Name = "btnReportOpen";
            btnReportOpen.Size = new Size(80, 30);
            btnReportOpen.TabIndex = 2;
            btnReportOpen.Text = "Start";
            btnReportOpen.UseVisualStyleBackColor = false;
            btnReportOpen.Click += btnReportIssues_Click;
            // 
            // cardEvents
            // 
            cardEvents.BackColor = Color.Black;
            cardEvents.Controls.Add(lblEventsTitle);
            cardEvents.Controls.Add(lblEventsDesc);
            cardEvents.Controls.Add(btnEventsComingSoon);
            cardEvents.ForeColor = Color.White;
            cardEvents.Location = new Point(30, 220);
            cardEvents.Name = "cardEvents";
            cardEvents.Size = new Size(703, 90);
            cardEvents.TabIndex = 2;
            cardEvents.TabStop = false;
            // 
            // lblEventsTitle
            // 
            lblEventsTitle.AutoSize = true;
            lblEventsTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblEventsTitle.ForeColor = Color.White;
            lblEventsTitle.Location = new Point(15, 20);
            lblEventsTitle.Name = "lblEventsTitle";
            lblEventsTitle.Size = new Size(187, 25);
            lblEventsTitle.TabIndex = 0;
            lblEventsTitle.Text = "Community Notices";
            // 
            // lblEventsDesc
            // 
            lblEventsDesc.AutoSize = true;
            lblEventsDesc.Font = new Font("Segoe UI", 9F);
            lblEventsDesc.ForeColor = Color.Gainsboro;
            lblEventsDesc.Location = new Point(15, 50);
            lblEventsDesc.Name = "lblEventsDesc";
            lblEventsDesc.Size = new Size(422, 20);
            lblEventsDesc.TabIndex = 1;
            lblEventsDesc.Text = "Stay informed with official announcements and local activities.";
            // 
            // btnEventsComingSoon
            // 
            btnEventsComingSoon.BackColor = Color.DimGray;
            btnEventsComingSoon.Enabled = false;
            btnEventsComingSoon.ForeColor = Color.White;
            btnEventsComingSoon.Location = new Point(552, 40);
            btnEventsComingSoon.Name = "btnEventsComingSoon";
            btnEventsComingSoon.Size = new Size(120, 30);
            btnEventsComingSoon.TabIndex = 2;
            btnEventsComingSoon.Text = "Unavailable";
            btnEventsComingSoon.UseVisualStyleBackColor = false;
            // 
            // cardStatus
            // 
            cardStatus.BackColor = Color.Black;
            cardStatus.Controls.Add(lblStatusTitle);
            cardStatus.Controls.Add(lblStatusDesc);
            cardStatus.Controls.Add(btnStatusComingSoon);
            cardStatus.ForeColor = Color.White;
            cardStatus.Location = new Point(30, 320);
            cardStatus.Name = "cardStatus";
            cardStatus.Size = new Size(703, 90);
            cardStatus.TabIndex = 3;
            cardStatus.TabStop = false;
            // 
            // lblStatusTitle
            // 
            lblStatusTitle.AutoSize = true;
            lblStatusTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblStatusTitle.ForeColor = Color.White;
            lblStatusTitle.Location = new Point(15, 20);
            lblStatusTitle.Name = "lblStatusTitle";
            lblStatusTitle.Size = new Size(177, 25);
            lblStatusTitle.TabIndex = 0;
            lblStatusTitle.Text = "Track My Requests";
            // 
            // lblStatusDesc
            // 
            lblStatusDesc.AutoSize = true;
            lblStatusDesc.Font = new Font("Segoe UI", 9F);
            lblStatusDesc.ForeColor = Color.Gainsboro;
            lblStatusDesc.Location = new Point(15, 50);
            lblStatusDesc.Name = "lblStatusDesc";
            lblStatusDesc.Size = new Size(430, 20);
            lblStatusDesc.TabIndex = 1;
            lblStatusDesc.Text = "Check the progress of your previously submitted service reports.";
            // 
            // btnStatusComingSoon
            // 
            btnStatusComingSoon.BackColor = Color.DimGray;
            btnStatusComingSoon.Enabled = false;
            btnStatusComingSoon.ForeColor = Color.White;
            btnStatusComingSoon.Location = new Point(552, 40);
            btnStatusComingSoon.Name = "btnStatusComingSoon";
            btnStatusComingSoon.Size = new Size(120, 30);
            btnStatusComingSoon.TabIndex = 2;
            btnStatusComingSoon.Text = "Unavailable";
            btnStatusComingSoon.UseVisualStyleBackColor = false;
            // 
            // 
            // --- New View Issues Button ---
            Button btnViewIssues = new Button();
            btnViewIssues.BackColor = Color.Gray;
            btnViewIssues.ForeColor = Color.White;
            btnViewIssues.FlatStyle = FlatStyle.Flat;
            btnViewIssues.Location = new Point(30, 430);   // position at bottom
            btnViewIssues.Name = "btnViewIssues";
            btnViewIssues.Size = new Size(200, 40);
            btnViewIssues.TabIndex = 4;
            btnViewIssues.Text = "📋 View Submitted Issues";
            btnViewIssues.UseVisualStyleBackColor = false;
            btnViewIssues.Click += btnViewIssues_Click;

            // Add to form controls
            this.Controls.Add(btnViewIssues);

            // MainMenu
            // 
            BackColor = Color.Black;
            ClientSize = new Size(805, 530);
            Controls.Add(headerPanel);
            Controls.Add(cardReport);
            Controls.Add(cardEvents);
            Controls.Add(cardStatus);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "MainMenu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Community Connect Portal";
            headerPanel.ResumeLayout(false);
            headerPanel.PerformLayout();
            cardReport.ResumeLayout(false);
            cardReport.PerformLayout();
            cardEvents.ResumeLayout(false);
            cardEvents.PerformLayout();
            cardStatus.ResumeLayout(false);
            cardStatus.PerformLayout();
            ResumeLayout(false);
        }
    }
}
