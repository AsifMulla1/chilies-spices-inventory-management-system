using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Windows.Forms;
using System.Data.OleDb;

namespace Red_cillies
{
    public partial class Date_Wise_Bill : Form
    {
        public Date_Wise_Bill()
        {
            InitializeComponent();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            ReportDocument crpt = new ReportDocument();
            crpt.Load(@"C:\Users\USER\OneDrive\Desktop\Red cillies - Copy\Red cillies\Reports\rpt_CustBill.rpt");
            crpt.RecordSelectionFormula = "Date({BillMaster.tDate})>=Date('" + dateTimePicker1.Value + "')and Date({BillMaster.tDate})<=Date('" + dateTimePicker2.Value + " ')";
            crystalReportViewer2.ReportSource = crpt;
            crystalReportViewer2.Show();

        }

        private void crystalReportViewer2_Load(object sender, EventArgs e)
        {

        }
    }
}
