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
    public partial class UC_Payment : UserControl

    {
        private string connectionstring = @"Data Source=DESKTOP-PB208MO;Initial Catalog=CaalamiDentalClinic;Integrated Security=True";

        private int paymentId = 0;
        private int appointmentId= 0;

        public UC_Payment()
        {
            
            InitializeComponent();
            LoadAppointments();
            LoadPaymentMethods();
            LoadPayments();
            cmbAppointments.SelectedIndex = -1;
            txtPatientName.Clear();

            dtpPaymentDate.Value = DateTime.Today;
        }

        private void ClearFields()
        {
            paymentId = 0;

            cmbAppointments.SelectedIndex = -1;

            txtPatientName.Clear();
            txtTotal.Clear();
            txtDiscount.Clear();
            txtSubtotal.Clear();

            cmbPaymentMethod.SelectedIndex = 0;

            dtpPaymentDate.Value =
                DateTime.Today;
        }
        private void LoadAppointments()
        {
            try
            {
                using (SqlConnection con =
                    new SqlConnection(connectionstring))
                {
                    string query = @"
                SELECT AppointmentId, PatientName
                FROM Appointments
                ORDER BY AppointmentId DESC";

                    using (SqlDataAdapter da =
                        new SqlDataAdapter(query, con))
                    {
                        DataTable dt = new DataTable();

                        da.Fill(dt);

                        cmbAppointments.DataSource = dt;
                        cmbAppointments.DisplayMember = "AppointmentId";
                        cmbAppointments.ValueMember = "AppointmentId";

                        cmbAppointments.SelectedIndex = -1;
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
            cmbPaymentMethod.Items.Add("Mobile Money");
            cmbPaymentMethod.Items.Add("Card");

            cmbPaymentMethod.SelectedIndex = 0;
        }
        private void cmbAppointment_SelectedIndexChanged(
    object sender,
    EventArgs e)
        {

        }
        
        
        
        private void CalculateSubtotal()
        {



            decimal total = 0;
            decimal discount = 0;

            decimal.TryParse(txtTotal.Text, out total);
            decimal.TryParse(txtDiscount.Text, out discount);

            decimal subtotal = total - discount;

            if (subtotal < 0)
                subtotal = 0;

            txtSubtotal.Text = subtotal.ToString("0.00");
        }

        
        private void txtDiscount_TextChanged(
    object sender,
    EventArgs e)
        {
            CalculateSubtotal();
        }

        private void LoadPayments()
        {
            try
            {
                using (SqlConnection con =
                    new SqlConnection(connectionstring))
                {
                    string query = @"
                SELECT *
                FROM Payments
                ORDER BY PaymentId DESC";

                    SqlDataAdapter da =
                        new SqlDataAdapter(query, con);

                    DataTable dt =
                        new DataTable();

                    da.Fill(dt);

                    dgvPayments.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
         
            decimal total;
            decimal discount;

            if (!decimal.TryParse(
                txtTotal.Text,
                out total))
            {
                MessageBox.Show(
                    "Enter valid total");
                return;
            }

            if (!decimal.TryParse(
                txtDiscount.Text,
                out discount))
            {
                MessageBox.Show(
                    "Enter valid discount");
                return;
            }

            decimal subtotal =
                total - discount;

            try
            {
                using (SqlConnection con =
                    new SqlConnection(connectionstring))
                {
                    string query = @"
                INSERT INTO Payments
                (
                    AppointmentId,
                    PatientName,
                    Total,
                    Discount,
                    Subtotal,
                    PaymentMethod,
                    PaymentDate
                )
                VALUES
                (
                    @AppointmentId,
                    @PatientName,
                    @Total,
                    @Discount,
                    @Subtotal,
                    @PaymentMethod,
                    @PaymentDate
                )";

                    SqlCommand cmd =
                        new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue(
                        "@AppointmentId",
                        cmbAppointments.SelectedValue);

                    cmd.Parameters.AddWithValue(
                        "@PatientName",
                        txtPatientName.Text);

                    cmd.Parameters.AddWithValue(
                        "@Total",
                        total);

                    cmd.Parameters.AddWithValue(
                        "@Discount",
                        discount);

                    cmd.Parameters.AddWithValue(
                        "@Subtotal",
                        subtotal);

                    cmd.Parameters.AddWithValue(
                        "@PaymentMethod",
                        cmbPaymentMethod.Text);

                    cmd.Parameters.AddWithValue(
                        "@PaymentDate",
                        dtpPaymentDate.Value.Date);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show(
                    "Payment saved successfully");

                LoadPayments();

                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvPayments_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex < 0)
                return;

            DataGridViewRow row = dgvPayments.Rows[e.RowIndex];

          
            paymentId = Convert.ToInt32(
                row.Cells["PaymentId"].Value
            );


            cmbAppointments.SelectedValue =
                row.Cells["AppointmentId"].Value;

            txtPatientName.Text =
                row.Cells["PatientName"].Value.ToString();

            txtTotal.Text =
                row.Cells["Total"].Value.ToString();

            txtDiscount.Text =
                row.Cells["Discount"].Value.ToString();

            txtSubtotal.Text =
                row.Cells["Subtotal"].Value.ToString();

            cmbPaymentMethod.Text =
                row.Cells["PaymentMethod"].Value.ToString();

            dtpPaymentDate.Value =
                Convert.ToDateTime(
                    row.Cells["PaymentDate"].Value
                );
        
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
          
            if (paymentId == 0)
            {
                MessageBox.Show(
                    "Select payment first");
                return;
            }

            decimal total =
                Convert.ToDecimal(
                    txtTotal.Text);

            decimal discount =
                Convert.ToDecimal(
                    txtDiscount.Text);

            decimal subtotal =
                total - discount;

            try
            {
                using (SqlConnection con =
                    new SqlConnection(connectionstring))
                {
                    string query = @"
                UPDATE Payments
                SET
                    AppointmentId=@AppointmentId,
                    PatientName=@PatientName,
                    Total=@Total,
                    Discount=@Discount,
                    Subtotal=@Subtotal,
                    PaymentMethod=@PaymentMethod,
                    PaymentDate=@PaymentDate
                WHERE PaymentId=@PaymentId";

                    SqlCommand cmd =
                        new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue(
                        "@AppointmentId",
                        cmbAppointments.SelectedValue);

                    cmd.Parameters.AddWithValue(
                        "@PatientName",
                        txtPatientName.Text);

                    cmd.Parameters.AddWithValue(
                        "@Total",
                        total);

                    cmd.Parameters.AddWithValue(
                        "@Discount",
                        discount);

                    cmd.Parameters.AddWithValue(
                        "@Subtotal",
                        subtotal);

                    cmd.Parameters.AddWithValue(
                        "@PaymentMethod",
                        cmbPaymentMethod.Text);

                    cmd.Parameters.AddWithValue(
                        "@PaymentDate",
                        dtpPaymentDate.Value.Date);

                    cmd.Parameters.AddWithValue(
                        "@PaymentId",
                        paymentId);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show(
                    "Payment updated");

                LoadPayments();

                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {


         
            if (dgvPayments.CurrentRow == null)
            {
                MessageBox.Show("Select payment first");
                return;
            }

            int selectedPaymentId = Convert.ToInt32(
                dgvPayments.CurrentRow.Cells["PaymentId"].Value
            );

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this payment?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.No)
                return;

            try
            {
                using (SqlConnection con = new SqlConnection(connectionstring))
                {
                    string query = "DELETE FROM Payments WHERE PaymentId=@PaymentId";

                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue(
                        "@PaymentId",
                        selectedPaymentId
                    );

                    con.Open();
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Payment deleted successfully");

                paymentId = 0;

                LoadPayments();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        

        private void btnClear_Click(object sender, EventArgs e)
        {
     
            ClearFields();
        }

        private void UC_Payment_Load(object sender, EventArgs e)
        {

        }

        private void cmbAppointments_SelectedIndexChanged(object sender, EventArgs e)
        {



       
            if (cmbAppointments.SelectedIndex == -1)
            {
                txtPatientName.Clear();
                return;
            }

            DataRowView row =
                cmbAppointments.SelectedItem as DataRowView;

            if (row != null)
            {
                txtPatientName.Text =
                    row["PatientName"].ToString();
            }
        }
        

        private void txtPatientName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtsearching_TextChanged(object sender, EventArgs e)
        {
          
            try
            {
                using (SqlConnection con =
                    new SqlConnection(connectionstring))
                {
                    string query = @"
                SELECT *
                FROM Payments
                WHERE PatientName LIKE @Search
                   OR PaymentId LIKE @Search
                ORDER BY PaymentId DESC";

                    SqlDataAdapter da =
                        new SqlDataAdapter(query, con);

                    da.SelectCommand.Parameters.AddWithValue(
                        "@Search",
                        "%" + txtsearching.Text.Trim() + "%");

                    DataTable dt = new DataTable();

                    da.Fill(dt);

                    dgvPayments.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtTotal_TextChanged(object sender, EventArgs e)
        {
            CalculateSubtotal();
        }

        private void txtSubtotal_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtDiscount_TextChanged_1(object sender, EventArgs e)
        {
            CalculateSubtotal();
        }
    }
    }
    
    
    
    
    
    
