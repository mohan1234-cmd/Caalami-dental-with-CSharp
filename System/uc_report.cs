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
    public partial class uc_report : UserControl
    {
        public uc_report()
        {
            InitializeComponent();
        }

        private void r_patient_Click(object sender, EventArgs e)
        {
            PatientFormReport report=new PatientFormReport();
            report.Show
                ();
        }

        private void r_appointment_Click(object sender, EventArgs e)
        {
            AppointmentFormReport report=new AppointmentFormReport();
            report.Show();
        }

        private void r_payment_Click(object sender, EventArgs e)
        {
            PaymentFormReport report=new PaymentFormReport();
            report.Show();
        }

        private void r_salary_Click(object sender, EventArgs e)
        {
            SalaryFormReportcs report=new SalaryFormReportcs();
            report.Show();
        }
    }
}
