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
    public partial class Uc_expense : UserControl
    {
        private int expenseId = 0;
        private string connectionstring = @"Data Source=DESKTOP-PB208MO;Initial Catalog=CaalamiDentalClinic;Integrated Security=True";


        public Uc_expense()
        {
            InitializeComponent();
            LoadPaymentMethods();
            LoadExpenses();
            dtpExpenseDate.Value = DateTime.Today;
        }

        private void LoadPaymentMethods()
        {
            cmbPaymentMethod.Items.Clear();

            cmbPaymentMethod.Items.Add("Cash");
            cmbPaymentMethod.Items.Add("dollar");
            cmbPaymentMethod.Items.Add("gacan");

            cmbPaymentMethod.SelectedIndex = 0;
        }
        private void LoadExpenses()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionstring))
                {
                    string query = @"
                SELECT
                    ExpenseId,
                    ExpenseName,
                    Amount,
                    Description,
                    ExpenseDate,
                    PaymentMethod
                FROM Expenses
                ORDER BY ExpenseId DESC";

                    using (SqlDataAdapter da =
                        new SqlDataAdapter(query, con))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        dgvExpenses.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Uc_expense_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtExpenseName.Text))
            {
                MessageBox.Show("Please enter expense name");
                return;
            }

            if (!decimal.TryParse(txtAmount.Text, out decimal amount))
            {
                MessageBox.Show("Enter valid amount");
                return;
            }

            if (amount < 0)
            {
                MessageBox.Show("Amount cannot be negative");
                return;
            }

            try
            {
                using (SqlConnection con =
                    new SqlConnection(connectionstring))
                {
                    string query = @"
                INSERT INTO Expenses
                (
                    ExpenseName,
                    Amount,
                    Description,
                    ExpenseDate,
                    PaymentMethod
                )
                VALUES
                (
                    @ExpenseName,
                    @Amount,
                    @Description,
                    @ExpenseDate,
                    @PaymentMethod
                )";

                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue(
                        "@ExpenseName", txtExpenseName.Text);

                    cmd.Parameters.AddWithValue(
                        "@Amount", amount);

                    cmd.Parameters.AddWithValue(
                        "@Description", txtDescription.Text);

                    cmd.Parameters.AddWithValue(
                        "@ExpenseDate", dtpExpenseDate.Value.Date);

                    cmd.Parameters.AddWithValue(
                        "@PaymentMethod", cmbPaymentMethod.Text);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Expense saved successfully");

                LoadExpenses();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
         
            if (expenseId == 0)
            {
                MessageBox.Show("Select expense first");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtExpenseName.Text))
            {
                MessageBox.Show("Please enter expense name");
                return;
            }

            if (!decimal.TryParse(txtAmount.Text, out decimal amount))
            {
                MessageBox.Show("Enter valid amount");
                return;
            }

            if (amount < 0)
            {
                MessageBox.Show("Amount cannot be negative");
                return;
            }

            try
            {
                using (SqlConnection con =
                    new SqlConnection(connectionstring))
                {
                    string query = @"
                UPDATE Expenses
                SET
                    ExpenseName = @ExpenseName,
                    Amount = @Amount,
                    Description = @Description,
                    ExpenseDate = @ExpenseDate,
                    PaymentMethod = @PaymentMethod
                WHERE ExpenseId = @ExpenseId";

                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue(
                        "@ExpenseId", expenseId);

                    cmd.Parameters.AddWithValue(
                        "@ExpenseName", txtExpenseName.Text);

                    cmd.Parameters.AddWithValue(
                        "@Amount", amount);

                    cmd.Parameters.AddWithValue(
                        "@Description", txtDescription.Text);

                    cmd.Parameters.AddWithValue(
                        "@ExpenseDate", dtpExpenseDate.Value.Date);

                    cmd.Parameters.AddWithValue(
                        "@PaymentMethod", cmbPaymentMethod.Text);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Expense updated successfully");

                LoadExpenses();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
        
            if (dgvExpenses.CurrentRow == null)
            {
                MessageBox.Show("Select expense first");
                return;
            }

            int selectedExpenseId =
                Convert.ToInt32(
                    dgvExpenses.CurrentRow.Cells["ExpenseId"].Value);

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this expense?",
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
                        "DELETE FROM Expenses WHERE ExpenseId=@ExpenseId";

                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue(
                        "@ExpenseId", selectedExpenseId);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Expense deleted successfully");

                expenseId = 0;

                LoadExpenses();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ClearFields()
        {
            expenseId = 0;

            txtExpenseName.Clear();
            txtAmount.Clear();
            txtDescription.Clear();

            cmbPaymentMethod.SelectedIndex = 0;

            dtpExpenseDate.Value = DateTime.Today;
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void dgvExpenses_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row =
                dgvExpenses.Rows[e.RowIndex];

            expenseId =
                Convert.ToInt32(
                    row.Cells["ExpenseId"].Value);

            txtExpenseName.Text =
                row.Cells["ExpenseName"].Value.ToString();

            txtAmount.Text =
                row.Cells["Amount"].Value.ToString();

            txtDescription.Text =
                row.Cells["Description"].Value.ToString();

            dtpExpenseDate.Value =
                Convert.ToDateTime(
                    row.Cells["ExpenseDate"].Value);

            cmbPaymentMethod.Text =
                row.Cells["PaymentMethod"].Value.ToString();
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
                FROM Expenses
                WHERE ExpenseName LIKE @Search
                   OR ExpenseId LIKE @Search
                ORDER BY ExpenseId DESC";

                    SqlDataAdapter da =
                        new SqlDataAdapter(query, con);

                    da.SelectCommand.Parameters.AddWithValue(
                        "@Search",
                        "%" + txtSearching.Text.Trim() + "%");

                    DataTable dt = new DataTable();

                    da.Fill(dt);

                    dgvExpenses.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
    
    }
   
    
    

