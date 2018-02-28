using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Emlak
{
    public partial class Giriş : Form
    {
        public Giriş()
        {
            InitializeComponent();
        }
        // log -in ve yeni form alanı.

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (textBox1.Text == "admin" && textBox2.Text == "admin")
            {

                Form2 f2 = new Form2();
                f2.Show();
                this.Hide();
            }

            else
            {
                MessageBox.Show("Incorrect ID or Pass !", "Please ReEnter ID or Pass", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label3.Text = label3.Text.Substring(1) + label3.Text.Substring(0, 1);
        }
    }
}
