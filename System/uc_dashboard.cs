using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace System
{
    public partial class uc_dashboard : UserControl
    {
        private string connectionstring = @"Data Source=DESKTOP-PB208MO;Initial Catalog=CaalamiDentalClinic;Integrated Security=True";

        public uc_dashboard()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = true;
        }

        private void LoadTodaysAppointments()
        {
            try
            {
                string query = @"
            SELECT
                p.PatientName,
                d.DentistName,
                a.AppointmentDate,
                a.AppointmentTime,
                a.Status
            FROM Appointments a
            INNER JOIN Patients p
                ON a.PatientId = p.PatientId
            INNER JOIN Dentists d
                ON a.DentistId = d.DentistId
            WHERE CAST(a.AppointmentDate AS DATE) =
                  CAST(GETDATE() AS DATE)
            ORDER BY a.AppointmentTime ASC";

                DataTable dt = new DataTable();

                using (SqlConnection con = new SqlConnection(connectionstring))
                using (SqlDataAdapter da = new SqlDataAdapter(query, con))
                {
                    da.Fill(dt);
                }

                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Today's Appointments Error:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void LoadDashboardCounts()

        {

            try

            {

                using (SqlConnection con =

                    new SqlConnection(connectionstring))

                {

                    con.Open();


                    string queryPatients =

                        "SELECT COUNT(*) FROM Patients";

                    using (SqlCommand cmd =

                        new SqlCommand(queryPatients, con))

                    {

                        lblPatientsCount.Text =

                            cmd.ExecuteScalar().ToString();

                    }

                  

                    string queryDentists =

                        "SELECT COUNT(*) FROM Dentists";

                    using (SqlCommand cmd =

                        new SqlCommand(queryDentists, con))

                    {

                        lblDentistsCount.Text =

                            cmd.ExecuteScalar().ToString();

                    }

            

                    string queryAppointments =

                        "SELECT COUNT(*) FROM Appointments";

                    using (SqlCommand cmd =

                        new SqlCommand(queryAppointments, con))

                    {

                        lblAppointmentsCount.Text =

                            cmd.ExecuteScalar().ToString();

                    }

                   

                    string queryPayments = @"

                        SELECT ISNULL(SUM(Subtotal), 0)

                        FROM Payments";

                    using (SqlCommand cmd =

                        new SqlCommand(queryPayments, con))

                    {

                        lblPaymentsCount.Text =

                            cmd.ExecuteScalar().ToString();

                    }


                    string queryExpenses = @"

                        SELECT ISNULL(SUM(Amount), 0)

                        FROM Expenses";

                    using (SqlCommand cmd =

                        new SqlCommand(queryExpenses, con))

                    {

                        lblExpensesCount.Text =

                            cmd.ExecuteScalar().ToString();

                    }

                }

            }

            catch (Exception ex)

            {

                MessageBox.Show(

                    "Dashboard Error:\n" + ex.Message,

                    "Error",

                    MessageBoxButtons.OK,

                    MessageBoxIcon.Error);

            }
        }
        private void uc_dashboard_Load(object sender, EventArgs e)
        {
            LoadDashboardCounts();
            LoadTodaysAppointments();
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lblPatientsCount_Click(object sender, EventArgs e)
        {

        }
    }
    }

