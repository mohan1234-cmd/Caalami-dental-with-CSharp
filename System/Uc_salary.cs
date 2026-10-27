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
    public partial class Uc_salary : UserControl
    {
        private int salaryId = 0;
        private string connectionstring = @"Data Source=DESKTOP-PB208MO;Initial Catalog=CaalamiDentalClinic;Integrated Security=True";


        public Uc_salary()
        {
            InitializeComponent();
            LoadDentists();
            LoadPaymentMethods();
            LoadSalary();


            dtpSalaryDate.Value = DateTime.Today;
        }

        private void ClearFields()

        {

            salaryId = 0;

            cmbDentists.SelectedIndex = -1;

            txtFullName.Clear();

            txtSalaryAmount.Clear();

            txtBonus.Clear();

            txtNetSalary.Clear();

            cmbPaymentMethod.SelectedIndex = 0;

            dtpSalaryDate.Value = DateTime.Today;

        }
        private void CalculateNetSalary()
        {
            decimal salaryAmount = 0;
            decimal bonus = 0;

            decimal.TryParse(txtSalaryAmount.Text, out salaryAmount);
            decimal.TryParse(txtBonus.Text, out bonus);

            decimal netSalary = salaryAmount + bonus;

            txtNetSalary.Text = netSalary.ToString("0.00");
        }

        private void LoadDentists()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionstring))
                {
                    string query = @"
                SELECT DentistId, DentistName,SalaryAmount
                FROM Dentists
                ORDER BY DentistName";

                    using (SqlDataAdapter da = new SqlDataAdapter(query, con))
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
                MessageBox.Show(ex.Message);
            }
        }
        private void LoadSalary()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionstring))
                {
                    string query = @"
                SELECT
                    SalaryId,
                    DentistId,
                    FullName,
                    SalaryAmount,
                    Bonus,
                    NetSalary,
                    PaymentMethod,
                    SalaryDate
                FROM Salary
                ORDER BY SalaryId DESC";

                    using (SqlDataAdapter da = new SqlDataAdapter(query, con))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        dgvSalary.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void LoadPaymentMethods()
        {
            cmbPaymentMethod.Items.Clear();

            cmbPaymentMethod.Items.Add("Cash");
            cmbPaymentMethod.Items.Add("dollar");
            cmbPaymentMethod.Items.Add("gacan");

            cmbPaymentMethod.SelectedIndex = 0;
        }

        private void txtFullName_TextChanged(object sender, EventArgs e)
        {

        }

        private void Uc_salary_Load(object sender, EventArgs e)
        {

        }

        private void cmbDentists_SelectedIndexChanged(object sender, EventArgs e)
        {
        
            if (cmbDentists.SelectedIndex == -1)
            {
                txtFullName.Clear();
                txtSalaryAmount.Clear();
                txtNetSalary.Clear();
                return;
            }

            if (cmbDentists.SelectedItem is DataRowView row)
            {
                txtFullName.Text = row["DentistName"].ToString();
                txtSalaryAmount.Text = row["SalaryAmount"].ToString();
            }
        
        }

        private void txtSalaryAmount_TextChanged(object sender, EventArgs e)
        {

            CalculateNetSalary();
        }

        private void txtBonus_TextChanged(object sender, EventArgs e)
        {

            CalculateNetSalary();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (cmbDentists.SelectedIndex == -1)
            {
                MessageBox.Show("Please select dentist");
                return;
            }

            if (!decimal.TryParse(txtSalaryAmount.Text, out decimal salaryAmount))
            {
                MessageBox.Show("Enter valid salary amount");
                return;
            }

            if (!decimal.TryParse(txtBonus.Text, out decimal bonus))
            {
                bonus = 0;
            }

            decimal netSalary = salaryAmount + bonus;

            try
            {
                using (SqlConnection con = new SqlConnection(connectionstring))
                {
                    string query = @"
                INSERT INTO Salary
                (
                    DentistId,
                    FullName,
                    SalaryAmount,
                    Bonus,
                    NetSalary,
                    PaymentMethod,
                    SalaryDate
                )
                VALUES
                (
                    @DentistId,
                    @FullName,
                    @SalaryAmount,
                    @Bonus,
                    @NetSalary,
                    @PaymentMethod,
                    @SalaryDate
                )";

                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@DentistId", cmbDentists.SelectedValue);
                    cmd.Parameters.AddWithValue("@FullName", txtFullName.Text);
                    cmd.Parameters.AddWithValue("@SalaryAmount", salaryAmount);
                    cmd.Parameters.AddWithValue("@Bonus", bonus);
                    cmd.Parameters.AddWithValue("@NetSalary", netSalary);
                    cmd.Parameters.AddWithValue("@PaymentMethod", cmbPaymentMethod.Text);
                    cmd.Parameters.AddWithValue("@SalaryDate", dtpSalaryDate.Value.Date);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Salary saved successfully");

                LoadSalary();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtUpdate_Click(object sender, EventArgs e)
        {
            {

                if (salaryId == 0)

                {

                    MessageBox.Show("Select salary first");

                    return;

                }

                if (cmbDentists.SelectedIndex == -1)

                {

                    MessageBox.Show("Please select dentist");

                    return;

                }

                if (!decimal.TryParse(

                    txtSalaryAmount.Text,

                    out decimal salaryAmount))

                {

                    MessageBox.Show(

                        "Enter valid salary amount");

                    return;

                }

                if (!decimal.TryParse(

                    txtBonus.Text,

                    out decimal bonus))

                {

                    bonus = 0;

                }

                decimal netSalary =

                    salaryAmount + bonus;

                try

                {

                    using (SqlConnection con =

                        new SqlConnection(connectionstring))

                    {

                        string query = @"

                        UPDATE Salary

                        SET

                            DentistId = @DentistId,

                            FullName = @FullName,

                            SalaryAmount = @SalaryAmount,

                            Bonus = @Bonus,

                            NetSalary = @NetSalary,

                            PaymentMethod = @PaymentMethod,

                            SalaryDate = @SalaryDate

                        WHERE SalaryId = @SalaryId";

                        SqlCommand cmd =

                            new SqlCommand(query, con);

                        cmd.Parameters.AddWithValue(

                            "@SalaryId",

                            salaryId);

                        cmd.Parameters.AddWithValue(

                            "@DentistId",

                            cmbDentists.SelectedValue);

                        cmd.Parameters.AddWithValue(

                            "@FullName",

                            txtFullName.Text);

                        cmd.Parameters.AddWithValue(

                            "@SalaryAmount",

                            salaryAmount);

                        cmd.Parameters.AddWithValue(

                            "@Bonus",

                            bonus);

                        cmd.Parameters.AddWithValue(

                            "@NetSalary",

                            netSalary);

                        cmd.Parameters.AddWithValue(

                            "@PaymentMethod",

                            cmbPaymentMethod.Text);

                        cmd.Parameters.AddWithValue(

                            "@SalaryDate",

                            dtpSalaryDate.Value.Date);

                        con.Open();

                        cmd.ExecuteNonQuery();

                    }

                    MessageBox.Show(

                        "Salary updated successfully");

                    LoadSalary();

                    ClearFields();

                }

                catch (Exception ex)

                {

                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void txtDelete_Click(object sender, EventArgs e)
        {
            if (dgvSalary.CurrentRow == null)

            {

                MessageBox.Show("Select salary first");

                return;

            }

            int selectedSalaryId =

                Convert.ToInt32(

                    dgvSalary.CurrentRow

                    .Cells["SalaryId"].Value);

            DialogResult result =

                MessageBox.Show(

                    "Are you sure you want to delete this salary?",

                    "Confirm Delete",

                    MessageBoxButtons.YesNo,

                    MessageBoxIcon.Warning);

            if (result == DialogResult.No)

                return;

            try

            {

                using (SqlConnection con =

                    new SqlConnection(connectionstring))

                {

                    string query =

                        "DELETE FROM Salary WHERE SalaryId=@SalaryId";

                    SqlCommand cmd =

                        new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue(

                        "@SalaryId",

                        selectedSalaryId);

                    con.Open();

                    cmd.ExecuteNonQuery();

                }

                MessageBox.Show(

                    "Salary deleted successfully");

                salaryId = 0;

                LoadSalary();

                ClearFields();

            }

            catch (Exception ex)

            {

                MessageBox.Show(ex.Message);
            }
        }

        private void dgvSalary_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)

                return;

            DataGridViewRow row =

                dgvSalary.Rows[e.RowIndex];

            salaryId =

                Convert.ToInt32(

                    row.Cells["SalaryId"].Value);

            cmbDentists.SelectedValue =

                row.Cells["DentistId"].Value;

            txtFullName.Text =

                row.Cells["FullName"].Value.ToString();

            txtSalaryAmount.Text =

                row.Cells["SalaryAmount"].Value.ToString();

            txtBonus.Text =

                row.Cells["Bonus"].Value.ToString();

            txtNetSalary.Text =

                row.Cells["NetSalary"].Value.ToString();

            cmbPaymentMethod.Text =

                row.Cells["PaymentMethod"].Value.ToString();

            dtpSalaryDate.Value =

                Convert.ToDateTime(

                    row.Cells["SalaryDate"].Value);
        }

        private void txtClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void txtSearching_TextChanged(object sender, EventArgs e)
        {
         
            try
            {
                using (SqlConnection con =
                    new SqlConnection(connectionstring))
                {
                    string query = @"
                SELECT *
                FROM Salary
                WHERE FullName LIKE @Search
                   OR SalaryId LIKE @Search
                ORDER BY SalaryId DESC";

                    SqlDataAdapter da =
                        new SqlDataAdapter(query, con);

                    da.SelectCommand.Parameters.AddWithValue(
                        "@Search",
                        "%" + txtSearching.Text.Trim() + "%");

                    DataTable dt = new DataTable();

                    da.Fill(dt);

                    dgvSalary.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
    }

    
    

