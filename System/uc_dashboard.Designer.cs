namespace System
{
    partial class uc_dashboard
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.pnlPatients = new System.Windows.Forms.Panel();
            this.lblPatientsCount = new System.Windows.Forms.Label();
            this.lblPatientsTitle = new System.Windows.Forms.Label();
            this.pnlDentists = new System.Windows.Forms.Panel();
            this.lblDentistsCount = new System.Windows.Forms.Label();
            this.lblDentistsTitle = new System.Windows.Forms.Label();
            this.pnlAppointments = new System.Windows.Forms.Panel();
            this.lblAppointmentsCount = new System.Windows.Forms.Label();
            this.lblAppointmenTitle = new System.Windows.Forms.Label();
            this.pnlPayments = new System.Windows.Forms.Panel();
            this.lblPaymentsCount = new System.Windows.Forms.Label();
            this.lblPaymentsTitle = new System.Windows.Forms.Label();
            this.pnlExpenses = new System.Windows.Forms.Panel();
            this.lblExpensesCount = new System.Windows.Forms.Label();
            this.lblExpensesTitle = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.pnlPatients.SuspendLayout();
            this.pnlDentists.SuspendLayout();
            this.pnlAppointments.SuspendLayout();
            this.pnlPayments.SuspendLayout();
            this.pnlExpenses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Adobe Fan Heiti Std B", 19F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(228, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(504, 48);
            this.label1.TabIndex = 2;
            this.label1.Text = "Welcome To The Dashbaord";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // pnlPatients
            // 
            this.pnlPatients.BackColor = System.Drawing.Color.CornflowerBlue;
            this.pnlPatients.Controls.Add(this.lblPatientsCount);
            this.pnlPatients.Controls.Add(this.lblPatientsTitle);
            this.pnlPatients.Location = new System.Drawing.Point(78, 94);
            this.pnlPatients.Name = "pnlPatients";
            this.pnlPatients.Size = new System.Drawing.Size(230, 112);
            this.pnlPatients.TabIndex = 3;
            // 
            // lblPatientsCount
            // 
            this.lblPatientsCount.AutoSize = true;
            this.lblPatientsCount.Font = new System.Drawing.Font("Adobe Fan Heiti Std B", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPatientsCount.Location = new System.Drawing.Point(102, 67);
            this.lblPatientsCount.Name = "lblPatientsCount";
            this.lblPatientsCount.Size = new System.Drawing.Size(31, 35);
            this.lblPatientsCount.TabIndex = 1;
            this.lblPatientsCount.Text = "0";
            this.lblPatientsCount.Click += new System.EventHandler(this.lblPatientsCount_Click);
            // 
            // lblPatientsTitle
            // 
            this.lblPatientsTitle.AutoSize = true;
            this.lblPatientsTitle.Font = new System.Drawing.Font("Adobe Fan Heiti Std B", 12F, System.Drawing.FontStyle.Bold);
            this.lblPatientsTitle.Location = new System.Drawing.Point(48, 21);
            this.lblPatientsTitle.Name = "lblPatientsTitle";
            this.lblPatientsTitle.Size = new System.Drawing.Size(161, 30);
            this.lblPatientsTitle.TabIndex = 0;
            this.lblPatientsTitle.Text = "Total Patients";
            // 
            // pnlDentists
            // 
            this.pnlDentists.BackColor = System.Drawing.Color.Orange;
            this.pnlDentists.Controls.Add(this.lblDentistsCount);
            this.pnlDentists.Controls.Add(this.lblDentistsTitle);
            this.pnlDentists.Location = new System.Drawing.Point(372, 94);
            this.pnlDentists.Name = "pnlDentists";
            this.pnlDentists.Size = new System.Drawing.Size(230, 112);
            this.pnlDentists.TabIndex = 4;
            // 
            // lblDentistsCount
            // 
            this.lblDentistsCount.AutoSize = true;
            this.lblDentistsCount.Font = new System.Drawing.Font("Adobe Fan Heiti Std B", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDentistsCount.Location = new System.Drawing.Point(102, 63);
            this.lblDentistsCount.Name = "lblDentistsCount";
            this.lblDentistsCount.Size = new System.Drawing.Size(31, 35);
            this.lblDentistsCount.TabIndex = 1;
            this.lblDentistsCount.Text = "0";
            // 
            // lblDentistsTitle
            // 
            this.lblDentistsTitle.AutoSize = true;
            this.lblDentistsTitle.Font = new System.Drawing.Font("Adobe Fan Heiti Std B", 12F, System.Drawing.FontStyle.Bold);
            this.lblDentistsTitle.Location = new System.Drawing.Point(48, 21);
            this.lblDentistsTitle.Name = "lblDentistsTitle";
            this.lblDentistsTitle.Size = new System.Drawing.Size(161, 30);
            this.lblDentistsTitle.TabIndex = 0;
            this.lblDentistsTitle.Text = "Total Dentists";
            // 
            // pnlAppointments
            // 
            this.pnlAppointments.BackColor = System.Drawing.Color.Green;
            this.pnlAppointments.Controls.Add(this.lblAppointmentsCount);
            this.pnlAppointments.Controls.Add(this.lblAppointmenTitle);
            this.pnlAppointments.Location = new System.Drawing.Point(676, 95);
            this.pnlAppointments.Name = "pnlAppointments";
            this.pnlAppointments.Size = new System.Drawing.Size(230, 112);
            this.pnlAppointments.TabIndex = 5;
            // 
            // lblAppointmentsCount
            // 
            this.lblAppointmentsCount.AutoSize = true;
            this.lblAppointmentsCount.Font = new System.Drawing.Font("Adobe Fan Heiti Std B", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppointmentsCount.Location = new System.Drawing.Point(108, 64);
            this.lblAppointmentsCount.Name = "lblAppointmentsCount";
            this.lblAppointmentsCount.Size = new System.Drawing.Size(31, 35);
            this.lblAppointmentsCount.TabIndex = 1;
            this.lblAppointmentsCount.Text = "0";
            // 
            // lblAppointmenTitle
            // 
            this.lblAppointmenTitle.AutoSize = true;
            this.lblAppointmenTitle.Font = new System.Drawing.Font("Adobe Fan Heiti Std B", 12F, System.Drawing.FontStyle.Bold);
            this.lblAppointmenTitle.Location = new System.Drawing.Point(3, 20);
            this.lblAppointmenTitle.Name = "lblAppointmenTitle";
            this.lblAppointmenTitle.Size = new System.Drawing.Size(230, 30);
            this.lblAppointmenTitle.TabIndex = 0;
            this.lblAppointmenTitle.Text = "Total Appointments";
            // 
            // pnlPayments
            // 
            this.pnlPayments.BackColor = System.Drawing.Color.AliceBlue;
            this.pnlPayments.Controls.Add(this.lblPaymentsCount);
            this.pnlPayments.Controls.Add(this.lblPaymentsTitle);
            this.pnlPayments.Location = new System.Drawing.Point(78, 234);
            this.pnlPayments.Name = "pnlPayments";
            this.pnlPayments.Size = new System.Drawing.Size(230, 112);
            this.pnlPayments.TabIndex = 5;
            // 
            // lblPaymentsCount
            // 
            this.lblPaymentsCount.AutoSize = true;
            this.lblPaymentsCount.Font = new System.Drawing.Font("Adobe Fan Heiti Std B", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaymentsCount.Location = new System.Drawing.Point(97, 67);
            this.lblPaymentsCount.Name = "lblPaymentsCount";
            this.lblPaymentsCount.Size = new System.Drawing.Size(31, 35);
            this.lblPaymentsCount.TabIndex = 1;
            this.lblPaymentsCount.Text = "0";
            // 
            // lblPaymentsTitle
            // 
            this.lblPaymentsTitle.AutoSize = true;
            this.lblPaymentsTitle.Font = new System.Drawing.Font("Adobe Fan Heiti Std B", 12F, System.Drawing.FontStyle.Bold);
            this.lblPaymentsTitle.Location = new System.Drawing.Point(36, 21);
            this.lblPaymentsTitle.Name = "lblPaymentsTitle";
            this.lblPaymentsTitle.Size = new System.Drawing.Size(180, 30);
            this.lblPaymentsTitle.TabIndex = 0;
            this.lblPaymentsTitle.Text = "Total Payments";
            // 
            // pnlExpenses
            // 
            this.pnlExpenses.BackColor = System.Drawing.Color.Bisque;
            this.pnlExpenses.Controls.Add(this.lblExpensesCount);
            this.pnlExpenses.Controls.Add(this.lblExpensesTitle);
            this.pnlExpenses.Location = new System.Drawing.Point(372, 234);
            this.pnlExpenses.Name = "pnlExpenses";
            this.pnlExpenses.Size = new System.Drawing.Size(230, 112);
            this.pnlExpenses.TabIndex = 5;
            // 
            // lblExpensesCount
            // 
            this.lblExpensesCount.AutoSize = true;
            this.lblExpensesCount.Font = new System.Drawing.Font("Adobe Fan Heiti Std B", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExpensesCount.Location = new System.Drawing.Point(100, 67);
            this.lblExpensesCount.Name = "lblExpensesCount";
            this.lblExpensesCount.Size = new System.Drawing.Size(31, 35);
            this.lblExpensesCount.TabIndex = 1;
            this.lblExpensesCount.Text = "0";
            // 
            // lblExpensesTitle
            // 
            this.lblExpensesTitle.AutoSize = true;
            this.lblExpensesTitle.Font = new System.Drawing.Font("Adobe Fan Heiti Std B", 12F, System.Drawing.FontStyle.Bold);
            this.lblExpensesTitle.Location = new System.Drawing.Point(41, 21);
            this.lblExpensesTitle.Name = "lblExpensesTitle";
            this.lblExpensesTitle.Size = new System.Drawing.Size(173, 30);
            this.lblExpensesTitle.TabIndex = 0;
            this.lblExpensesTitle.Text = "Total Expenses";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Adobe Fan Heiti Std B", 13F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(356, 366);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(270, 33);
            this.label2.TabIndex = 6;
            this.label2.Text = "Today\'s Appointment";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(78, 402);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(828, 241);
            this.dataGridView1.TabIndex = 7;
            // 
            // uc_dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pnlExpenses);
            this.Controls.Add(this.pnlPayments);
            this.Controls.Add(this.pnlAppointments);
            this.Controls.Add(this.pnlDentists);
            this.Controls.Add(this.pnlPatients);
            this.Controls.Add(this.label1);
            this.Name = "uc_dashboard";
            this.Size = new System.Drawing.Size(966, 680);
            this.Load += new System.EventHandler(this.uc_dashboard_Load);
            this.pnlPatients.ResumeLayout(false);
            this.pnlPatients.PerformLayout();
            this.pnlDentists.ResumeLayout(false);
            this.pnlDentists.PerformLayout();
            this.pnlAppointments.ResumeLayout(false);
            this.pnlAppointments.PerformLayout();
            this.pnlPayments.ResumeLayout(false);
            this.pnlPayments.PerformLayout();
            this.pnlExpenses.ResumeLayout(false);
            this.pnlExpenses.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Windows.Forms.Label label1;
        private Windows.Forms.Panel pnlPatients;
        private Windows.Forms.Label lblPatientsCount;
        private Windows.Forms.Label lblPatientsTitle;
        private Windows.Forms.Panel pnlDentists;
        private Windows.Forms.Label lblDentistsCount;
        private Windows.Forms.Label lblDentistsTitle;
        private Windows.Forms.Panel pnlAppointments;
        private Windows.Forms.Label lblAppointmentsCount;
        private Windows.Forms.Label lblAppointmenTitle;
        private Windows.Forms.Panel pnlPayments;
        private Windows.Forms.Label lblPaymentsCount;
        private Windows.Forms.Label lblPaymentsTitle;
        private Windows.Forms.Panel pnlExpenses;
        private Windows.Forms.Label lblExpensesCount;
        private Windows.Forms.Label lblExpensesTitle;
        private Windows.Forms.Label label2;
        private Windows.Forms.DataGridView dataGridView1;
    }
}
