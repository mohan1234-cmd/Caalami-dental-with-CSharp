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
    public partial class PatientFormReport : Form

    {
        private string connectionstring = @"Data Source=DESKTOP-PB208MO;Initial Catalog=CaalamiDentalClinic;Integrated Security=True";

        public PatientFormReport()
        {
            InitializeComponent();
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
      
            try
            {
                string name = txtSearchName.Text.Trim();
                string id = txtSearchId.Text.Trim();

             
                if (string.IsNullOrEmpty(name) &&
                    string.IsNullOrEmpty(id) &&
                    !dtpSearchDate.Checked)
                {
                    MessageBox.Show(
                        "Fadlan so geli Patient Name, Patient ID ama dooro Date.",
                        "Search",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }

                string query = @"
            SELECT *
            FROM Patients
            WHERE
               (@Name = '' OR PatientName = @Name)
                AND
                (@ID = '' OR CAST(PatientId AS NVARCHAR(50)) = @ID)
                AND
                (@UseDate = 0 OR CAST(DateOfBirth AS DATE) = @Date)
            ORDER BY PatientId DESC";

                DataTable dt = new DataTable();

                using (SqlConnection con = new SqlConnection(connectionstring))
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@ID", id);

                    cmd.Parameters.AddWithValue(
                        "@UseDate",
                        dtpSearchDate.Checked ? 1 : 0
                    );

                    cmd.Parameters.AddWithValue(
                        "@Date",
                        dtpSearchDate.Value.Date
                    );

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }

              
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show(
                        "Patient kani maba jiro muuse.",
                        "Search Result",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    crystalReportViewer1.ReportSource = null;
                    return;
                }

             
                ReportPatient report = new ReportPatient();

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
        

        private void PatientFormReport_Load(object sender, EventArgs e)
        {
           
        }
    }
    }

