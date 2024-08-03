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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
            label1.Parent = pictureBox1;
            label2.Parent = pictureBox1;
            label3.Parent = pictureBox1;
            label1.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
            label3.BackColor = Color.Transparent;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           if(progressBar1.Value<100)
            {
                progressBar1.Value += 10;
                label3.Text = progressBar1.Value.ToString() + "%";
            }
           else
            {
                timer1.Stop();
                MessageBox.Show("Loading page successful");
                Form2 fm2 = new Form2();
                fm2.Show();
                this.Hide();
            }
        }
    }
}
