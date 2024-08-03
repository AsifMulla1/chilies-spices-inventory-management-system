using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Red_cillies.Reports;

namespace Red_cillies
{
    public partial class List_CustBill : Form
    {
        public List_CustBill()
        {
            InitializeComponent();
        }

        private void Product_list_Load(object sender, EventArgs e)
        {
            rpt_CustBill r = new rpt_CustBill();
            crystalReportViewer1.ReportSource = r;

           
        }
    }
}
