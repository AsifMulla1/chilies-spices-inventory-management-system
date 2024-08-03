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
    public partial class List_Product : Form
    {
        public List_Product()
        {
            InitializeComponent();
        }

        private void List_Product_Load(object sender, EventArgs e)
        {
            rpt_product r = new rpt_product();
            crystalReportViewer1.ReportSource = r;
        }
    }
}
