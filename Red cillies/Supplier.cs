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
    public partial class Supplier : Form
    {
        private static string myConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\\RedCilliesDb.mdb";
        OleDbConnection conn = new OleDbConnection(myConn);

        public void SetConnection()
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
                // MessageBox.Show("Connectiom open");
            }
        }

        string Flag = "";

        public Supplier()
        {
            InitializeComponent();
            ctrlGotFocus();
            ctrlLostFocus();
            FormClear();

        }
    
        private void btnEdit_Click(object sender, EventArgs e)
        {
            FormClear();
            Flag = "M";
            textSid.Focus();
        }
    


        private void textSid_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                if (Flag == "M" || Flag == "D")
                {
                    SetConnection();
                    OleDbCommand cmd = new OleDbCommand();
                    cmd = new OleDbCommand("select * from SupplierTbl where ID = " + textSid.Text + "", conn);
                    OleDbDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        textSname.Text = dr["SuppName"].ToString();
                        textSaddr.Text = dr["SuppAddress"].ToString();
                        textSmob.Text = dr["SuppCont"].ToString();
                        textSemail.Text = dr["SuppEmail"].ToString();
                    }
                    if (Flag == "D")
                    {
                        string msg = "You want to delete ?";
                        DialogResult result = MessageBox.Show(msg, "Confirm detletion", MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            cmd = new OleDbCommand("Delete from SupplierTbl where ID = " + textSid.Text + "", conn);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Record Deleted Successfully..");
                            FormClear();
                            Flag = "";
                            btnNew.Focus();
                        }
                        else
                        {
                            FormClear();
                            Flag = "";
                            btnNew.Focus();
                        }
                    }
                }
                if (Flag == "A" || Flag == "M")
                {
                    textSname.Focus();
                }
                textSname.Focus();
            }
        }

        private void textSname_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textSaddr.Focus();
            }
        }

        private void textSaddr_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textSmob.Focus();
            }
        }

        private void textSmob_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textSemail.Focus();
            }
        }

        private void textSemail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnNew.Focus();
            }
        }
        //Focus
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
        private void FormClear()
        {
            foreach (Control c in panel1.Controls)
            {
                if (c is TextBox || c is ComboBox)
                {
                    c.Text = "";
                }
            }
        }
        private void ctrlGotFocus()
        {
            foreach (Control c in panel1.Controls)
            {
                if (c is TextBox || c is ComboBox)
                {
                    c.GotFocus += Onfocus;
                }
            }
        }
        private void ctrlLostFocus()
        {
            foreach (Control c in panel1.Controls)
            {
                if (c is TextBox || c is ComboBox)
                {
                    c.LostFocus += OnLostFocus;
                }
            }
        }

        private void textSid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != (char)Keys.Space && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void textSname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)Keys.Space && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void textSmob_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != (char)Keys.Space && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Flag = "A";
            FormClear();
            SetConnection();
            textSid.Focus();
            OleDbCommand cmd = new OleDbCommand("select max(ID) from SupplierTbl");
            cmd.Connection = conn;
            int id = (int)cmd.ExecuteScalar() + 1;
            conn.Close();
            textSid.Text = id.ToString();
            textSname.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Flag == "A")
            {
                
                OleDbCommand cmd = new OleDbCommand();
                cmd = new OleDbCommand("Insert Into SupplierTbl( ID ,SuppName,SuppAddress,SuppCont,SuppEmail) values (" + textSid.Text + ",'" + textSname.Text + "','" + textSaddr.Text + "','" + textSmob.Text + "','" + textSemail.Text + "') ", conn);
                SetConnection();
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Data inserted successfully...");
                Flag = "";
                FormClear();
                btnNew.Focus();

            }
            else if (Flag == "M")
            {
                SetConnection();
                OleDbCommand cmd = new OleDbCommand();
                cmd = new OleDbCommand("Update SupplierTbl set SuppName='" + textSname.Text + "',SuppAddress='" + textSaddr.Text + "',SuppCont='" + textSmob.Text + "', SuppEmail='" + textSemail.Text + "' where ID = " + textSid.Text + "", conn);
                cmd.Connection = conn;
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Data Updated successfully...");
                Flag = "";
                FormClear();
                btnNew.Focus();

            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            FormClear();
            Flag = "D";
            textSid.Focus();

        }

       

        private void btnProduct_Click(object sender, EventArgs e)
        {
            Product Prod = new Product();
            Prod.Show();
            this.Hide();
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {

            Customer Cust = new Customer();
            Cust.Show();
            this.Hide();
        }

        private void btnPurchase_Click(object sender, EventArgs e)
        {
            Purchase Purch = new Purchase();
            Purch.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form2 Log = new Form2();
            Log.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CustBill Log = new CustBill();
            Log.Show();
            this.Hide();
        }

        private void Supplier_Load(object sender, EventArgs e)
        {

        }

        private void textSname_TextChanged(object sender, EventArgs e)
        {

        }

        private void textSemail_Validating(object sender, CancelEventArgs e)
        {
            if (!this.textSemail.Text.Contains('@') || !this.textSemail.Text.Contains(".com"))
            {
                MessageBox.Show("Invalid Email!!");
            }
        }
    }
}
