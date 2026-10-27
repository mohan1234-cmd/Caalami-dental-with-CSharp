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
    public partial class AppointmentFormReport : Form
    {
        private string connectionstring = @"Data Source=DESKTOP-PB208MO;Initial Catalog=CaalamiDentalClinic;Integrated Security=True";

        public AppointmentFormReport()
        {
            InitializeComponent();
            LoadDentists();
            LoadPatients();

            LoadStatus();
            dtpAppointmentDate.Checked = false;
        }
        private void LoadPatients()
        {
            string query = @"
        SELECT PatientId, PatientName
        FROM Patients
        ORDER BY PatientName";

            using (SqlConnection con = new SqlConnection(connectionstring))
            using (SqlDataAdapter da = new SqlDataAdapter(query, con))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbPatients.DataSource = dt;
                cmbPatients.DisplayMember = "PatientName";
                cmbPatients.ValueMember = "PatientId";
                cmbPatients.SelectedIndex = -1;
            }
        }
        private void LoadDentists()
        {
            string query = @"
        SELECT DentistId, DentistName
        FROM Dentists
        ORDER BY DentistName";

            using (SqlConnection con = new SqlConnection(connectionstring))
            using (SqlDataAdapter da = new SqlDataAdapter(query, con))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbDentitst.DataSource = dt;
                cmbDentitst.DisplayMember = "DentistName";
                cmbDentitst.ValueMember = "DentistId";
                cmbDentitst.SelectedIndex = -1;
            }
        }
        private void LoadStatus()
        {
            cmbStatus.Items.Clear();

            cmbStatus.Items.Add("Pending");
            cmbStatus.Items.Add("Completed");
            cmbStatus.Items.Add("Cancelled");

            cmbStatus.SelectedIndex = -1;
        }
        private void AppointmentFormReport_Load(object sender, EventArgs e)
        {

        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
         
            try
            {
                int patientId = 0;
                int dentistId = 0;
                string status = "";

                if (cmbPatients.SelectedIndex != -1)
                {
                    patientId = Convert.ToInt32(cmbPatients.SelectedValue);
                }

                if (cmbDentitst.SelectedIndex != -1)
                {
                    dentistId = Convert.ToInt32(cmbDentitst.SelectedValue);
                }

                if (cmbStatus.SelectedIndex != -1)
                {
                    status = cmbStatus.Text.Trim();
                }

                if (patientId == 0 &&
                    dentistId == 0 &&
                    string.IsNullOrEmpty(status) &&
                    !dtpAppointmentDate.Checked)
                {
                    MessageBox.Show(
                        "Fadlan dooro Patient, Dentist, Status ama Date.",
                        "Search",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }

                string query = @"
            SELECT *
            FROM Appointments
            WHERE
                (@PatientId = 0 OR PatientId = @PatientId)
                AND
                (@DentistId = 0 OR DentistId = @DentistId)
                AND
                (@Status = '' OR Status = @Status)
                AND
                (@UseDate = 0 OR CAST(AppointmentDate AS DATE) = @AppointmentDate)
            ORDER BY AppointmentId DESC";

                DataTable dt = new DataTable();

                using (SqlConnection con = new SqlConnection(connectionstring))
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@PatientId", patientId);
                    cmd.Parameters.AddWithValue("@DentistId", dentistId);
                    cmd.Parameters.AddWithValue("@Status", status);

                    cmd.Parameters.AddWithValue(
                        "@UseDate",
                        dtpAppointmentDate.Checked ? 1 : 0
                    );

                    cmd.Parameters.AddWithValue(
                        "@AppointmentDate",
                        dtpAppointmentDate.Value.Date
                    );

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show(
                        "Appointment lama helin.",
                        "Search Result",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    crystalReportViewer1.ReportSource = null;
                    return;
                }

                AppointmentReport report = new AppointmentReport();

                report.SetDataSource(dt);

                crystalReportViewer1.ReportSource = report;
                crystalReportViewer1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Search Error:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
    }