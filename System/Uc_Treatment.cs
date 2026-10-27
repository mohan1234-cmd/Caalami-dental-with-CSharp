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
    public partial class Uc_Treatment : UserControl
    {
        private string connectionstring = @"Data Source=DESKTOP-PB208MO;Initial Catalog=CaalamiDentalClinic;Integrated Security=True";

        private int treatmentId = 0;
        public Uc_Treatment()
        {
            InitializeComponent();
            LoadStatus();
            LoadTreatments();
        }

        private void datadisplay()
        {
            try
            {
                string sql = "SELECT*FROM treatments";

                using (SqlConnection con = new SqlConnection(connectionstring))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(sql, con))
                    {
                        DataTable dt = new DataTable();

                        da.Fill(dt);

                        dtvTreatments.DataSource = dt;
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
        private void LoadStatus()
        {
            cmbStatus.Items.Clear();

            cmbStatus.Items.Add("Available");
            cmbStatus.Items.Add("Unavailable");

            cmbStatus.SelectedIndex = 0;
        }

        private void LoadTreatments()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionstring))
                {
                    string query = @"
                SELECT
                    TreatmentId,
                    TreatmentName,
                    Description,
                    Price,
                    Status
                FROM Treatments
                ORDER BY TreatmentId DESC";

                    using (SqlDataAdapter da = new SqlDataAdapter(query, con))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        dtvTreatments.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error loading treatments:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void Uc_Treatment_Load(object sender, EventArgs e)
        {
            datadisplay();
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
       
            if (treatmentId == 0)
            {
                MessageBox.Show("Please select a treatment first.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTreatmentName.Text))
            {
                MessageBox.Show("Please enter treatment name.");
                return;
            }

            if (!decimal.TryParse(txtPrice.Text, out decimal price))
            {
                MessageBox.Show("Please enter a valid price.");
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
                UPDATE Treatments
                SET
                    TreatmentName = @TreatmentName,
                    Description = @Description,
                    Price = @Price,
                    Status = @Status
                WHERE TreatmentId = @TreatmentId";

                    using (SqlCommand cmd =
                        new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue(
                            "@TreatmentName",
                            txtTreatmentName.Text.Trim());

                        cmd.Parameters.AddWithValue(
                            "@Description",
                            txtDescription.Text.Trim());

                        cmd.Parameters.AddWithValue(
                            "@Price",
                            price);

                        cmd.Parameters.AddWithValue(
                            "@Status",
                            cmbStatus.Text);

                        cmd.Parameters.AddWithValue(
                            "@TreatmentId",
                            treatmentId);

                        con.Open();

                        int rows = cmd.ExecuteNonQuery();

                        if (rows > 0)
                        {
                            MessageBox.Show(
                                "Treatment updated successfully.",
                                "Success",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                        }
                    }
                }

                LoadTreatments();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error updating treatment:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        

        private void gunaButton2_Click(object sender, EventArgs e)
        {
        
            if (treatmentId == 0)
            {
                MessageBox.Show("Please select a treatment first.");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this treatment?",
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
                        "DELETE FROM Treatments WHERE TreatmentId = @TreatmentId";

                    using (SqlCommand cmd =
                        new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue(
                            "@TreatmentId",
                            treatmentId);

                        con.Open();

                        int rows = cmd.ExecuteNonQuery();

                        if (rows > 0)
                        {
                            MessageBox.Show(
                                "Treatment deleted successfully.",
                                "Success",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                        }
                    }
                }

                LoadTreatments();
                ClearFields();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    "This treatment cannot be deleted because it is connected to another record.\n\n"
                    + ex.Message,
                    "Delete Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error deleting treatment:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        

        private void gunaButton3_Click(object sender, EventArgs e)
        {
        
            ClearFields();
        }

        private void ClearFields()
        {
            txtTreatmentName.Clear();
            txtDescription.Clear();
            txtPrice.Clear();

            cmbStatus.SelectedIndex = 0;

            treatmentId = 0;

            dtvTreatments.ClearSelection();
        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtTreatmentName_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
          
            if (string.IsNullOrWhiteSpace(txtTreatmentName.Text))
            {
                MessageBox.Show("Please enter treatment name.");
                return;
            }

            if (!decimal.TryParse(txtPrice.Text, out decimal price))
            {
                MessageBox.Show("Please enter a valid price.");
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
                INSERT INTO Treatments
                (
                    TreatmentName,
                    Description,
                    Price,
                    Status
                )
                VALUES
                (
                    @TreatmentName,
                    @Description,
                    @Price,
                    @Status
                )";

                    using (SqlCommand cmd =
                        new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue(
                            "@TreatmentName",
                            txtTreatmentName.Text.Trim());

                        cmd.Parameters.AddWithValue(
                            "@Description",
                            txtDescription.Text.Trim());

                        cmd.Parameters.AddWithValue(
                            "@Price",
                            price);

                        cmd.Parameters.AddWithValue(
                            "@Status",
                            cmbStatus.Text);

                        con.Open();

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show(
                    "Treatment saved successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LoadTreatments();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error saving treatment:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        

        private void dtvTreatments_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row = dtvTreatments.Rows[e.RowIndex];

            treatmentId = Convert.ToInt32(
                row.Cells["TreatmentId"].Value);

            txtTreatmentName.Text =
                row.Cells["TreatmentName"].Value.ToString();

            txtDescription.Text =
                row.Cells["Description"].Value.ToString();

            txtPrice.Text =
                row.Cells["Price"].Value.ToString();

            cmbStatus.Text =
                row.Cells["Status"].Value.ToString();
        }

        private void txtsearching_TextChanged(object sender, EventArgs e)
        {
         
            try
            {
                using (SqlConnection con = new SqlConnection(connectionstring))
                {
                    string query = @"
                SELECT
                    TreatmentId,
                    TreatmentName,
                    Description,
                    Price,
                    Status
                FROM Treatments
                WHERE TreatmentName LIKE @Search
                   OR Description LIKE @Search
                   OR Status LIKE @Search
                ORDER BY TreatmentId DESC";

                    using (SqlDataAdapter da = new SqlDataAdapter(query, con))
                    {
                        da.SelectCommand.Parameters.AddWithValue(
                            "@Search",
                            "%" + txtsearching.Text.Trim() + "%"
                        );

                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        dtvTreatments.DataSource = dt;
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
    

