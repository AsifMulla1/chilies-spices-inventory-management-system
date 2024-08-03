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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            ctrlGotFocus();
            ctrlLostFocus();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(100, 0, 0, 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(UidTb.Text==""|| PasswordTb.Text=="")
            {
                MessageBox.Show("Enter Admin Name and Password");
            }
            else if(UidTb.Text=="Admin"&& PasswordTb.Text=="Pass")
            {
                MDI main = new MDI();
                main.Show();
                this.Hide();
            }else
            {
                MessageBox.Show("Wrong Admin Name or Password");
            }
           
        }

        private void UidTb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                PasswordTb.Focus();
            }
        }

        private void PasswordTb_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                button1.Focus();
            }
        }

        private void UidTb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)Keys.Space && e.KeyChar != (char)Keys.Back && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
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

       

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
