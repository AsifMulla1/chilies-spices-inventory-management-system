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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Windows.Forms;

namespace Red_cillies
{
    public partial class CustBill : Form
    {
        string Flag = "";
        private static string myConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\\RedCilliesDb.mdb";
        static OleDbConnection conn = new OleDbConnection(myConn);

        OleDbCommand cmd = new OleDbCommand();
        DataTable dt = new DataTable();
        DataRow dr1;

        public void SetConnection()
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
                // MessageBox.Show("Connectiom open");
            }
        }
        public CustBill()
        {
            InitializeComponent();
            
            ctrlGotFocus();
            ctrlLostFocus();
            FormClear();
            dateTimePicker1.Value = DateTime.Now;
            textTotAmt.Text = "0";
        }

        private void CustBill_Load(object sender, EventArgs e)
        {
            DataColumn srno;
            DataColumn ProdName;
            DataColumn Price;
            DataColumn qty;
            DataColumn Amount;

            dt = new DataTable();
            ProdName = new DataColumn("ProdName");
            srno = new DataColumn("SrNo", Type.GetType("System.Int32"));
            qty = new DataColumn("ProdQty", Type.GetType("System.Int32"));
            Price = new DataColumn("Price", Type.GetType("System.Int32"));
            Amount = new DataColumn("Amount", Type.GetType("System.Double"));

            dt.Columns.Add(srno);
            dt.Columns.Add(ProdName);
            dt.Columns.Add(qty);
            dt.Columns.Add(Price);
            dt.Columns.Add(Amount);
        }
        private void FormClear()
        {
            foreach (Control c in panel2.Controls)
            {
                if (c is TextBox || c is ComboBox)
                {
                    c.Text = "";
                }
            }
            foreach (Control c in panel4.Controls)
            {
                if (c is TextBox || c is ComboBox)
                {
                    c.Text = "";
                }
            }
            dataGridView1.DataSource = null;
        }
        private void ctrlGotFocus()
        {
            foreach (Control c in panel2.Controls)
            {
                if (c is TextBox || c is ComboBox)
                {
                    c.GotFocus += Onfocus;
                }
            }
            foreach (Control c in panel4.Controls)
            {
                if (c is TextBox || c is ComboBox)
                {
                    c.GotFocus += Onfocus;
                }
            }
        }
        private void ctrlLostFocus()
        {
            foreach (Control c in panel2.Controls)
            {
                if (c is TextBox || c is ComboBox)
                {
                    c.LostFocus += OnLostFocus;
                }
            }
            foreach (Control c in panel4.Controls)
            {
                if (c is TextBox || c is ComboBox)
                {
                    c.LostFocus += OnLostFocus;
                }
            }
        }
        private void Onfocus(object sender, EventArgs e)
        {
            var ctrl = sender as Control;
            ctrl.Tag = ctrl.BackColor;
            ctrl.BackColor = Color.Cyan;
        }
        private void OnLostFocus(object sender, EventArgs e)
        {
            var ctrl = sender as Control;
            ctrl.Tag = ctrl.BackColor;
            ctrl.BackColor = Color.White;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            FormClear();
            Flag = "A";
            SetConnection();
            cmd = new OleDbCommand("Select max(BillNo) from BillMaster", conn);
            if (System.DBNull.Value == cmd.ExecuteScalar())
            {
                textBillno.Text = Convert.ToString(1);

            }
            else
            {
                int i = Convert.ToInt32(cmd.ExecuteScalar());
                textBillno.Text = Convert.ToString(i + 1);
            }
            conn.Close();
            //textTotAmt.Text = "0";
            textBillno.Focus();
        }

        private void textBillno_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBillno_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (Flag == "M" || Flag == "D")
                {
                    SetConnection();
                    cmd = new OleDbCommand("Select * from BillMaster where BillNo = " + textBillno.Text + "", conn);
                    OleDbDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        dateTimePicker1.Text = dr["tDate"].ToString();
                        textCustID.Text = dr["CustID"].ToString();
                        CustNameCombo.Text = dr["CustName"].ToString();

                    }
                    //dr.Close();
                    cmd = new OleDbCommand("Select * from BillDetails where BillNo = " + textBillno.Text + "", conn);
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        dr1 = dt.NewRow();
                        dr1["SrNo"] = dr["SrNo"];
                        dr1["ProdName"] = dr["ProdName"];
                        dr1["ProdQty"] = dr["Qty"];
                        dr1["Price"] = dr["Price"];
                        dr1["Amount"] = dr["Amount"];
                        dt.Rows.Add(dr1);
                    }
                    dataGridView1.DataSource = dt;

                    if (Flag == "D")
                    {
                        DialogResult result = MessageBox.Show("Are You Sure ?", "Confirm Deletion", MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            cmd = new OleDbCommand("Delete from BillMaster where BillNo=" + textBillno.Text + "", conn);
                            cmd.ExecuteNonQuery();
                            cmd = new OleDbCommand("Delete from BillDetails where BillNo=" + textBillno.Text + "", conn);
                            cmd.ExecuteNonQuery();
                            Flag = "";
                            FormClear();
                            btnNew.Focus();

                        }
                    }
                }
                if (Flag == "A" || Flag == "M")
                {
                    dateTimePicker1.Focus();
                }


            }
        }

        private void dateTimePicker1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SetConnection();
                CustNameCombo.Items.Clear();
                cmd = new OleDbCommand("Select CustName from CustomerTbl", conn);
                OleDbDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    CustNameCombo.Items.Add(dr["CustName"].ToString());
                }
                dr.Close();
                conn.Close();
                CustNameCombo.Focus();
            }
        }

        private void CustNameCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetConnection();
            OleDbCommand cmd = new OleDbCommand("Select ID from CustomerTbl where CustName='" + CustNameCombo.Text + "'", conn);
            textCustID.Text = cmd.ExecuteScalar().ToString();
            conn.Close();
        }

        private void CustNameCombo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textSrNo.Text = "1";
                textSrNo.Focus();
            }
        }

        private void textSrNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SetConnection();
                ProdNameCombo.Items.Clear();
                cmd = new OleDbCommand("Select ProdName from ProductTbl", conn);
                OleDbDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ProdNameCombo.Items.Add(dr["ProdName"].ToString());

                }
                dr.Close();
                conn.Close();
                ProdNameCombo.Focus();

            }
        }

        private void ProdNameCombo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textPrice.Focus();
            }
        }

        private void ProdNameCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetConnection();
            OleDbCommand cmd = new OleDbCommand("Select ID,ProdPrice from ProductTbl where ProdName='" + ProdNameCombo.Text + "'", conn);
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                textProdID.Text = dr["ID"].ToString();
                textPrice.Text = dr["ProdPrice"].ToString();
            }
            dr.Close();
            conn.Close();
        }

        private void textQuantity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textAmount.Text = (Convert.ToDouble(textQuantity.Text) * Convert.ToDouble(textPrice.Text)).ToString();
                textAmount.Focus();
            }
        }

        private void textPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textQuantity.Focus();
            }
        }

        private void textAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dr1 = dt.NewRow();
                dr1["SrNo"] = Convert.ToInt32(textSrNo.Text);
                dr1["ProdName"] = ProdNameCombo.Text;
                dr1["ProdQty"] = Convert.ToInt32(textQuantity.Text);
                dr1["Price"] = Convert.ToInt32(textPrice.Text);
                dr1["Amount"] = Convert.ToInt32(textAmount.Text);
                dt.Rows.Add(dr1);
                dataGridView1.DataSource = dt;

                textTotAmt.Text = (Convert.ToInt32(textTotAmt.Text) + Convert.ToInt32(textAmount.Text)).ToString();

                textProdID.Clear();
                textPrice.Clear();
                textQuantity.Clear();
                textAmount.Clear();
                textSrNo.Text = (Convert.ToInt32(textSrNo.Text) + 1).ToString();
                textSrNo.Focus();

             /*   textTotAmt.Text = (Convert.ToInt32(textTotAmt.Text) + Convert.ToInt32(textAmount.Text)).ToString();
               
                textSrNo.Text = (Convert.ToInt32(textSrNo.Text) + 1).ToString();
                textSrNo.Focus();*/
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Flag == "A")
            {
                SetConnection();
                cmd.Connection = conn;
                cmd = new OleDbCommand("insert into BillMaster (BillNo,tDate,CustID,CustName,BillAmount) values(" + textBillno.Text + ",#" + dateTimePicker1.Value + "#, " + textCustID.Text + ", '" +CustNameCombo.Text + "'," + textTotAmt.Text + ")", conn);

                cmd.ExecuteNonQuery();
            }
            for (int i = 0; i <= (dataGridView1.Rows.Count) - 2; i++)
            {
                SetConnection();
                cmd = new OleDbCommand("Insert Into BillDetails (SrNo,BillNo,ProdName,Qty,Price,Amount) Values (" + dataGridView1.Rows[i].Cells[0].Value + "," + textBillno.Text + ",'" + dataGridView1.Rows[i].Cells[1].Value + "'," + dataGridView1.Rows[i].Cells[2].Value + "," + dataGridView1.Rows[i].Cells[3].Value + "," + dataGridView1.Rows[i].Cells[4].Value + ")", conn);

                cmd.ExecuteNonQuery();

            }

            MessageBox.Show("Data Inserted");
            if (Flag == "M")
            {
                cmd = new OleDbCommand("DELETE FROM BillDetails where BillNo = " + textBillno.Text + "", conn);
                cmd.ExecuteNonQuery();
                for (int i = 0; i <= (dataGridView1.Rows.Count) - 2; i++)
                {
                    cmd = new OleDbCommand("INSERT INTO BillDetails (SrNo,BillNo,ProdName,Price,Qty,Amount) Values (" + dataGridView1.Rows[i].Cells[0].Value + "," + textBillno.Text + ",'" + dataGridView1.Rows[i].Cells[1].Value + "'," + dataGridView1.Rows[i].Cells[2].Value + "," + dataGridView1.Rows[i].Cells[3].Value + "," + dataGridView1.Rows[i].Cells[4].Value + ")", conn);
                }
            }
            Flag = "";
            //FormClear();
            btnNew.Focus();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            FormClear();
            Flag = "M";
            textBillno.Focus();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            FormClear();
            Flag = "D";
            textBillno.Focus();
        }

        private void btnCust_Click(object sender, EventArgs e)
        {
            Customer Cust = new Customer();
            Cust.Show();
            this.Hide();
        }

        private void btnProd_Click(object sender, EventArgs e)
        {
            Product Prod = new Product();
            Prod.Show();
            this.Hide();
        }

        private void btnSupp_Click(object sender, EventArgs e)
        {
            Supplier Supp = new Supplier();
            Supp.Show();
            this.Hide();
        }

        private void btnPurch_Click(object sender, EventArgs e)
        {
            Purchase Log = new Purchase();
            Log.Show();
            this.Hide();
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            Form2 Log = new Form2();
            Log.Show();
            this.Hide();
        }

        private void PrintButton_Click(object sender, EventArgs e)
        {
            ReportDocument crypt = new ReportDocument();
            crypt.Load(@"C:\Users\USER\OneDrive\Desktop\Final pro\Red cillies\Reports\rpt_FinalBill.rpt");
            crypt.RecordSelectionFormula = "{BillDetails.BillNo}=" + Convert.ToInt32(textBillno.Text) + "";
            panel1.Visible = false;
            crypt.Refresh();
            CrystalReportViewer view1 = new CrystalReportViewer();
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            btnSupp.Visible = false;
            btnProd.Visible = false;
            btnCust.Visible = false;
            btnPurch.Visible = false;
            btnLog.Visible = false;

            view1.Dock = DockStyle.Fill;
            view1.ReportSource = crypt;
            this.Controls.Add(view1);
        }
    }
    
}
