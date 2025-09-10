using MunicipalServicesApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.IO;
using System.Windows.Forms;

namespace MunicipalServicesApp
{
    public partial class ReportIssuesForm : Form
    {
        // Shared queue for all issues
        public static IssueQueue MunicipalQueue = new IssueQueue();

        public ReportIssuesForm()
        {
            InitializeComponent();
        }

        private void btnAttachFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Images|*.jpg;*.jpeg;*.png|Documents|*.pdf;*.docx|All Files|*.*";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    txtMediaPath.Text = ofd.FileName;
                }
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLocation.Text) ||
                cmbCategory.SelectedIndex == -1 ||
                string.IsNullOrWhiteSpace(rtbDescription.Text))
            {
                MessageBox.Show("Please fill in all required fields.", "Missing Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Create new issue object
            Issue newIssue = new Issue(
                txtLocation.Text,
                cmbCategory.SelectedItem.ToString(),
                rtbDescription.Text,
                txtMediaPath.Text
            );

            // Add to queue
            MunicipalQueue.Enqueue(newIssue);

            // Show confirmation
            progressBar.Value = 100;
            MessageBox.Show("Issue submitted successfully!\n\n" + newIssue.ToString(),
                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
