using System.Windows.Forms;

namespace System
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
           
            InitializeComponent();
            this.WindowState=FormWindowState.Maximized;
           
           
          
         

        }

        private void gunaButton3_Click(object sender, EventArgs e)
        {
            addappoint();
            Uc_Appointmens uc=new Uc_Appointmens();
        }

        private void gunaButton2_Click(object sender, EventArgs e)
        {
            adduser();
            Uc_Patients uc=new Uc_Patients();
            

        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {

        }

        private void gunaButton6_Click(object sender, EventArgs e)
        {
            addpayment();
            UC_Payment payment = new UC_Payment();
        }

        private void gunaButton5_Click(object sender, EventArgs e)
        {
            addsalary();
            Uc_salary uc=new Uc_salary();
        }

        private void gunaButton2_Click_1(object sender, EventArgs e)
        {
           addtreatment();
            Uc_Treatment uc=new Uc_Treatment();
        }

        private void gunaButton7_Click(object sender, EventArgs e)
        {
            addDentits();
            Uc_Dentists uc = new Uc_Dentists();
        }

        private void gunaButton8_Click(object sender, EventArgs e)
        {
            addreport();
            uc_report uc=new uc_report();
        }

        private void uc_Patients1_Load(object sender, EventArgs e)
        {

        }

        private void gunaButton9_Click(object sender, EventArgs e)
        {
            addexpenses();
            Uc_expense uc=new Uc_expense();
        }

        private void uc_Appointmens1_Load(object sender, EventArgs e)
        {

        }

        private void gunaButton1_Click_1(object sender, EventArgs e)
        {
            adddash();
          uc_dashboard uc=new uc_dashboard();   
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            LoginForm l=new LoginForm();
            l.Show();
            this.Hide();
        }

        private void gunaButton4_Click(object sender, EventArgs e)
        {
           
        }

        private void gunaButton10_Click(object sender, EventArgs e)
        {
           
        }

        private void gunaButton11_Click(object sender, EventArgs e)
        {
         
           
        }

        private void closebtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Maximized)
            {
                this.WindowState=FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Minimized;
            }
            
        }

        private void uc_Patients1_Load_1(object sender, EventArgs e)
        {

        }
       private void adduser()
        {
            panelContainer.Controls.Clear();
           uc_Patients1.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(uc_Patients1);
            uc_Patients1.BringToFront();
        }

        private void addDentits()
        {
            panelContainer.Controls.Clear();
            uc_Dentists1.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(uc_Dentists1);
            uc_Dentists1.BringToFront();
        }
        private void addtreatment()
        {
            panelContainer.Controls.Clear();
            uc_Treatment1.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(uc_Treatment1);
            uc_Treatment1.BringToFront();
        }
        private void addpayment()
        {
            panelContainer.Controls.Clear();
            uC_Payment1.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(uC_Payment1);
            uC_Payment1.BringToFront();
        }

        private void addsalary()
        {
            panelContainer.Controls.Clear();
            uc_salary1.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(uc_salary1);
            uc_salary1.BringToFront();
        }
        private void addreport()
        {
            panelContainer.Controls.Clear();
            uc_report1.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(uc_report1);
            uc_report1.BringToFront();
        }
        private void addexpenses()
        {
            panelContainer.Controls.Clear();
            uc_expense1.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(uc_expense1);
            uc_expense1.BringToFront();
        }

        private void addappoint()
        {
            panelContainer.Controls.Clear();
            uc_Appointmens1.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(uc_Appointmens1);
            uc_Appointmens1.BringToFront();
        }
        private void adddash()
        {
            panelContainer.Controls.Clear();
            uc_dashboard1.Size=panelContainer.ClientSize;
            
            uc_dashboard1.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(uc_dashboard1);
            uc_dashboard1.BringToFront();
        }

        private void Dashboard_Resize(object sender, EventArgs e)
        {
            if (uc_dashboard1!=null)
            {
                uc_dashboard1.Dock= DockStyle.Fill;
                uc_dashboard1.Size=panelContainer.ClientSize;
            }
        }
    }
}
