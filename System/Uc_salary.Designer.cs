namespace System
{
    partial class Uc_salary
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Uc_salary));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbDentists = new System.Windows.Forms.ComboBox();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.txtSalaryAmount = new System.Windows.Forms.TextBox();
            this.txtBonus = new System.Windows.Forms.TextBox();
            this.txtNetSalary = new System.Windows.Forms.TextBox();
            this.cmbPaymentMethod = new System.Windows.Forms.ComboBox();
            this.dtpSalaryDate = new System.Windows.Forms.DateTimePicker();
            this.dgvSalary = new System.Windows.Forms.DataGridView();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtClear = new Guna.UI.WinForms.GunaButton();
            this.txtDelete = new Guna.UI.WinForms.GunaButton();
            this.txtUpdate = new Guna.UI.WinForms.GunaButton();
            this.btnSave = new Guna.UI.WinForms.GunaButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtSearching = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Adobe Fan Heiti Std B", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(64, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 30);
            this.label1.TabIndex = 1;
            this.label1.Text = "Dentists";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Adobe Fan Heiti Std B", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(64, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 30);
            this.label2.TabIndex = 2;
            this.label2.Text = "Full Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Adobe Fan Heiti Std B", 12F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(378, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(173, 30);
            this.label3.TabIndex = 3;
            this.label3.Text = "Salary Amount";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Adobe Fan Heiti Std B", 12F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(378, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 30);
            this.label4.TabIndex = 4;
            this.label4.Text = "Bonus";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Adobe Fan Heiti Std B", 12F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(378, 211);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 30);
            this.label5.TabIndex = 5;
            this.label5.Text = "Net salaray";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Adobe Fan Heiti Std B", 12F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(64, 212);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(201, 30);
            this.label6.TabIndex = 6;
            this.label6.Text = "Payment Method";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Adobe Fan Heiti Std B", 12F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(64, 286);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(136, 30);
            this.label7.TabIndex = 7;
            this.label7.Text = "Salary Date";
            // 
            // cmbDentists
            // 
            this.cmbDentists.FormattingEnabled = true;
            this.cmbDentists.Location = new System.Drawing.Point(69, 112);
            this.cmbDentists.Name = "cmbDentists";
            this.cmbDentists.Size = new System.Drawing.Size(284, 28);
            this.cmbDentists.TabIndex = 8;
            this.cmbDentists.SelectedIndexChanged += new System.EventHandler(this.cmbDentists_SelectedIndexChanged);
            // 
            // txtFullName
            // 
            this.txtFullName.BackColor = System.Drawing.Color.White;
            this.txtFullName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFullName.Font = new System.Drawing.Font("Franklin Gothic Demi", 10F);
            this.txtFullName.Location = new System.Drawing.Point(69, 176);
            this.txtFullName.Multiline = true;
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(284, 33);
            this.txtFullName.TabIndex = 9;
            this.txtFullName.TextChanged += new System.EventHandler(this.txtFullName_TextChanged);
            // 
            // txtSalaryAmount
            // 
            this.txtSalaryAmount.BackColor = System.Drawing.Color.White;
            this.txtSalaryAmount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSalaryAmount.Font = new System.Drawing.Font("Franklin Gothic Demi", 10F);
            this.txtSalaryAmount.Location = new System.Drawing.Point(383, 112);
            this.txtSalaryAmount.Multiline = true;
            this.txtSalaryAmount.Name = "txtSalaryAmount";
            this.txtSalaryAmount.Size = new System.Drawing.Size(205, 33);
            this.txtSalaryAmount.TabIndex = 10;
            this.txtSalaryAmount.TextChanged += new System.EventHandler(this.txtSalaryAmount_TextChanged);
            // 
            // txtBonus
            // 
            this.txtBonus.BackColor = System.Drawing.Color.White;
            this.txtBonus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBonus.Font = new System.Drawing.Font("Franklin Gothic Demi", 10F);
            this.txtBonus.Location = new System.Drawing.Point(383, 175);
            this.txtBonus.Multiline = true;
            this.txtBonus.Name = "txtBonus";
            this.txtBonus.Size = new System.Drawing.Size(205, 33);
            this.txtBonus.TabIndex = 11;
            this.txtBonus.TextChanged += new System.EventHandler(this.txtBonus_TextChanged);
            // 
            // txtNetSalary
            // 
            this.txtNetSalary.BackColor = System.Drawing.Color.White;
            this.txtNetSalary.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNetSalary.Font = new System.Drawing.Font("Franklin Gothic Demi", 10F);
            this.txtNetSalary.Location = new System.Drawing.Point(383, 240);
            this.txtNetSalary.Multiline = true;
            this.txtNetSalary.Name = "txtNetSalary";
            this.txtNetSalary.Size = new System.Drawing.Size(205, 33);
            this.txtNetSalary.TabIndex = 12;
            // 
            // cmbPaymentMethod
            // 
            this.cmbPaymentMethod.FormattingEnabled = true;
            this.cmbPaymentMethod.Location = new System.Drawing.Point(69, 244);
            this.cmbPaymentMethod.Name = "cmbPaymentMethod";
            this.cmbPaymentMethod.Size = new System.Drawing.Size(284, 28);
            this.cmbPaymentMethod.TabIndex = 13;
            // 
            // dtpSalaryDate
            // 
            this.dtpSalaryDate.Location = new System.Drawing.Point(69, 319);
            this.dtpSalaryDate.Name = "dtpSalaryDate";
            this.dtpSalaryDate.Size = new System.Drawing.Size(351, 26);
            this.dtpSalaryDate.TabIndex = 14;
            // 
            // dgvSalary
            // 
            this.dgvSalary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSalary.Location = new System.Drawing.Point(69, 361);
            this.dgvSalary.Name = "dgvSalary";
            this.dgvSalary.RowHeadersWidth = 62;
            this.dgvSalary.RowTemplate.Height = 28;
            this.dgvSalary.Size = new System.Drawing.Size(830, 177);
            this.dgvSalary.TabIndex = 15;
            this.dgvSalary.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSalary_CellContentClick);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Adobe Fan Heiti Std B", 9F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(29, 18);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(115, 23);
            this.label8.TabIndex = 20;
            this.label8.Text = "Salary_Form";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Adobe Fan Heiti Std B", 15F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(627, 13);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(304, 38);
            this.label9.TabIndex = 21;
            this.label9.Text = "Caalami Dental Clinic";
            // 
            // txtClear
            // 
            this.txtClear.AnimationHoverSpeed = 0.07F;
            this.txtClear.AnimationSpeed = 0.03F;
            this.txtClear.BackColor = System.Drawing.Color.Transparent;
            this.txtClear.BaseColor = System.Drawing.Color.Red;
            this.txtClear.BorderColor = System.Drawing.Color.Black;
            this.txtClear.DialogResult = System.Windows.Forms.DialogResult.None;
            this.txtClear.FocusedColor = System.Drawing.Color.Empty;
            this.txtClear.Font = new System.Drawing.Font("Adobe Fan Heiti Std B", 9F, System.Drawing.FontStyle.Bold);
            this.txtClear.ForeColor = System.Drawing.Color.White;
            this.txtClear.Image = ((System.Drawing.Image)(resources.GetObject("txtClear.Image")));
            this.txtClear.ImageSize = new System.Drawing.Size(30, 30);
            this.txtClear.Location = new System.Drawing.Point(717, 566);
            this.txtClear.Name = "txtClear";
            this.txtClear.OnHoverBaseColor = System.Drawing.Color.Black;
            this.txtClear.OnHoverBorderColor = System.Drawing.Color.Black;
            this.txtClear.OnHoverForeColor = System.Drawing.Color.White;
            this.txtClear.OnHoverImage = null;
            this.txtClear.OnPressedColor = System.Drawing.Color.Black;
            this.txtClear.Radius = 10;
            this.txtClear.Size = new System.Drawing.Size(169, 54);
            this.txtClear.TabIndex = 19;
            this.txtClear.Text = "Clear";
            this.txtClear.Click += new System.EventHandler(this.txtClear_Click);
            // 
            // txtDelete
            // 
            this.txtDelete.AnimationHoverSpeed = 0.07F;
            this.txtDelete.AnimationSpeed = 0.03F;
            this.txtDelete.BackColor = System.Drawing.Color.Transparent;
            this.txtDelete.BaseColor = System.Drawing.Color.Orange;
            this.txtDelete.BorderColor = System.Drawing.Color.Black;
            this.txtDelete.DialogResult = System.Windows.Forms.DialogResult.None;
            this.txtDelete.FocusedColor = System.Drawing.Color.Empty;
            this.txtDelete.Font = new System.Drawing.Font("Adobe Fan Heiti Std B", 9F, System.Drawing.FontStyle.Bold);
            this.txtDelete.ForeColor = System.Drawing.Color.White;
            this.txtDelete.Image = ((System.Drawing.Image)(resources.GetObject("txtDelete.Image")));
            this.txtDelete.ImageSize = new System.Drawing.Size(30, 30);
            this.txtDelete.Location = new System.Drawing.Point(496, 566);
            this.txtDelete.Name = "txtDelete";
            this.txtDelete.OnHoverBaseColor = System.Drawing.Color.Black;
            this.txtDelete.OnHoverBorderColor = System.Drawing.Color.Black;
            this.txtDelete.OnHoverForeColor = System.Drawing.Color.White;
            this.txtDelete.OnHoverImage = null;
            this.txtDelete.OnPressedColor = System.Drawing.Color.Black;
            this.txtDelete.Radius = 10;
            this.txtDelete.Size = new System.Drawing.Size(169, 54);
            this.txtDelete.TabIndex = 18;
            this.txtDelete.Text = "Delete";
            this.txtDelete.Click += new System.EventHandler(this.txtDelete_Click);
            // 
            // txtUpdate
            // 
            this.txtUpdate.AnimationHoverSpeed = 0.07F;
            this.txtUpdate.AnimationSpeed = 0.03F;
            this.txtUpdate.BackColor = System.Drawing.Color.Transparent;
            this.txtUpdate.BaseColor = System.Drawing.Color.Green;
            this.txtUpdate.BorderColor = System.Drawing.Color.Black;
            this.txtUpdate.DialogResult = System.Windows.Forms.DialogResult.None;
            this.txtUpdate.FocusedColor = System.Drawing.Color.Empty;
            this.txtUpdate.Font = new System.Drawing.Font("Adobe Fan Heiti Std B", 9F, System.Drawing.FontStyle.Bold);
            this.txtUpdate.ForeColor = System.Drawing.Color.White;
            this.txtUpdate.Image = ((System.Drawing.Image)(resources.GetObject("txtUpdate.Image")));
            this.txtUpdate.ImageSize = new System.Drawing.Size(30, 30);
            this.txtUpdate.Location = new System.Drawing.Point(278, 566);
            this.txtUpdate.Name = "txtUpdate";
            this.txtUpdate.OnHoverBaseColor = System.Drawing.Color.Black;
            this.txtUpdate.OnHoverBorderColor = System.Drawing.Color.Black;
            this.txtUpdate.OnHoverForeColor = System.Drawing.Color.White;
            this.txtUpdate.OnHoverImage = null;
            this.txtUpdate.OnPressedColor = System.Drawing.Color.Black;
            this.txtUpdate.Radius = 10;
            this.txtUpdate.Size = new System.Drawing.Size(169, 54);
            this.txtUpdate.TabIndex = 17;
            this.txtUpdate.Text = "Update";
            this.txtUpdate.Click += new System.EventHandler(this.txtUpdate_Click);
            // 
            // btnSave
            // 
            this.btnSave.AnimationHoverSpeed = 0.07F;
            this.btnSave.AnimationSpeed = 0.03F;
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.BaseColor = System.Drawing.Color.RoyalBlue;
            this.btnSave.BorderColor = System.Drawing.Color.Black;
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnSave.FocusedColor = System.Drawing.Color.Empty;
            this.btnSave.Font = new System.Drawing.Font("Adobe Fan Heiti Std B", 9F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageSize = new System.Drawing.Size(30, 30);
            this.btnSave.Location = new System.Drawing.Point(66, 566);
            this.btnSave.Name = "btnSave";
            this.btnSave.OnHoverBaseColor = System.Drawing.Color.Black;
            this.btnSave.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnSave.OnHoverForeColor = System.Drawing.Color.White;
            this.btnSave.OnHoverImage = null;
            this.btnSave.OnPressedColor = System.Drawing.Color.Black;
            this.btnSave.Radius = 10;
            this.btnSave.Size = new System.Drawing.Size(169, 54);
            this.btnSave.TabIndex = 16;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(621, 106);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(36, 34);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 23;
            this.pictureBox1.TabStop = false;
            // 
            // txtSearching
            // 
            this.txtSearching.Font = new System.Drawing.Font("Franklin Gothic Demi", 10F);
            this.txtSearching.Location = new System.Drawing.Point(621, 106);
            this.txtSearching.Multiline = true;
            this.txtSearching.Name = "txtSearching";
            this.txtSearching.Size = new System.Drawing.Size(278, 34);
            this.txtSearching.TabIndex = 22;
            this.txtSearching.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSearching.TextChanged += new System.EventHandler(this.txtSearching_TextChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.RoyalBlue;
            this.panel1.Location = new System.Drawing.Point(610, 96);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 55);
            this.panel1.TabIndex = 24;
            // 
            // Uc_salary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtSearching);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtClear);
            this.Controls.Add(this.txtDelete);
            this.Controls.Add(this.txtUpdate);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dgvSalary);
            this.Controls.Add(this.dtpSalaryDate);
            this.Controls.Add(this.cmbPaymentMethod);
            this.Controls.Add(this.txtNetSalary);
            this.Controls.Add(this.txtBonus);
            this.Controls.Add(this.txtSalaryAmount);
            this.Controls.Add(this.txtFullName);
            this.Controls.Add(this.cmbDentists);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Uc_salary";
            this.Size = new System.Drawing.Size(956, 680);
            this.Load += new System.EventHandler(this.Uc_salary_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Windows.Forms.Label label1;
        private Windows.Forms.Label label2;
        private Windows.Forms.Label label3;
        private Windows.Forms.Label label4;
        private Windows.Forms.Label label5;
        private Windows.Forms.Label label6;
        private Windows.Forms.Label label7;
        private Windows.Forms.ComboBox cmbDentists;
        private Windows.Forms.TextBox txtFullName;
        private Windows.Forms.TextBox txtSalaryAmount;
        private Windows.Forms.TextBox txtBonus;
        private Windows.Forms.TextBox txtNetSalary;
        private Windows.Forms.ComboBox cmbPaymentMethod;
        private Windows.Forms.DateTimePicker dtpSalaryDate;
        private Windows.Forms.DataGridView dgvSalary;
        private Guna.UI.WinForms.GunaButton btnSave;
        private Guna.UI.WinForms.GunaButton txtUpdate;
        private Guna.UI.WinForms.GunaButton txtDelete;
        private Guna.UI.WinForms.GunaButton txtClear;
        private Windows.Forms.Label label8;
        private Windows.Forms.Label label9;
        private Windows.Forms.PictureBox pictureBox1;
        private Windows.Forms.TextBox txtSearching;
        private Windows.Forms.Panel panel1;
    }
}
