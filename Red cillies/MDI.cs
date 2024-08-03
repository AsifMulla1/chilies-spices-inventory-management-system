using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Red_cillies
{
    public partial class MDI : Form
    {
        public MDI()
        {
            InitializeComponent();
        }

        private void customerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Customer().Show();
            this.Show();
        }

        private void supplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Supplier().Show();
            this.Show();
        }

        private void productToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Product().Show();
            this.Show();
        }

        private void customerBillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new CustBill().Show();
            this.Show();
        }

        private void purshaseMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Purchase().Show();
            this.Show();
        }

        private void productToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new rpt_Prod().Show();
            this.Show();
        }

        private void customerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new rpt_Cust().Show();
            this.Show();
        }

        private void supplierToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new rpt_Supp().Show();
            this.Show();
        }

        private void purchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new rpt_Purch().Show();
            this.Show();
        }

        private void billToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new rpt_Bill().Show();
            this.Show();
        }

        private void dateWiseReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Date_Wise_Bill().Show();
            this.Show();
        }
    }
}
