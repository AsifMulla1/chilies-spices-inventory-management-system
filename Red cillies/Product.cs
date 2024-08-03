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
       
    public partial class Product : Form
    {

       
        public Product()
        {
            InitializeComponent();
            ctrlGotFocus();
            ctrlLostFocus();
            
        }
        Operations Op = new Operations();
        
        String query;
        String myquery;
        int Prodid;
        private void GetProduct()
        {
            myquery = "select * from ProductTbl";
            var ds = Op.populate(myquery);
            dataGridView1.DataSource = ds.Tables[0];
        }
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                Prodid = Op.count();
                query = "insert into ProductTbl values(" +Prodid+ ",'" + ProdNameTb.Text + "','" + BrandCb.SelectedItem.ToString() + "','" + CategoryCb.SelectedItem.ToString() + "'," + ProdQty.Text + "," + PriceTb.Text + ")";
                Op.insertdata(query);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }


        }

        
        
        //Keydown
        private void ID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ProdNameTb.Focus();
            }
        }

        private void ProdNameTb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ProdQty.Focus();
            }
        }

        private void ProdQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BrandCb.Focus();
            }
        }

        private void BrandCb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CategoryCb.Focus();
            }
        }

        private void CategoryCb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                PriceTb.Focus();
            }
        }

        private void PriceTb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
               button4.Focus();
            }
        }

        //Gridview
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            GetProduct();
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
        private void ID_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != (char)Keys.Space && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void PriceTb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != (char)Keys.Space && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void ProdQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != (char)Keys.Space && e.KeyChar != (char)Keys.Back && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void ProdNameTb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)Keys.Space && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void ID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != (char)Keys.Space && e.KeyChar != (char)Keys.Back && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                myquery = "Delete from ProductTbl where ID = "+ID.Text+";";
                Op.deleteProduct(myquery);
                GetProduct();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ID.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            ProdNameTb.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            BrandCb.SelectedItem = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            CategoryCb.SelectedItem = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            ProdQty.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            PriceTb.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                myquery = "update ProductTbl set ProdName = '"+ProdNameTb.Text+"', prodBrand = '"+BrandCb.SelectedItem.ToString()+"',ProdCat = '"+CategoryCb.SelectedItem.ToString()+"', ProdQty = "+ProdQty.Text+",ProdPrice = "+PriceTb.Text+" where ID = "+ID.Text+";";
                
                Op.Editdata(myquery);
                GetProduct();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
        private void clear()
        {
            ID.Text = "";
            ProdNameTb.Text = "";
            BrandCb.SelectedItem = -1;
            CategoryCb.SelectedItem = -1;
            ProdQty.Text = "";
            PriceTb.Text = "";
        }
        private void button7_Click(object sender, EventArgs e)
        {
            Refresh();
            clear();
        }

        private void Product_Load(object sender, EventArgs e)
        {

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

        private void btnSupplier_Click(object sender, EventArgs e)
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

        private void btnBill_Click(object sender, EventArgs e)
        {
            CustBill Bill = new CustBill();
            Bill.Show();
            this.Hide();
        }
    }
}
