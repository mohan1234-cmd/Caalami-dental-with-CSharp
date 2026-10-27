using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace System
{
    public partial class Uc_Patients : UserControl
    {
        private string connectionstring = @"Data Source=DESKTOP-PB208MO;Initial Catalog=CaalamiDentalClinic;Integrated Security=True";
        private int patientId = 0;
        public Uc_Patients()
        {
            InitializeComponent();
            LoadGender();
            LoadPatients();

        }

        private void datadisplay()
        {
            try
            {
                string sql = "SELECT*FROM Patients";

                using (SqlConnection con = new SqlConnection(connectionstring))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(sql, con))
                    {
                        DataTable dt = new DataTable();

                        da.Fill(dt);

                        dgvPatients.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error loading patients: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
        private void LoadGender()
        {
            cmbGender.Items.Clear();

            cmbGender.Items.Add("Male");
            cmbGender.Items.Add("Female");
        }



        private void LoadPatients()
        {
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                string query = "SELECT * FROM Patients";

                SqlDataAdapter da = new SqlDataAdapter(query, con);

                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvPatients.DataSource = dt;
            }
        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
         
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row = dgvPatients.Rows[e.RowIndex];

            patientId = Convert.ToInt32(row.Cells["PatientId"].Value);

            txtPatientName.Text = row.Cells["PatientName"].Value.ToString();
            cmbGender.Text = row.Cells["Gender"].Value.ToString();
            txtPhone.Text = row.Cells["Phone"].Value.ToString();
            txtAddress.Text = row.Cells["Address"].Value.ToString();

            if (row.Cells["DateOfBirth"].Value != DBNull.Value)
            {
                dtpDateOfBirth.Value =
                    Convert.ToDateTime(row.Cells["DateOfBirth"].Value);
            }
        }
        
        private void Uc_Patients_Load(object sender, EventArgs e)
        {
            datadisplay
                ();
        }

        private void gunaButton2_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtPatientName.Text == "" ||
                            cmbGender.Text == "" ||
                            txtPhone.Text == "")
            {
                MessageBox.Show("Please fill the required fields.");
                return;
            }

            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                string query = @"INSERT INTO Patients
                                (PatientName, Gender, Phone, Address, DateOfBirth)
                                VALUES
                                (@PatientName, @Gender, @Phone, @Address, @DateOfBirth)";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@PatientName",
                    txtPatientName.Text);

                cmd.Parameters.AddWithValue("@Gender",
                    cmbGender.Text);

                cmd.Parameters.AddWithValue("@Phone",
                    txtPhone.Text);

                cmd.Parameters.AddWithValue("@Address",
                    txtAddress.Text);

                cmd.Parameters.AddWithValue("@DateOfBirth",
                    dtpDateOfBirth.Value.Date);

                con.Open();
                cmd.ExecuteNonQuery();

                MessageBox.Show("Patient saved successfully.");

                ClearFields();
                LoadPatients();
            }
        }

        private void ClearFields()
        {
            txtPatientName.Clear();
            cmbGender.SelectedIndex = -1;
            txtPhone.Clear();
            txtAddress.Clear();
            dtpDateOfBirth.Value = DateTime.Today;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
          
            if (patientId == 0)
            {
                MessageBox.Show(
                    "Please select a patient first.",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this patient?",
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
                    string query = @"
                DELETE FROM Patients
                WHERE PatientId = @PatientId";

                    using (SqlCommand cmd =
                        new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue(
                            "@PatientId",
                            patientId);

                        con.Open();

                        int rows = cmd.ExecuteNonQuery();

                        if (rows > 0)
                        {
                            MessageBox.Show(
                                "Patient deleted successfully.",
                                "Success",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                        }
                    }
                }

                LoadPatients();
                ClearFields();
                patientId = 0;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    "This patient cannot be deleted because other records are connected to this patient.\n\n" +
                    ex.Message,
                    "Delete Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error deleting patient:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            if (patientId == 0)
            {
                MessageBox.Show(
                    "Please select a patient first.",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (txtPatientName.Text.Trim() == "")
            {
                MessageBox.Show("Please enter patient name.");
                return;
            }

            if (cmbGender.SelectedIndex == -1)
            {
                MessageBox.Show("Please select gender.");
                return;
            }

            if (txtPhone.Text.Trim() == "")
            {
                MessageBox.Show("Please enter phone number.");
                return;
            }

            try
            {
                using (SqlConnection con =
                    new SqlConnection(connectionstring))
                {
                    string query = @"
                UPDATE Patients
                SET
                    PatientName = @PatientName,
                    Gender = @Gender,
                    Phone = @Phone,
                    Address = @Address,
                    DateOfBirth = @DateOfBirth
                WHERE PatientId = @PatientId";

                    using (SqlCommand cmd =
                        new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue(
                            "@PatientId", patientId);

                        cmd.Parameters.AddWithValue(
                            "@PatientName",
                            txtPatientName.Text.Trim());

                        cmd.Parameters.AddWithValue(
                            "@Gender",
                            cmbGender.Text);

                        cmd.Parameters.AddWithValue(
                            "@Phone",
                            txtPhone.Text.Trim());

                        cmd.Parameters.AddWithValue(
                            "@Address",
                            txtAddress.Text.Trim());

                        cmd.Parameters.AddWithValue(
                            "@DateOfBirth",
                            dtpDateOfBirth.Value.Date);

                        con.Open();

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected == 0)
                        {
                            MessageBox.Show(
                                "Patient was not found.");
                            return;
                        }
                    }
                }

                MessageBox.Show(
                    "Patient updated successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LoadPatients();

                ClearFields();

                patientId = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error updating patient:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void ClearFieldss()
        {
            txtPatientName.Clear();
            cmbGender.SelectedIndex = -1;
            txtPhone.Clear();
            txtAddress.Clear();
            dtpDateOfBirth.Value = DateTime.Today;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
           
            ClearFieldsss();
        }

        private void ClearFieldsss()
        {
            txtPatientName.Clear();
            txtPhone.Clear();
            txtAddress.Clear();

            cmbGender.SelectedIndex = -1;

            dtpDateOfBirth.Value = DateTime.Today;

            patientId = 0;

            dgvPatients.ClearSelection();
        }

        private void txtSearching_TextChanged(object sender, EventArgs e)
        {
          
            try
            {
                using (SqlConnection con = new SqlConnection(connectionstring))
                {
                    string query = @"
                SELECT
                    PatientId,
                    PatientName,
                    Gender,
                    Phone,
                    Address,
                    DateOfBirth
                FROM Patients
                WHERE PatientName LIKE @Search
                   OR Gender LIKE @Search
                   OR Phone LIKE @Search
                   OR Address LIKE @Search
                ORDER BY PatientId DESC";

                    using (SqlDataAdapter da = new SqlDataAdapter(query, con))
                    {
                        da.SelectCommand.Parameters.AddWithValue(
                            "@Search",
                            "%" + txtSearching.Text.Trim() + "%"
                        );

                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        dgvPatients.DataSource = dt;
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
    

    

    

