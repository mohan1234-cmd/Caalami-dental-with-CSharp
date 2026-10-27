using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace System
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

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            if (progressBar1.Value<100)
            {
                progressBar1.Value += 2;
                label1.Text = progressBar1.Value.ToString()+ "%";
            }
            else
            {
                timer1.Stop();  
                LoginForm   l=new LoginForm();
                l.Show();
                this.Hide();
            }
        }
    }
}
