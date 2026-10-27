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
    public partial class Uc_Dentists : UserControl

    {
        private int dentistsId = 0;
        private string connectionstring = @"Data Source=DESKTOP-PB208MO;Initial Catalog=CaalamiDentalClinic;Integrated Security=True";

        public Uc_Dentists()
        {
            InitializeComponent();
            LoadDentists();
        }
        private void datadisplay()
        {
            try
            {
                string sql = "SELECT*FROM Dentists";

                using (SqlConnection con = new SqlConnection(connectionstring))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(sql, con))
                    {
                        DataTable dt = new DataTable();

                        da.Fill(dt);

                        dgvDentists.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error loading Dentits: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
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
                SELECT
                    DentistId,
                    DentistName,
                    Phone,
                    Address,
                    Specialization,
                    SalaryAmount,
                    HireDate
                FROM Dentists
                ORDER BY DentistId DESC";

                    using (SqlDataAdapter da =
                        new SqlDataAdapter(query, con))
                    {
                        DataTable dt = new DataTable();

                        da.Fill(dt);

                        dgvDentists.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error loading dentists:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
           
            if (dentistsId == 0)
            {
                MessageBox.Show(
                    "Please select a dentist first.");

                return;
            }

            if (txtDentistsName.Text.Trim() == "")
            {
                MessageBox.Show(
                    "Please enter dentist name.");

                return;
            }

            if (txtPhone.Text.Trim() == "")
            {
                MessageBox.Show(
                    "Please enter phone number.");

                return;
            }

            if (txtSpecialization.Text.Trim() == "")
            {
                MessageBox.Show(
                    "Please enter specialization.");

                return;
            }

            decimal salary;

            if (!decimal.TryParse(
                txtSalaryAmount.Text.Trim(),
                out salary))
            {
                MessageBox.Show(
                    "Please enter a valid salary amount.");

                return;
            }

            try
            {
                using (SqlConnection con =
                    new SqlConnection(connectionstring))
                {
                    string query = @"
                UPDATE Dentists
                SET
                    DentistName = @DentistName,
                    Phone = @Phone,
                    Address = @Address,
                    Specialization = @Specialization,
                    SalaryAmount = @SalaryAmount,
                    HireDate = @HireDate
                WHERE DentistId = @DentistId";

                    using (SqlCommand cmd =
                        new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue(
                            "@DentistId",
                            dentistsId);

                        cmd.Parameters.AddWithValue(
                            "@DentistName",
                            txtDentistsName.Text.Trim());

                        cmd.Parameters.AddWithValue(
                            "@Phone",
                            txtPhone.Text.Trim());

                        cmd.Parameters.AddWithValue(
                            "@Address",
                            txtAddress.Text.Trim());

                        cmd.Parameters.AddWithValue(
                            "@Specialization",
                            txtSpecialization.Text.Trim());

                        cmd.Parameters.Add(
                            "@SalaryAmount",
                            SqlDbType.Decimal).Value = salary;

                        cmd.Parameters.AddWithValue(
                            "@HireDate",
                            dtpHireDate.Value.Date);

                        con.Open();

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show(
                    "Dentist updated successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LoadDentists();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error updating dentist:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        

        private void btnDelete_Click(object sender, EventArgs e)
        {
           
            if (dentistsId == 0)
            {
                MessageBox.Show(
                    "Please select a dentist first.");

                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this dentist?",
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
                DELETE FROM Dentists
                WHERE DentistId = @DentistId";

                    using (SqlCommand cmd =
                        new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue(
                            "@DentistId",
                            dentistsId);

                        con.Open();

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show(
                    "Dentist deleted successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LoadDentists();
                ClearFields();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    "This dentist cannot be deleted because " +
                    "the dentist is connected to other records.\n\n" +
                    ex.Message,
                    "Delete Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error deleting dentist:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        

        private void btnClear_Click(object sender, EventArgs e)
        {
          
            ClearFields();
        
        }
        private void ClearFields()
        {
            txtDentistsName.Clear();
            txtPhone.Clear();
            txtAddress.Clear();
            txtSpecialization.Clear();
            txtSalaryAmount.Clear();

            dtpHireDate.Value = DateTime.Today;

            dentistsId = 0;

            dgvDentists.ClearSelection();
        }
        private void btnsaveD_Click(object sender, EventArgs e)
        {
          
            if (txtDentistsName.Text.Trim() == "")
            {
                MessageBox.Show(
                    "Please enter dentist name.");

                return;
            }

            if (txtPhone.Text.Trim() == "")
            {
                MessageBox.Show(
                    "Please enter phone number.");

                return;
            }

            if (txtSpecialization.Text.Trim() == "")
            {
                MessageBox.Show(
                    "Please enter specialization.");

                return;
            }

            decimal salary;

            if (!decimal.TryParse(
                txtSalaryAmount.Text.Trim(),
                out salary))
            {
                MessageBox.Show(
                    "Please enter a valid salary amount.");

                return;
            }

            try
            {
                using (SqlConnection con =
                    new SqlConnection(connectionstring))
                {
                    string query = @"
                INSERT INTO Dentists
                (
                    DentistName,
                    Phone,
                    Address,
                    Specialization,
                    SalaryAmount,
                    HireDate
                )
                VALUES
                (
                    @DentistName,
                    @Phone,
                    @Address,
                    @Specialization,
                    @SalaryAmount,
                    @HireDate
                )";

                    using (SqlCommand cmd =
                        new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue(
                            "@DentistName",
                            txtDentistsName.Text.Trim());

                        cmd.Parameters.AddWithValue(
                            "@Phone",
                            txtPhone.Text.Trim());

                        cmd.Parameters.AddWithValue(
                            "@Address",
                            txtAddress.Text.Trim());

                        cmd.Parameters.AddWithValue(
                            "@Specialization",
                            txtSpecialization.Text.Trim());

                        cmd.Parameters.Add(
                            "@SalaryAmount",
                            SqlDbType.Decimal).Value = salary;

                        cmd.Parameters.AddWithValue(
                            "@HireDate",
                            dtpHireDate.Value.Date);

                        con.Open();

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show(
                    "Dentist saved successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LoadDentists();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error saving dentist:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        

        private void dgvDentists_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row = dgvDentists.Rows[e.RowIndex];

            dentistsId = Convert.ToInt32(
                row.Cells["DentistId"].Value);

            txtDentistsName.Text =
                row.Cells["DentistName"].Value.ToString();

            txtPhone.Text =
                row.Cells["Phone"].Value.ToString();

            txtAddress.Text =
                row.Cells["Address"].Value.ToString();

            txtSpecialization.Text =
                row.Cells["Specialization"].Value.ToString();

            txtSalaryAmount.Text =
                row.Cells["SalaryAmount"].Value.ToString();

            if (row.Cells["HireDate"].Value != DBNull.Value)
            {
                dtpHireDate.Value =
                    Convert.ToDateTime(
                        row.Cells["HireDate"].Value);
            }
        }

        private void Uc_Dentists_Load(object sender, EventArgs e)
        {
            datadisplay();
        }

        private void txtsearching_TextChanged(object sender, EventArgs e)
        {
           
            try
            {
                using (SqlConnection con = new SqlConnection(connectionstring))
                {
                    string query = @"
                SELECT
                    DentistId,
                    DentistName,
                    Phone,
                    Address,
                    Specialization,
                    SalaryAmount,
                    HireDate
                FROM Dentists
                WHERE DentistName LIKE @Search
                   OR Phone LIKE @Search
                   OR Address LIKE @Search
                   OR Specialization LIKE @Search
                ORDER BY DentistId DESC";

                    using (SqlDataAdapter da = new SqlDataAdapter(query, con))
                    {
                        da.SelectCommand.Parameters.AddWithValue(
                            "@Search",
                            "%" + txtsearching.Text.Trim() + "%"
                        );

                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        dgvDentists.DataSource = dt;
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
    

