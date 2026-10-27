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
    public partial class PaymentFormReport : Form
    {
        private string connectionstring = @"Data Source=DESKTOP-PB208MO;Initial Catalog=CaalamiDentalClinic;Integrated Security=True";

        public PaymentFormReport()
        {
            InitializeComponent();
            LoadPaymentMethods();
            LoadPatients();
            dtpPaymentDate.Checked = false;
            
        }

        private void PaymentFormReport_Load(object sender, EventArgs e)
        {

        }
        private void LoadPaymentMethods()
        {
            cmbPaymentMethod.Items.Clear();

            cmbPaymentMethod.Items.Add("Cash");
            cmbPaymentMethod.Items.Add("Mobile Money");
            cmbPaymentMethod.Items.Add("Card");

            cmbPaymentMethod.SelectedIndex = -1;
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
        private void gunaButton1_Click(object sender, EventArgs e)
        {
          
            try
            {
                string patientName = "";
                string paymentMethod = "";

         
                if (cmbPatients.SelectedIndex != -1)
                {
                    patientName = cmbPatients.Text.Trim();
                }

              
                if (cmbPaymentMethod.SelectedIndex != -1)
                {
                    paymentMethod = cmbPaymentMethod.Text.Trim();
                }

              
                if (string.IsNullOrEmpty(patientName) &&
                    string.IsNullOrEmpty(paymentMethod) &&
                    !dtpPaymentDate.Checked)
                {
                    MessageBox.Show(
                        "Fadlan dooro Patient, Payment Method ama Date.",
                        "Search",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }

                string query = @"
            SELECT *
            FROM Payments
            WHERE
                (@PatientName = '' OR PatientName = @PatientName)
                AND
                (@PaymentMethod = '' OR PaymentMethod = @PaymentMethod)
                AND
                (@UseDate = 0 OR CAST(PaymentDate AS DATE) = @PaymentDate)
            ORDER BY PaymentId DESC";

                DataTable dt = new DataTable();

                using (SqlConnection con = new SqlConnection(connectionstring))
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@PatientName", patientName);
                    cmd.Parameters.AddWithValue("@PaymentMethod", paymentMethod);
                    cmd.Parameters.AddWithValue(
                        "@UseDate",
                        dtpPaymentDate.Checked ? 1 : 0
                    );
                    cmd.Parameters.AddWithValue(
                        "@PaymentDate",
                        dtpPaymentDate.Value.Date
                    );

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }

                // Haddii Payment aan la helin
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show(
                        "Payment lama helin.",
                        "Search Result",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    crystalReportViewer1.ReportSource = null;
                    return;
                }

                // Crystal Report
                ReportPayment report = new ReportPayment();

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

