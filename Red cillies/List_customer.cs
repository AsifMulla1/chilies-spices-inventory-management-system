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
    public partial class List_customer : Form
    {
        public List_customer()
        {
            InitializeComponent();
        }

        private void List_customer_Load(object sender, EventArgs e)
        {
            rpt_Customer r = new rpt_Customer();
            crystalReportViewer1.ReportSource = r;
        }
    }
}
