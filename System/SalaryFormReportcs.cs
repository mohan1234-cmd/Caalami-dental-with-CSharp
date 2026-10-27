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
    public partial class SalaryFormReportcs : Form
    {
        private string connectionstring = @"Data Source=DESKTOP-PB208MO;Initial Catalog=CaalamiDentalClinic;Integrated Security=True";

        public SalaryFormReportcs()
        {
            InitializeComponent();
            LoadDentists();
            LoadPaymentMethods();   
            dtpSalaryDate.Checked = false;
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

                cmbDentists.DataSource = dt;
                cmbDentists.DisplayMember = "DentistName";
                cmbDentists.ValueMember = "DentistId";

                cmbDentists.SelectedIndex = -1;
            }
        }
        private void LoadPaymentMethods()
        {
            cmbPaymentMethod.Items.Clear();

            cmbPaymentMethod.Items.Add("Cash");
            cmbPaymentMethod.Items.Add("dollar");
            cmbPaymentMethod.Items.Add("gacan");

            cmbPaymentMethod.SelectedIndex = -1;
        }
        private void SalaryFormReportcs_Load(object sender, EventArgs e)
        {

        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
         
            try
            {
                if (cmbDentists.SelectedIndex == -1 &&
                    cmbPaymentMethod.SelectedIndex == -1 &&
                    !dtpSalaryDate.Checked)
                {
                    MessageBox.Show(
                        "Fadlan dooro Dentist, Payment Method ama Date.",
                        "Search",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }

                string query = @"
            SELECT *
            FROM Salary
            WHERE
                (@DentistId = 0 OR DentistId = @DentistId)
                AND
                (@PaymentMethod = '' OR PaymentMethod = @PaymentMethod)
                AND
                (@UseDate = 0 OR CAST(SalaryDate AS DATE) = @SalaryDate)
            ORDER BY SalaryId DESC";

                DataTable dt = new DataTable();

                using (SqlConnection con = new SqlConnection(connectionstring))
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    int dentistId = 0;

                    if (cmbDentists.SelectedIndex != -1)
                    {
                        dentistId = Convert.ToInt32(cmbDentists.SelectedValue);
                    }

                    string paymentMethod = "";

                    if (cmbPaymentMethod.SelectedIndex != -1)
                    {
                        paymentMethod = cmbPaymentMethod.Text;
                    }

                    cmd.Parameters.AddWithValue("@DentistId", dentistId);
                    cmd.Parameters.AddWithValue("@PaymentMethod", paymentMethod);

                    cmd.Parameters.AddWithValue(
                        "@UseDate",
                        dtpSalaryDate.Checked ? 1 : 0
                    );

                    cmd.Parameters.AddWithValue(
                        "@SalaryDate",
                        dtpSalaryDate.Value.Date
                    );

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show(
                        "Salary lama helin.",
                        "Search Result",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    crystalReportViewer1.ReportSource = null;
                    return;
                }

                ReportSalary2 report = new ReportSalary2();

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

