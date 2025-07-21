namespace Windows_Forms_Rental_Management.Rental
{
    partial class UpdateRental
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
            panel2 = new Panel();
            chkIsActive = new CheckBox();
            nudRentValue = new NumericUpDown();
            groupBox2 = new GroupBox();
            radioButton1 = new RadioButton();
            radioButton2 = new RadioButton();
            radioButton3 = new RadioButton();
            cbItemForRent = new ComboBox();
            label10 = new Label();
            label11 = new Label();
            cbTenant = new ComboBox();
            label12 = new Label();
            label13 = new Label();
            label14 = new Label();
            dtpEndDate = new DateTimePicker();
            cbRentPaymentFrequency = new ComboBox();
            dtpStartDate = new DateTimePicker();
            label15 = new Label();
            numericUpDown1 = new NumericUpDown();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudRentValue).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(chkIsActive);
            panel2.Controls.Add(nudRentValue);
            panel2.Controls.Add(groupBox2);
            panel2.Controls.Add(cbItemForRent);
            panel2.Controls.Add(label10);
            panel2.Controls.Add(label11);
            panel2.Controls.Add(cbTenant);
            panel2.Controls.Add(label12);
            panel2.Controls.Add(label13);
            panel2.Controls.Add(label14);
            panel2.Controls.Add(dtpEndDate);
            panel2.Controls.Add(cbRentPaymentFrequency);
            panel2.Controls.Add(dtpStartDate);
            panel2.Controls.Add(label15);
            panel2.Controls.Add(numericUpDown1);
            panel2.Location = new Point(39, 96);
            panel2.Name = "panel2";
            panel2.Size = new Size(921, 283);
            panel2.TabIndex = 48;
            // 
            // chkIsActive
            // 
            chkIsActive.AutoSize = true;
            chkIsActive.Location = new Point(31, 212);
            chkIsActive.Name = "chkIsActive";
            chkIsActive.Size = new Size(88, 32);
            chkIsActive.TabIndex = 48;
            chkIsActive.Text = "Active";
            chkIsActive.UseVisualStyleBackColor = true;
            // 
            // nudRentValue
            // 
            nudRentValue.DecimalPlaces = 2;
            nudRentValue.Location = new Point(750, 105);
            nudRentValue.Margin = new Padding(4);
            nudRentValue.Maximum = new decimal(new int[] { 99999999, 0, 0, 0 });
            nudRentValue.Name = "nudRentValue";
            nudRentValue.Size = new Size(151, 34);
            nudRentValue.TabIndex = 47;
            nudRentValue.TextAlign = HorizontalAlignment.Center;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(radioButton1);
            groupBox2.Controls.Add(radioButton2);
            groupBox2.Controls.Add(radioButton3);
            groupBox2.Enabled = false;
            groupBox2.Location = new Point(31, 34);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(442, 87);
            groupBox2.TabIndex = 46;
            groupBox2.TabStop = false;
            groupBox2.Text = "Rental type";
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(308, 33);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(100, 32);
            radioButton1.TabIndex = 37;
            radioButton1.Text = "Custom";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Checked = true;
            radioButton2.Location = new Point(44, 33);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(127, 32);
            radioButton2.TabIndex = 36;
            radioButton2.TabStop = true;
            radioButton2.Text = "Apartment";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            radioButton3.AutoSize = true;
            radioButton3.Location = new Point(210, 33);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new Size(62, 32);
            radioButton3.TabIndex = 35;
            radioButton3.Text = "Car";
            radioButton3.UseVisualStyleBackColor = true;
            // 
            // cbItemForRent
            // 
            cbItemForRent.DropDownStyle = ComboBoxStyle.DropDownList;
            cbItemForRent.Enabled = false;
            cbItemForRent.FormattingEnabled = true;
            cbItemForRent.Location = new Point(267, 128);
            cbItemForRent.Margin = new Padding(4);
            cbItemForRent.Name = "cbItemForRent";
            cbItemForRent.Size = new Size(206, 36);
            cbItemForRent.TabIndex = 44;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(31, 172);
            label10.Margin = new Padding(4, 0, 4, 0);
            label10.Name = "label10";
            label10.Size = new Size(73, 28);
            label10.TabIndex = 22;
            label10.Text = "Tenant:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(31, 128);
            label11.Margin = new Padding(4, 0, 4, 0);
            label11.Name = "label11";
            label11.Size = new Size(125, 28);
            label11.TabIndex = 43;
            label11.Text = "Item for rent:";
            // 
            // cbTenant
            // 
            cbTenant.DropDownStyle = ComboBoxStyle.DropDownList;
            cbTenant.Enabled = false;
            cbTenant.FormattingEnabled = true;
            cbTenant.Location = new Point(267, 172);
            cbTenant.Margin = new Padding(4);
            cbTenant.Name = "cbTenant";
            cbTenant.Size = new Size(206, 36);
            cbTenant.TabIndex = 23;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(514, 203);
            label12.Margin = new Padding(4, 0, 4, 0);
            label12.Name = "label12";
            label12.Size = new Size(93, 28);
            label12.TabIndex = 42;
            label12.Text = "End date:";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(514, 158);
            label13.Margin = new Padding(4, 0, 4, 0);
            label13.Name = "label13";
            label13.Size = new Size(101, 28);
            label13.TabIndex = 41;
            label13.Text = "Start date:";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(514, 57);
            label14.Margin = new Padding(4, 0, 4, 0);
            label14.Name = "label14";
            label14.Size = new Size(228, 28);
            label14.TabIndex = 31;
            label14.Text = "Rent payment frequency:";
            // 
            // dtpEndDate
            // 
            dtpEndDate.Format = DateTimePickerFormat.Short;
            dtpEndDate.Location = new Point(750, 198);
            dtpEndDate.Name = "dtpEndDate";
            dtpEndDate.Size = new Size(151, 34);
            dtpEndDate.TabIndex = 40;
            // 
            // cbRentPaymentFrequency
            // 
            cbRentPaymentFrequency.DropDownStyle = ComboBoxStyle.DropDownList;
            cbRentPaymentFrequency.FormattingEnabled = true;
            cbRentPaymentFrequency.Location = new Point(750, 54);
            cbRentPaymentFrequency.Margin = new Padding(4);
            cbRentPaymentFrequency.Name = "cbRentPaymentFrequency";
            cbRentPaymentFrequency.Size = new Size(151, 36);
            cbRentPaymentFrequency.TabIndex = 32;
            // 
            // dtpStartDate
            // 
            dtpStartDate.Format = DateTimePickerFormat.Short;
            dtpStartDate.Location = new Point(750, 153);
            dtpStartDate.Name = "dtpStartDate";
            dtpStartDate.Size = new Size(151, 34);
            dtpStartDate.TabIndex = 39;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(514, 107);
            label15.Margin = new Padding(4, 0, 4, 0);
            label15.Name = "label15";
            label15.Size = new Size(106, 28);
            label15.TabIndex = 33;
            label15.Text = "Rent value:";
            // 
            // numericUpDown1
            // 
            numericUpDown1.DecimalPlaces = 2;
            numericUpDown1.Location = new Point(1418, 304);
            numericUpDown1.Margin = new Padding(8);
            numericUpDown1.Maximum = new decimal(new int[] { 99999999, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(286, 34);
            numericUpDown1.TabIndex = 34;
            numericUpDown1.TextAlign = HorizontalAlignment.Center;
            // 
            // UpdateRental
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(993, 443);
            Controls.Add(panel2);
            Font = new Font("Segoe UI", 12F);
            Margin = new Padding(4);
            Name = "UpdateRental";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "UpdateRental";
            Load += UpdateRental_Load;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudRentValue).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel2;
        private GroupBox groupBox2;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private RadioButton radioButton3;
        private ComboBox cbItemForRent;
        private Label label10;
        private Label label11;
        private ComboBox cbTenant;
        private Label label12;
        private Label label13;
        private Label label14;
        private DateTimePicker dtpEndDate;
        private ComboBox cbRentPaymentFrequency;
        private DateTimePicker dtpStartDate;
        private Label label15;
        private NumericUpDown numericUpDown1;
        private NumericUpDown nudRentValue;
        private CheckBox chkIsActive;
    }
}