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
    public partial class Customer : Form
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

        public Customer()
        {
            InitializeComponent();
            ctrlGotFocus();
            ctrlLostFocus();
            FormClear();
        }

        Operations Op = new Operations();

        //String query;
        //Keydown
        private void btnEdit_Click(object sender, EventArgs e)
        {
            FormClear();
            Flag = "M";
            textCidTb.Focus();
        }
        private void CidTb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if(Flag=="M"|| Flag=="D")
                {
                    SetConnection();
                    OleDbCommand cmd = new OleDbCommand();
                    cmd = new OleDbCommand("select * from CustomerTbl where ID = "+ textCidTb.Text+"", conn);
                    OleDbDataReader dr = cmd.ExecuteReader();
                    while(dr.Read())
                    {
                        textCnameTb.Text = dr["CustName"].ToString();
                        textCaddrTb.Text = dr["CustAdd"].ToString();
                        textCmobTb.Text = dr["CustCont"].ToString();
                        textCemailTb.Text = dr["CustEmail"].ToString();
                    }
                    if(Flag=="D")
                    {
                        string msg = "You want to delete ?";
                        DialogResult result = MessageBox.Show(msg, "Confirm detletion", MessageBoxButtons.YesNo);
                        if(result==DialogResult.Yes)
                        {
                            cmd = new OleDbCommand("Delete from CustomerTbl where ID = "+textCidTb.Text+"",conn);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Record Deleted Successfully..");
                            FormClear();
                            Flag = "";
                            button4.Focus();
                        }
                        else
                        {
                            FormClear();
                            Flag = "";
                            button4.Focus();
                        }
                    }
                }
                if(Flag=="A" || Flag=="M")
                {
                    textCnameTb.Focus();
                }
                textCnameTb.Focus();
            }
        }

        private void CnameTb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textCaddrTb.Focus();
            }
        }

        private void CaddrTb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textCmobTb.Focus();
            }
        }

        private void CmobTb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textCemailTb.Focus();
            }
        }

        private void CemailTb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button4.Focus();
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

        //validations
        private void CidTb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != (char)Keys.Space && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void CnameTb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)Keys.Space && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void CmobTb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != (char)Keys.Space && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Flag = "A";
            FormClear();
            SetConnection();
            OleDbCommand cmd = new OleDbCommand("select max(ID) from CustomerTbl");
            cmd.Connection = conn;
            int id = (int)cmd.ExecuteScalar()+1;
            conn.Close();
            textCidTb.Text = id.ToString();
            textCnameTb.Focus();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(Flag=="A")
            {
                SetConnection();
                OleDbCommand cmd = new OleDbCommand();
                cmd = new OleDbCommand("Insert Into CustomerTbl( ID , CustName,CustAdd,CustCont,CustEmail) values(" + textCidTb.Text + ",'" + textCnameTb.Text + "','" + textCaddrTb.Text + "','" + textCmobTb.Text + "','" + textCemailTb.Text + "') ", conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Data inserted successfully...");
                Flag = "";
                FormClear();
                button4.Focus();

            }
            else if(Flag=="M")
            {
                SetConnection();
                OleDbCommand cmd = new OleDbCommand();
                cmd = new OleDbCommand("Update CustomerTbl set CustName='" + textCnameTb.Text + "',CustAdd='" + textCaddrTb.Text + "',CustCont='" + textCmobTb.Text + "', CustEmail='"+ textCemailTb.Text + "' where ID = " + textCidTb.Text + "", conn);
                cmd.Connection=conn;
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Data Updated successfully...");
                Flag = "";
                FormClear();
                button4.Focus();

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
            textCidTb.Focus();

        }

        private void textCidTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void Customer_Load(object sender, EventArgs e)
        {

        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            Product Prod = new Product();
            Prod.Show();
            this.Hide();
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            Supplier Supp = new Supplier();
            Supp.Show();
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

        private void textCemailTb_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textCemailTb_Validating(object sender, CancelEventArgs e)
        {
            if (!this.textCemailTb.Text.Contains('@') || !this.textCemailTb.Text.Contains(".com"))
            {
                MessageBox.Show("Invalid Email!!");
            }
        }
    }
}
