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
    public partial class Uc_Appointmens : UserControl
    {
        private string connectionstring = @"Data Source=DESKTOP-PB208MO;Initial Catalog=CaalamiDentalClinic;Integrated Security=True";
        private int appointmentId = 0;
       

        public Uc_Appointmens()
        {
            InitializeComponent();
            LoadPatients();
            LoadDentists();
            LoadTreatments();
            LoadStatus();
            LoadAppointments();

            dtpAppointmentTime.Format = DateTimePickerFormat.Time;
            dtpAppointmentTime.ShowUpDown = true;
        }

        private void LoadPatients()
        {
            try
            {
                using (SqlConnection con =
                    new SqlConnection(connectionstring))
                {
                    string query = @"
                SELECT PatientId, PatientName
                FROM Patients
                ORDER BY PatientName";

                    using (SqlDataAdapter da =
                        new SqlDataAdapter(query, con))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        cmbPatient.DataSource = dt;
                        cmbPatient.DisplayMember = "PatientName";
                        cmbPatient.ValueMember = "PatientId";
                        cmbPatient.SelectedIndex = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error loading patients:\n" + ex.Message);
            }
        }
        private void LoadDentists()
        {
            try
            {
                using (SqlConnection con =
                    new SqlConnection(connectionstring))
                {
                    string query = @"
                SELECT DentistId, DentistName
                FROM Dentists
                ORDER BY DentistName";

                    using (SqlDataAdapter da =
                        new SqlDataAdapter(query, con))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        cmbDentists.DataSource = dt;
                        cmbDentists.DisplayMember = "DentistName";
                        cmbDentists.ValueMember = "DentistId";
                        cmbDentists.SelectedIndex = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error loading dentists:\n" + ex.Message);
            }
        }

        private void LoadTreatments()
        {
            try
            {
                using (SqlConnection con =
                    new SqlConnection(connectionstring))
                {
                    string query = @"
                SELECT TreatmentId, TreatmentName
                FROM Treatments
                WHERE Status = 'Available'
                ORDER BY TreatmentName";

                    using (SqlDataAdapter da =
                        new SqlDataAdapter(query, con))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        cmbTreatment.DataSource = dt;
                        cmbTreatment.DisplayMember = "TreatmentName";
                        cmbTreatment.ValueMember = "TreatmentId";
                        cmbTreatment.SelectedIndex = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error loading treatments:\n" + ex.Message);
            }
        }

        private void LoadStatus()
        {
            cmbStatus.Items.Clear();

            cmbStatus.Items.Add("Pending");
            cmbStatus.Items.Add("Completed");
            cmbStatus.Items.Add("Cancelled");

            cmbStatus.SelectedIndex = 0;
        }

        private void LoadAppointments()
        {
            try
            {
                using (SqlConnection con =
                    new SqlConnection(connectionstring))
                {
                    string query = @"
                SELECT
                    AppointmentId,
                    PatientId,
                    PatientName,
                    DentistId,
                    DentistName,
                    TreatmentId,
                    TreatmentName,
                    AppointmentDate,
                    AppointmentTime,
                    Status
                FROM Appointments
                ORDER BY AppointmentId DESC";

                    using (SqlDataAdapter da =
                        new SqlDataAdapter(query, con))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        dgvAppointments.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error loading appointments:\n" + ex.Message);
            }
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
          
            if (cmbPatient.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a patient.");
                return;
            }

            if (cmbDentists.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a dentist.");
                return;
            }

            if (cmbTreatment.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a treatment.");
                return;
            }

            if (cmbStatus.SelectedIndex == -1)
            {
                MessageBox.Show("Please select status.");
                return;
            }

            try
            {
                using (SqlConnection con =
                    new SqlConnection(connectionstring))
                {
                    string query = @"
                INSERT INTO Appointments
                (
                    PatientId,
                    PatientName,
                    DentistId,
                    DentistName,
                    TreatmentId,
                    TreatmentName,
                    AppointmentDate,
                    AppointmentTime,
                    Status
                )
                VALUES
                (
                    @PatientId,
                    @PatientName,
                    @DentistId,
                    @DentistName,
                    @TreatmentId,
                    @TreatmentName,
                    @AppointmentDate,
                    @AppointmentTime,
                    @Status
                )";

                    using (SqlCommand cmd =
                        new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue(
                            "@PatientId",
                            cmbPatient.SelectedValue);

                        cmd.Parameters.AddWithValue(
                            "@PatientName",
                            cmbPatient.Text);

                        cmd.Parameters.AddWithValue(
                            "@DentistId",
                            cmbDentists.SelectedValue);

                        cmd.Parameters.AddWithValue(
                            "@DentistName",
                            cmbDentists.Text);

                        cmd.Parameters.AddWithValue(
                            "@TreatmentId",
                            cmbTreatment.SelectedValue);

                        cmd.Parameters.AddWithValue(
                            "@TreatmentName",
                            cmbTreatment.Text);

                        cmd.Parameters.AddWithValue(
                            "@AppointmentDate",
                            dtpAppointmentDate.Value.Date);

                        cmd.Parameters.AddWithValue(
                            "@AppointmentTime",
                            dtpAppointmentTime.Value.TimeOfDay);

                        cmd.Parameters.AddWithValue(
                            "@Status",
                            cmbStatus.Text);

                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show(
                    "Appointment saved successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LoadAppointments();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error saving appointment:\n" + ex.Message);
            }
        }

        private void dgvAppointments_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row =
                dgvAppointments.Rows[e.RowIndex];

            appointmentId =
                Convert.ToInt32(row.Cells["AppointmentId"].Value);

            cmbPatient.SelectedValue =
                row.Cells["PatientId"].Value;

            cmbDentists.SelectedValue =
                row.Cells["DentistId"].Value;

            cmbTreatment.SelectedValue =
                row.Cells["TreatmentId"].Value;

            dtpAppointmentDate.Value =
                Convert.ToDateTime(
                    row.Cells["AppointmentDate"].Value);

            dtpAppointmentTime.Value =
                DateTime.Today.Add(
                    (TimeSpan)row.Cells["AppointmentTime"].Value);

            cmbStatus.Text =
                row.Cells["Status"].Value.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
           
            if (appointmentId == 0)
            {
                MessageBox.Show("Please select an appointment first.");
                return;
            }

            if (cmbPatient.SelectedIndex == -1 ||
                cmbDentists.SelectedIndex == -1 ||
                cmbTreatment.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Please select patient, dentist and treatment.");
                return;
            }

            try
            {
                using (SqlConnection con =
                    new SqlConnection(connectionstring))
                {
                    string query = @"
                UPDATE Appointments
                SET
                    PatientId = @PatientId,
                    PatientName = @PatientName,
                    DentistId = @DentistId,
                    DentistName = @DentistName,
                    TreatmentId = @TreatmentId,
                    TreatmentName = @TreatmentName,
                    AppointmentDate = @AppointmentDate,
                    AppointmentTime = @AppointmentTime,
                    Status = @Status
                WHERE AppointmentId = @AppointmentId";

                    using (SqlCommand cmd =
                        new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue(
                            "@PatientId",
                            cmbPatient.SelectedValue);

                        cmd.Parameters.AddWithValue(
                            "@PatientName",
                            cmbPatient.Text);

                        cmd.Parameters.AddWithValue(
                            "@DentistId",
                            cmbDentists.SelectedValue);

                        cmd.Parameters.AddWithValue(
                            "@DentistName",
                            cmbDentists.Text);

                        cmd.Parameters.AddWithValue(
                            "@TreatmentId",
                            cmbTreatment.SelectedValue);

                        cmd.Parameters.AddWithValue(
                            "@TreatmentName",
                            cmbTreatment.Text);

                        cmd.Parameters.AddWithValue(
                            "@AppointmentDate",
                            dtpAppointmentDate.Value.Date);

                        cmd.Parameters.AddWithValue(
                            "@AppointmentTime",
                            dtpAppointmentTime.Value.TimeOfDay);

                        cmd.Parameters.AddWithValue(
                            "@Status",
                            cmbStatus.Text);

                        cmd.Parameters.AddWithValue(
                            "@AppointmentId",
                            appointmentId);

                        con.Open();

                        int rows = cmd.ExecuteNonQuery();

                        if (rows > 0)
                        {
                            MessageBox.Show(
                                "Appointment updated successfully.",
                                "Success",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                        }
                    }
                }

                LoadAppointments();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error updating appointment:\n" + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
        
            if (appointmentId == 0)
            {
                MessageBox.Show("Please select an appointment first.");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this appointment?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            try
            {
                using (SqlConnection con =
                    new SqlConnection(connectionstring))
                {
                    string query =
                        "DELETE FROM Appointments WHERE AppointmentId = @AppointmentId";

                    using (SqlCommand cmd =
                        new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue(
                            "@AppointmentId",
                            appointmentId);

                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show(
                    "Appointment deleted successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LoadAppointments();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error deleting appointment:\n" + ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
         
            ClearFields();
        }

        private void ClearFields()
        {
            cmbPatient.SelectedIndex = -1;
            cmbDentists.SelectedIndex = -1;
            cmbTreatment.SelectedIndex = -1;

            dtpAppointmentDate.Value = DateTime.Today;
            dtpAppointmentTime.Value = DateTime.Now;

            cmbStatus.SelectedIndex = 0;

            appointmentId = 0;

            dgvAppointments.ClearSelection();
        }

        private void Uc_Appointmens_Load(object sender, EventArgs e)
        {

        }

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtsearching_TextChanged(object sender, EventArgs e)
        {
         
            try
            {
                using (SqlConnection con = new SqlConnection(connectionstring))
                {
                    string query = @"
                SELECT
                    AppointmentId,
                    PatientId,
                    PatientName,
                    DentistId,
                    DentistName,
                    TreatmentId,
                    TreatmentName,
                    AppointmentDate,
                    AppointmentTime,
                    Status
                FROM Appointments
                WHERE PatientName LIKE @Search
                   OR DentistName LIKE @Search
                   OR TreatmentName LIKE @Search
                   OR Status LIKE @Search
                ORDER BY AppointmentId DESC";

                    using (SqlDataAdapter da = new SqlDataAdapter(query, con))
                    {
                        da.SelectCommand.Parameters.AddWithValue(
                            "@Search",
                            "%" + txtsearching.Text.Trim() + "%"
                        );

                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        dgvAppointments.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
    }
    
    
    
    
    

