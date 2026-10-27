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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void gunaTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void gunaTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void gunaButton2_Click(object sender, EventArgs e)
        {
            if (txtusername.Text==""||txtpassword.Text=="")
            {
                MessageBox.Show("Fill the blank space");
            }
            else if(txtusername.Text=="Admin"&&txtpassword.Text=="123"&& cmbrole.Text=="Admin")
            {
                Dashboard d=new Dashboard();
                d.Show();
                this.Hide();
            }
            else if(cmbrole.SelectedIndex==-1){
                MessageBox.Show("dooro horta role kaaga");
            }


            else if (txtusername.Text == "User" && txtpassword.Text == "1122" && cmbrole.Text=="User")
            {
                Dashboard d = new Dashboard();
                d.Show();
                d.gunaButton6.Enabled=false;
                d.gunaButton5.Enabled=false;
                d.gunaButton9.Enabled=false;
                this.Hide();
            }
            else
            {
                MessageBox.Show("wrong password or username or role", "", MessageBoxButtons.OK);
            }

        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
            txtusername.Clear();
            txtpassword.Clear();
            cmbrole.SelectedIndex = -1;
        }
    }
}
