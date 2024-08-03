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
    public partial class List_Supplier : Form
    {
        public List_Supplier()
        {
            InitializeComponent();
        }

        private void List_Supplier_Load(object sender, EventArgs e)
        {
            rpt_Supplier r = new rpt_Supplier();
            crystalReportViewer1.ReportSource = r;
        }
    }
}
