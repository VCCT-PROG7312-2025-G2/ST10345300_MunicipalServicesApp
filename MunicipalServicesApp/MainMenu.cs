using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.Drawing;
using System.Windows.Forms;
using System;
using System;
using System.Windows.Forms;

namespace MunicipalServicesApp
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void btnReportIssues_Click(object sender, EventArgs e)
        {
            // Open the Report Issues Form
            ReportIssuesForm reportForm = new ReportIssuesForm();
            reportForm.ShowDialog();
        }

        private void btnViewIssues_Click(object sender, EventArgs e)
        {
            // Open the View Issues Form
            ViewIssuesForm viewForm = new ViewIssuesForm();
            viewForm.ShowDialog();
        }
    }
}
