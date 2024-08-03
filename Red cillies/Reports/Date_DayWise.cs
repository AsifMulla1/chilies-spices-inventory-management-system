using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
namespace Red_cillies.Reports
{
    public partial class r : Form
    {
        public r()
        {
            InitializeComponent();
        }


        OleDbCommand cmd;
        OleDbConnection cn;
        OleDbDataReader dr;
        private void r_Load(object sender, EventArgs e)
        {
            cn = new OleDbConnection();
            cn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\\RedCilliesDb.mdb";
            cn.Open();
        }

        private void btn_show_Click(object sender, EventArgs e)
        {
            rpt_CustBill r = new rpt_CustBill();
            //scrystalReportViewer1.SelectionFormula="Date{{"
            crystalReportViewer1.ReportSource = r;
        }
    }
}
