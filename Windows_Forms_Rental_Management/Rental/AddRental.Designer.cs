namespace Windows_Forms_Rental_Management.Rental
{
    partial class AddRental
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
            label6 = new Label();
            btnAdd = new Button();
            btnAddTenant = new Button();
            cbTenant = new ComboBox();
            label5 = new Label();
            label2 = new Label();
            cbRentPaymentFrequency = new ComboBox();
            label7 = new Label();
            openFileDialog1 = new OpenFileDialog();
            nudRentValue = new NumericUpDown();
            label1 = new Label();
            rbCar = new RadioButton();
            rbApartment = new RadioButton();
            rbCustom = new RadioButton();
            dtpStartDate = new DateTimePicker();
            dtpEndDate = new DateTimePicker();
            label3 = new Label();
            label4 = new Label();
            cbItemForRent = new ComboBox();
            label9 = new Label();
            btnAddNewItem = new Button();
            panel1 = new Panel();
            lblSelectedImagesCount = new Label();
            lbContractImagesNames = new ListBox();
            btnSelectImages = new Button();
            groupBox1 = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)nudRentValue).BeginInit();
            panel1.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 22.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.Firebrick;
            label6.Location = new Point(400, 38);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(202, 50);
            label6.TabIndex = 30;
            label6.Text = "Add Rental";
            // 
            // btnAdd
            // 
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Location = new Point(420, 449);
            btnAdd.Margin = new Padding(4);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(149, 46);
            btnAdd.TabIndex = 29;
            btnAdd.Text = "Add ";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnAddTenant
            // 
            btnAddTenant.FlatStyle = FlatStyle.Flat;
            btnAddTenant.Location = new Point(436, 189);
            btnAddTenant.Margin = new Padding(4);
            btnAddTenant.Name = "btnAddTenant";
            btnAddTenant.Size = new Size(37, 36);
            btnAddTenant.TabIndex = 28;
            btnAddTenant.Text = "+";
            btnAddTenant.UseVisualStyleBackColor = true;
            btnAddTenant.Click += btnAddTenant_Click;
            // 
            // cbTenant
            // 
            cbTenant.DropDownStyle = ComboBoxStyle.DropDownList;
            cbTenant.FormattingEnabled = true;
            cbTenant.Location = new Point(222, 189);
            cbTenant.Margin = new Padding(4);
            cbTenant.Name = "cbTenant";
            cbTenant.Size = new Size(206, 36);
            cbTenant.TabIndex = 23;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(31, 192);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(73, 28);
            label5.TabIndex = 22;
            label5.Text = "Tenant:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(513, 175);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(91, 28);
            label2.TabIndex = 19;
            label2.Text = "Contract:";
            // 
            // cbRentPaymentFrequency
            // 
            cbRentPaymentFrequency.DropDownStyle = ComboBoxStyle.DropDownList;
            cbRentPaymentFrequency.FormattingEnabled = true;
            cbRentPaymentFrequency.Location = new Point(267, 240);
            cbRentPaymentFrequency.Margin = new Padding(4);
            cbRentPaymentFrequency.Name = "cbRentPaymentFrequency";
            cbRentPaymentFrequency.Size = new Size(206, 36);
            cbRentPaymentFrequency.TabIndex = 32;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(31, 240);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(228, 28);
            label7.TabIndex = 31;
            label7.Text = "Rent payment frequency:";
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // nudRentValue
            // 
            nudRentValue.DecimalPlaces = 2;
            nudRentValue.Location = new Point(627, 28);
            nudRentValue.Margin = new Padding(4);
            nudRentValue.Maximum = new decimal(new int[] { 99999999, 0, 0, 0 });
            nudRentValue.Name = "nudRentValue";
            nudRentValue.Size = new Size(127, 34);
            nudRentValue.TabIndex = 34;
            nudRentValue.TextAlign = HorizontalAlignment.Center;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(513, 28);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(106, 28);
            label1.TabIndex = 33;
            label1.Text = "Rent value:";
            // 
            // rbCar
            // 
            rbCar.AutoSize = true;
            rbCar.Location = new Point(210, 33);
            rbCar.Name = "rbCar";
            rbCar.Size = new Size(62, 32);
            rbCar.TabIndex = 35;
            rbCar.Text = "Car";
            rbCar.UseVisualStyleBackColor = true;
            // 
            // rbApartment
            // 
            rbApartment.AutoSize = true;
            rbApartment.Checked = true;
            rbApartment.Location = new Point(44, 33);
            rbApartment.Name = "rbApartment";
            rbApartment.Size = new Size(127, 32);
            rbApartment.TabIndex = 36;
            rbApartment.TabStop = true;
            rbApartment.Text = "Apartment";
            rbApartment.UseVisualStyleBackColor = true;
            // 
            // rbCustom
            // 
            rbCustom.AutoSize = true;
            rbCustom.Location = new Point(308, 33);
            rbCustom.Name = "rbCustom";
            rbCustom.Size = new Size(100, 32);
            rbCustom.TabIndex = 37;
            rbCustom.Text = "Custom";
            rbCustom.UseVisualStyleBackColor = true;
            // 
            // dtpStartDate
            // 
            dtpStartDate.Format = DateTimePickerFormat.Short;
            dtpStartDate.Location = new Point(627, 74);
            dtpStartDate.Name = "dtpStartDate";
            dtpStartDate.Size = new Size(250, 34);
            dtpStartDate.TabIndex = 39;
            // 
            // dtpEndDate
            // 
            dtpEndDate.Format = DateTimePickerFormat.Short;
            dtpEndDate.Location = new Point(627, 119);
            dtpEndDate.Name = "dtpEndDate";
            dtpEndDate.Size = new Size(250, 34);
            dtpEndDate.TabIndex = 40;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(513, 79);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(101, 28);
            label3.TabIndex = 41;
            label3.Text = "Start date:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(513, 124);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(93, 28);
            label4.TabIndex = 42;
            label4.Text = "End date:";
            // 
            // cbItemForRent
            // 
            cbItemForRent.DropDownStyle = ComboBoxStyle.DropDownList;
            cbItemForRent.FormattingEnabled = true;
            cbItemForRent.Location = new Point(222, 135);
            cbItemForRent.Margin = new Padding(4);
            cbItemForRent.Name = "cbItemForRent";
            cbItemForRent.Size = new Size(206, 36);
            cbItemForRent.TabIndex = 44;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(31, 135);
            label9.Margin = new Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new Size(125, 28);
            label9.TabIndex = 43;
            label9.Text = "Item for rent:";
            // 
            // btnAddNewItem
            // 
            btnAddNewItem.FlatStyle = FlatStyle.Flat;
            btnAddNewItem.Location = new Point(436, 135);
            btnAddNewItem.Margin = new Padding(4);
            btnAddNewItem.Name = "btnAddNewItem";
            btnAddNewItem.Size = new Size(37, 36);
            btnAddNewItem.TabIndex = 45;
            btnAddNewItem.Text = "+";
            btnAddNewItem.UseVisualStyleBackColor = true;
            btnAddNewItem.Click += btnAddNewItem_Click;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(lblSelectedImagesCount);
            panel1.Controls.Add(lbContractImagesNames);
            panel1.Controls.Add(btnSelectImages);
            panel1.Controls.Add(groupBox1);
            panel1.Controls.Add(btnAddNewItem);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(cbItemForRent);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(cbTenant);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(btnAddTenant);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(dtpEndDate);
            panel1.Controls.Add(cbRentPaymentFrequency);
            panel1.Controls.Add(dtpStartDate);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(nudRentValue);
            panel1.Location = new Point(14, 107);
            panel1.Name = "panel1";
            panel1.Size = new Size(921, 322);
            panel1.TabIndex = 46;
            // 
            // lblSelectedImagesCount
            // 
            lblSelectedImagesCount.AutoSize = true;
            lblSelectedImagesCount.Location = new Point(863, 243);
            lblSelectedImagesCount.Name = "lblSelectedImagesCount";
            lblSelectedImagesCount.Size = new Size(23, 28);
            lblSelectedImagesCount.TabIndex = 49;
            lblSelectedImagesCount.Text = "0";
            // 
            // lbContractImagesNames
            // 
            lbContractImagesNames.FormattingEnabled = true;
            lbContractImagesNames.ItemHeight = 28;
            lbContractImagesNames.Location = new Point(627, 226);
            lbContractImagesNames.Name = "lbContractImagesNames";
            lbContractImagesNames.Size = new Size(221, 60);
            lbContractImagesNames.TabIndex = 48;
            // 
            // btnSelectImages
            // 
            btnSelectImages.FlatStyle = FlatStyle.Flat;
            btnSelectImages.Location = new Point(627, 169);
            btnSelectImages.Margin = new Padding(4);
            btnSelectImages.Name = "btnSelectImages";
            btnSelectImages.Size = new Size(250, 41);
            btnSelectImages.TabIndex = 47;
            btnSelectImages.Text = "Select images";
            btnSelectImages.UseVisualStyleBackColor = true;
            btnSelectImages.Click += btnSelectImages_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(rbCustom);
            groupBox1.Controls.Add(rbApartment);
            groupBox1.Controls.Add(rbCar);
            groupBox1.Location = new Point(31, 28);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(442, 87);
            groupBox1.TabIndex = 46;
            groupBox1.TabStop = false;
            groupBox1.Text = "Choose rental type";
            // 
            // AddRental
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(944, 528);
            Controls.Add(panel1);
            Controls.Add(label6);
            Controls.Add(btnAdd);
            Font = new Font("Segoe UI", 12F);
            Margin = new Padding(4);
            Name = "AddRental";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AddRental";
            Load += AddRental_Load;
            ((System.ComponentModel.ISupportInitialize)nudRentValue).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label6;
        private Button btnAdd;
        private Button btnAddTenant;
        private ComboBox cbTenant;
        private Label label5;
        private Label label2;
        private ComboBox cbRentPaymentFrequency;
        private Label label7;
        private OpenFileDialog openFileDialog1;
        private NumericUpDown nudRentValue;
        private Label label1;
        private RadioButton rbCar;
        private RadioButton rbApartment;
        private RadioButton rbCustom;
        private DateTimePicker dtpStartDate;
        private DateTimePicker dtpEndDate;
        private Label label3;
        private Label label4;
        private ComboBox cbItemForRent;
        private Label label9;
        private Button btnAddNewItem;
        private Panel panel1;
        private GroupBox groupBox1;
        private Button btnSelectImages;
        private ListBox lbContractImagesNames;
        private Label lblSelectedImagesCount;
    }
}