using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Windows.Forms;

namespace MunicipalServicesApp
{
    public partial class ViewIssuesForm : Form
    {
        public ViewIssuesForm()
        {
            InitializeComponent();
            LoadIssues();
        }

        private void LoadIssues()
        {
            dgvIssues.Columns.Clear();
            dgvIssues.Rows.Clear();

            // Setup columns
            dgvIssues.Columns.Add("Date", "Date Reported");
            dgvIssues.Columns.Add("Category", "Category");
            dgvIssues.Columns.Add("Location", "Location");
            dgvIssues.Columns.Add("Description", "Description");
            dgvIssues.Columns.Add("FilePath", "Attachment");

            if (ReportIssuesForm.MunicipalQueue.IsEmpty())
            {
                MessageBox.Show("No issues submitted yet.", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnRemoveOldest.Enabled = false; // disable remove if queue empty
            }
            else
            {
                btnRemoveOldest.Enabled = true; // enable if there are issues

                IssueNode current = ReportIssuesForm.MunicipalQueue.PeekNode();
                while (current != null)
                {
                    Issue issue = current.Data;
                    dgvIssues.Rows.Add(issue.DateReported,
                                       issue.Category,
                                       issue.Location,
                                       issue.Description,
                                       string.IsNullOrEmpty(issue.FilePath) ? "None" : issue.FilePath);
                    current = current.Next;
                }
            }
        }

        private void btnRemoveOldest_Click(object sender, EventArgs e)
        {
            if (ReportIssuesForm.MunicipalQueue.IsEmpty())
            {
                MessageBox.Show("No issues to remove.", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnRemoveOldest.Enabled = false;
            }
            else
            {
                Issue removed = ReportIssuesForm.MunicipalQueue.Dequeue();
                MessageBox.Show("Removed oldest issue:\n" +
                                $"{removed.DateReported}: {removed.Category} - {removed.Location}",
                                "Removed", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadIssues(); // refresh table
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
