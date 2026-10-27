namespace System
{
    partial class reportForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(reportForm));
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.r_expense = new Guna.UI.WinForms.GunaButton();
            this.r_payment = new Guna.UI.WinForms.GunaButton();
            this.r_treatment = new Guna.UI.WinForms.GunaButton();
            this.r_salary = new Guna.UI.WinForms.GunaButton();
            this.r_appointment = new Guna.UI.WinForms.GunaButton();
            this.r_patient = new Guna.UI.WinForms.GunaButton();
            this.r_dentists = new Guna.UI.WinForms.GunaButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.label1.Location = new System.Drawing.Point(544, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(320, 69);
            this.label1.TabIndex = 7;
            this.label1.Text = "REPORTS";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::System.Properties.Resources.f0fbd17474021f02239a1c4acb3e5e27;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(463, 592);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // r_expense
            // 
            this.r_expense.AnimationHoverSpeed = 0.07F;
            this.r_expense.AnimationSpeed = 0.03F;
            this.r_expense.BaseColor = System.Drawing.Color.MidnightBlue;
            this.r_expense.BorderColor = System.Drawing.Color.Black;
            this.r_expense.DialogResult = System.Windows.Forms.DialogResult.None;
            this.r_expense.FocusedColor = System.Drawing.Color.Empty;
            this.r_expense.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.r_expense.ForeColor = System.Drawing.Color.White;
            this.r_expense.Image = ((System.Drawing.Image)(resources.GetObject("r_expense.Image")));
            this.r_expense.ImageSize = new System.Drawing.Size(30, 30);
            this.r_expense.Location = new System.Drawing.Point(522, 291);
            this.r_expense.Name = "r_expense";
            this.r_expense.OnHoverBaseColor = System.Drawing.Color.Black;
            this.r_expense.OnHoverBorderColor = System.Drawing.Color.Black;
            this.r_expense.OnHoverForeColor = System.Drawing.Color.White;
            this.r_expense.OnHoverImage = null;
            this.r_expense.OnPressedColor = System.Drawing.Color.Black;
            this.r_expense.Size = new System.Drawing.Size(203, 54);
            this.r_expense.TabIndex = 6;
            this.r_expense.Text = "ExpenseReport";
            // 
            // r_payment
            // 
            this.r_payment.AnimationHoverSpeed = 0.07F;
            this.r_payment.AnimationSpeed = 0.03F;
            this.r_payment.BaseColor = System.Drawing.Color.MidnightBlue;
            this.r_payment.BorderColor = System.Drawing.Color.Black;
            this.r_payment.DialogResult = System.Windows.Forms.DialogResult.None;
            this.r_payment.FocusedColor = System.Drawing.Color.Empty;
            this.r_payment.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.r_payment.ForeColor = System.Drawing.Color.White;
            this.r_payment.Image = ((System.Drawing.Image)(resources.GetObject("r_payment.Image")));
            this.r_payment.ImageSize = new System.Drawing.Size(30, 30);
            this.r_payment.Location = new System.Drawing.Point(740, 291);
            this.r_payment.Name = "r_payment";
            this.r_payment.OnHoverBaseColor = System.Drawing.Color.Black;
            this.r_payment.OnHoverBorderColor = System.Drawing.Color.Black;
            this.r_payment.OnHoverForeColor = System.Drawing.Color.White;
            this.r_payment.OnHoverImage = null;
            this.r_payment.OnPressedColor = System.Drawing.Color.Black;
            this.r_payment.Size = new System.Drawing.Size(191, 54);
            this.r_payment.TabIndex = 5;
            this.r_payment.Text = "PaymentReport";
            // 
            // r_treatment
            // 
            this.r_treatment.AnimationHoverSpeed = 0.07F;
            this.r_treatment.AnimationSpeed = 0.03F;
            this.r_treatment.BaseColor = System.Drawing.Color.MidnightBlue;
            this.r_treatment.BorderColor = System.Drawing.Color.Black;
            this.r_treatment.DialogResult = System.Windows.Forms.DialogResult.None;
            this.r_treatment.FocusedColor = System.Drawing.Color.Empty;
            this.r_treatment.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.r_treatment.ForeColor = System.Drawing.Color.White;
            this.r_treatment.Image = ((System.Drawing.Image)(resources.GetObject("r_treatment.Image")));
            this.r_treatment.ImageSize = new System.Drawing.Size(30, 30);
            this.r_treatment.Location = new System.Drawing.Point(728, 161);
            this.r_treatment.Name = "r_treatment";
            this.r_treatment.OnHoverBaseColor = System.Drawing.Color.Black;
            this.r_treatment.OnHoverBorderColor = System.Drawing.Color.Black;
            this.r_treatment.OnHoverForeColor = System.Drawing.Color.White;
            this.r_treatment.OnHoverImage = null;
            this.r_treatment.OnPressedColor = System.Drawing.Color.Black;
            this.r_treatment.Size = new System.Drawing.Size(203, 54);
            this.r_treatment.TabIndex = 4;
            this.r_treatment.Text = "TreatmentReport";
            // 
            // r_salary
            // 
            this.r_salary.AnimationHoverSpeed = 0.07F;
            this.r_salary.AnimationSpeed = 0.03F;
            this.r_salary.BaseColor = System.Drawing.Color.MidnightBlue;
            this.r_salary.BorderColor = System.Drawing.Color.Black;
            this.r_salary.DialogResult = System.Windows.Forms.DialogResult.None;
            this.r_salary.FocusedColor = System.Drawing.Color.Empty;
            this.r_salary.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.r_salary.ForeColor = System.Drawing.Color.White;
            this.r_salary.Image = ((System.Drawing.Image)(resources.GetObject("r_salary.Image")));
            this.r_salary.ImageSize = new System.Drawing.Size(30, 30);
            this.r_salary.Location = new System.Drawing.Point(522, 359);
            this.r_salary.Name = "r_salary";
            this.r_salary.OnHoverBaseColor = System.Drawing.Color.Black;
            this.r_salary.OnHoverBorderColor = System.Drawing.Color.Black;
            this.r_salary.OnHoverForeColor = System.Drawing.Color.White;
            this.r_salary.OnHoverImage = null;
            this.r_salary.OnPressedColor = System.Drawing.Color.Black;
            this.r_salary.Size = new System.Drawing.Size(177, 54);
            this.r_salary.TabIndex = 3;
            this.r_salary.Text = "SalaryReport";
            // 
            // r_appointment
            // 
            this.r_appointment.AnimationHoverSpeed = 0.07F;
            this.r_appointment.AnimationSpeed = 0.03F;
            this.r_appointment.BaseColor = System.Drawing.Color.MidnightBlue;
            this.r_appointment.BorderColor = System.Drawing.Color.Black;
            this.r_appointment.DialogResult = System.Windows.Forms.DialogResult.None;
            this.r_appointment.FocusedColor = System.Drawing.Color.Empty;
            this.r_appointment.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.r_appointment.ForeColor = System.Drawing.Color.White;
            this.r_appointment.Image = ((System.Drawing.Image)(resources.GetObject("r_appointment.Image")));
            this.r_appointment.ImageSize = new System.Drawing.Size(30, 30);
            this.r_appointment.Location = new System.Drawing.Point(728, 225);
            this.r_appointment.Name = "r_appointment";
            this.r_appointment.OnHoverBaseColor = System.Drawing.Color.Black;
            this.r_appointment.OnHoverBorderColor = System.Drawing.Color.Black;
            this.r_appointment.OnHoverForeColor = System.Drawing.Color.White;
            this.r_appointment.OnHoverImage = null;
            this.r_appointment.OnPressedColor = System.Drawing.Color.Black;
            this.r_appointment.Size = new System.Drawing.Size(226, 54);
            this.r_appointment.TabIndex = 2;
            this.r_appointment.Text = "AppointmentReport";
            // 
            // r_patient
            // 
            this.r_patient.AnimationHoverSpeed = 0.07F;
            this.r_patient.AnimationSpeed = 0.03F;
            this.r_patient.BaseColor = System.Drawing.Color.MidnightBlue;
            this.r_patient.BorderColor = System.Drawing.Color.Black;
            this.r_patient.DialogResult = System.Windows.Forms.DialogResult.None;
            this.r_patient.FocusedColor = System.Drawing.Color.Empty;
            this.r_patient.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.r_patient.ForeColor = System.Drawing.Color.White;
            this.r_patient.Image = ((System.Drawing.Image)(resources.GetObject("r_patient.Image")));
            this.r_patient.ImageSize = new System.Drawing.Size(30, 30);
            this.r_patient.Location = new System.Drawing.Point(522, 161);
            this.r_patient.Name = "r_patient";
            this.r_patient.OnHoverBaseColor = System.Drawing.Color.Black;
            this.r_patient.OnHoverBorderColor = System.Drawing.Color.Black;
            this.r_patient.OnHoverForeColor = System.Drawing.Color.White;
            this.r_patient.OnHoverImage = null;
            this.r_patient.OnPressedColor = System.Drawing.Color.Black;
            this.r_patient.Size = new System.Drawing.Size(177, 54);
            this.r_patient.TabIndex = 1;
            this.r_patient.Text = "PatientReport";
            // 
            // r_dentists
            // 
            this.r_dentists.AnimationHoverSpeed = 0.07F;
            this.r_dentists.AnimationSpeed = 0.03F;
            this.r_dentists.BaseColor = System.Drawing.Color.MidnightBlue;
            this.r_dentists.BorderColor = System.Drawing.Color.Black;
            this.r_dentists.DialogResult = System.Windows.Forms.DialogResult.None;
            this.r_dentists.FocusedColor = System.Drawing.Color.Empty;
            this.r_dentists.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.r_dentists.ForeColor = System.Drawing.Color.White;
            this.r_dentists.Image = ((System.Drawing.Image)(resources.GetObject("r_dentists.Image")));
            this.r_dentists.ImageSize = new System.Drawing.Size(30, 30);
            this.r_dentists.Location = new System.Drawing.Point(522, 225);
            this.r_dentists.Name = "r_dentists";
            this.r_dentists.OnHoverBaseColor = System.Drawing.Color.Black;
            this.r_dentists.OnHoverBorderColor = System.Drawing.Color.Black;
            this.r_dentists.OnHoverForeColor = System.Drawing.Color.White;
            this.r_dentists.OnHoverImage = null;
            this.r_dentists.OnPressedColor = System.Drawing.Color.Black;
            this.r_dentists.Size = new System.Drawing.Size(194, 54);
            this.r_dentists.TabIndex = 0;
            this.r_dentists.Text = "DentistsReport";
            // 
            // reportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(995, 592);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.r_expense);
            this.Controls.Add(this.r_payment);
            this.Controls.Add(this.r_treatment);
            this.Controls.Add(this.r_salary);
            this.Controls.Add(this.r_appointment);
            this.Controls.Add(this.r_patient);
            this.Controls.Add(this.r_dentists);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "reportForm";
            this.Text = "reportForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI.WinForms.GunaButton r_dentists;
        private Guna.UI.WinForms.GunaButton r_patient;
        private Guna.UI.WinForms.GunaButton r_appointment;
        private Guna.UI.WinForms.GunaButton r_salary;
        private Guna.UI.WinForms.GunaButton r_treatment;
        private Guna.UI.WinForms.GunaButton r_payment;
        private Guna.UI.WinForms.GunaButton r_expense;
        private Windows.Forms.Label label1;
        private Windows.Forms.PictureBox pictureBox1;
    }
}