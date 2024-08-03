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

namespace Red_cillies
{
    public partial class Purchase : Form
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
        public Purchase()
        {
            InitializeComponent();
            ctrlGotFocus();
            ctrlLostFocus();
            FormClear();
            dtpdatePicker1.Value = DateTime.Now;
            textTotAmt.Text = "0";
        }

        private void Purchase_Load(object sender, EventArgs e)
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

        private void NewButton_Click(object sender, EventArgs e)
        {
            FormClear();
            Flag = "A";
            SetConnection();
            cmd = new OleDbCommand("Select max(PurchId) from PurchaseMaster", conn);
            if(System.DBNull.Value == cmd.ExecuteScalar())
            {
                textPurchID.Text = Convert.ToString(1);

            }
            else
            {
                int i = Convert.ToInt32(cmd.ExecuteScalar());
                textPurchID.Text = Convert.ToString(i + 1);
            }
            conn.Close();
            //textTotAmt.Text = "0";
            textPurchID.Focus();
        }

        private void textPurchID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (Flag == "M" || Flag == "D")
                {
                    SetConnection();
                    cmd = new OleDbCommand("Select * from PurchaseMaster where PurchID = " + textPurchID.Text + "", conn);
                    OleDbDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        dtpdatePicker1.Text = dr["tDate"].ToString();
                        textSuppId.Text = dr["SuppID"].ToString();
                        SuppNameCombo.Text = dr["suppname"].ToString();

                    }
                    //dr.Close();
                    cmd = new OleDbCommand("Select * from PurchaseDetails where PurchID = " + textPurchID.Text + "", conn);
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

                    if (Flag=="D")
                    {
                        DialogResult result = MessageBox.Show("Are You Sure ?", "Confirm Deletion", MessageBoxButtons.YesNo);
                        if(result == DialogResult.Yes)
                        {
                            cmd = new OleDbCommand("Delete from PurchaseMaster where PurchID=" + textPurchID.Text + "", conn);
                            cmd.ExecuteNonQuery();
                            cmd = new OleDbCommand("Delete from PurchaseDetails where PurchID=" + textPurchID.Text + "",conn);
                            cmd.ExecuteNonQuery();
                            Flag = "";
                            FormClear();
                            btnNew.Focus();

                        }
                    }
                }
                if (Flag =="A" || Flag == "M")
                {
                    dtpdatePicker1.Focus();
                }
                

            }
        }

        private void dtpdatePicker1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SetConnection();
                SuppNameCombo.Items.Clear();
                cmd = new OleDbCommand("Select SuppName from SupplierTbl", conn);
                OleDbDataReader dr = cmd.ExecuteReader();
                while(dr.Read())
                {
                    SuppNameCombo.Items.Add(dr["SuppName"].ToString());
                }
                dr.Close();
                conn.Close();
                SuppNameCombo.Focus();
            }
        }

        private void SuppNameCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetConnection();
            OleDbCommand cmd = new OleDbCommand("Select ID from SupplierTbl where SuppName='" + SuppNameCombo.Text + "'", conn);
            textSuppId.Text = cmd.ExecuteScalar().ToString();
            conn.Close();
        }

        private void SuppNameCombo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textSrNo.Text = "1";
                textSrNo.Focus();
            }
        }

        private void textSrNo_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                SetConnection();
                ProdNameCombo.Items.Clear();
                cmd = new OleDbCommand("Select ProdName from ProductTbl", conn);
                OleDbDataReader dr = cmd.ExecuteReader();
                while(dr.Read())
                {
                    ProdNameCombo.Items.Add(dr["ProdName"].ToString());

                }
                dr.Close();
                conn.Close();
                ProdNameCombo.Focus();

            }
        }
        private void ProdNameCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetConnection();
            OleDbCommand cmd = new OleDbCommand("Select ID,ProdPrice from ProductTbl where ProdName='" + ProdNameCombo.Text + "'", conn);
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                textProdId.Text = dr["ID"].ToString();
                textPrice.Text = dr["ProdPrice"].ToString();
            }
            dr.Close();
            conn.Close();
        }


        private void ProdNameCombo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textPrice.Focus();
            }
        }

        private void textQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textAmount.Text = (Convert.ToDouble(textQty.Text) * Convert.ToDouble(textPrice.Text)).ToString();
                textAmount.Focus();
            }
        }

        private void textPrice_KeyDown(object sender, KeyEventArgs e)
        {
           
            if (e.KeyCode == Keys.Enter)
            {
                textQty.Focus();
            }
            
        }

        private void textAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dr1 = dt.NewRow();
                dr1["SrNo"] = Convert.ToInt32(textSrNo.Text);
                dr1["ProdName"] = ProdNameCombo.Text;
                dr1["ProdQty"] = Convert.ToInt32(textQty.Text);
                dr1["Price"] = Convert.ToInt32(textPrice.Text);
                dr1["Amount"] = Convert.ToInt32(textAmount.Text);
                dt.Rows.Add(dr1);
                dataGridView1.DataSource = dt;

                textTotAmt.Text = (Convert.ToInt32(textTotAmt.Text) + Convert.ToInt32(textAmount.Text)).ToString();

                textProdId.Clear();
                textPrice.Clear();
                textQty.Clear();
                textAmount.Clear();
                textSrNo.Text = (Convert.ToInt32(textSrNo.Text) + 1).ToString();
                textSrNo.Focus();

             /*   textTotAmt.Text = (Convert.ToInt32(textTotAmt.Text) + Convert.ToInt32(textAmount.Text)).ToString();
               
                textSrNo.Text = (Convert.ToInt32(textSrNo.Text) + 1).ToString();
                textSrNo.Focus();*/
            }
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (Flag == "A")
            {
                SetConnection();
                cmd.Connection = conn;
                cmd = new OleDbCommand("insert into PurchaseMaster (PurchID,tDate,SuppID,SuppName,PurchAmount) values(" + textPurchID.Text + ",#" + dtpdatePicker1.Value + "#, " + textSuppId.Text + ", '" + SuppNameCombo.Text + "'," + textTotAmt.Text + ")", conn);

                cmd.ExecuteNonQuery();
            }
            for (int i = 0; i <= (dataGridView1.Rows.Count) - 2; i++)
            {
                SetConnection();
                cmd = new OleDbCommand("Insert Into PurchaseDetails (SrNo,PurchID,ProdName,Qty,Price,Amount) Values (" + dataGridView1.Rows[i].Cells[0].Value + "," + textPurchID.Text + ",'" + dataGridView1.Rows[i].Cells[1].Value + "'," + dataGridView1.Rows[i].Cells[2].Value + "," + dataGridView1.Rows[i].Cells[3].Value + "," + dataGridView1.Rows[i].Cells[4].Value + ")", conn);
              
                cmd.ExecuteNonQuery();

            }

            MessageBox.Show("Data Inserted");
            if (Flag == "M")
            {
                cmd = new OleDbCommand("DELETE FROM PurchaseDetails where PurchID = " + textPurchID.Text + "", conn);
                cmd.ExecuteNonQuery();
                for (int i = 0; i <= (dataGridView1.Rows.Count) - 2; i++)
                {
                    cmd = new OleDbCommand("INSERT INTO PurchaseDetails (SrNo,PurchID,ProdName,Price,Qty,Amount) Values (" + dataGridView1.Rows[i].Cells[0].Value + "," + textPurchID.Text + ",'" + dataGridView1.Rows[i].Cells[1].Value + "'," + dataGridView1.Rows[i].Cells[2].Value + "," + dataGridView1.Rows[i].Cells[3].Value + "," + dataGridView1.Rows[i].Cells[4].Value + ")", conn);
                }
            }
            Flag = "";
            FormClear();
            btnNew.Focus();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            FormClear();
            Flag = "M";
            textPurchID.Focus();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            FormClear();
            Flag = "D";
            textPurchID.Focus();
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            Customer Cust = new Customer();
            Cust.Show();
            this.Hide();
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            Product Prod = new Product();
            Prod.Show();
            this.Hide();
        }

        private void btnSuplier_Click(object sender, EventArgs e)
        {
            Supplier Supp = new Supplier();
            Supp.Show();
            this.Hide();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Form2 Log = new Form2();
            Log.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            CustBill Log = new CustBill();
            Log.Show();
            this.Hide();
        }
    }
}
 