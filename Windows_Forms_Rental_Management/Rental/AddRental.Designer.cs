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
            numericUpDown1 = new NumericUpDown();
            label1 = new Label();
            radioButton1 = new RadioButton();
            radioButton2 = new RadioButton();
            radioButton3 = new RadioButton();
            dateTimePicker1 = new DateTimePicker();
            dateTimePicker2 = new DateTimePicker();
            label3 = new Label();
            label4 = new Label();
            cbItemForRent = new ComboBox();
            label9 = new Label();
            button1 = new Button();
            panel1 = new Panel();
            lbContractPaths = new ListBox();
            btnSelectImages = new Button();
            groupBox1 = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
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
            // numericUpDown1
            // 
            numericUpDown1.DecimalPlaces = 2;
            numericUpDown1.Location = new Point(627, 28);
            numericUpDown1.Margin = new Padding(4);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(84, 34);
            numericUpDown1.TabIndex = 34;
            numericUpDown1.TextAlign = HorizontalAlignment.Center;
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
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(210, 33);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(62, 32);
            radioButton1.TabIndex = 35;
            radioButton1.Text = "Car";
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
            radioButton3.Location = new Point(308, 33);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new Size(100, 32);
            radioButton3.TabIndex = 37;
            radioButton3.Text = "Custom";
            radioButton3.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(627, 74);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(250, 34);
            dateTimePicker1.TabIndex = 39;
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Location = new Point(627, 119);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(250, 34);
            dateTimePicker2.TabIndex = 40;
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
            // button1
            // 
            button1.FlatStyle = FlatStyle.Flat;
            button1.Location = new Point(436, 135);
            button1.Margin = new Padding(4);
            button1.Name = "button1";
            button1.Size = new Size(37, 36);
            button1.TabIndex = 45;
            button1.Text = "+";
            button1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(lbContractPaths);
            panel1.Controls.Add(btnSelectImages);
            panel1.Controls.Add(groupBox1);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(cbItemForRent);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(cbTenant);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(btnAddTenant);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(dateTimePicker2);
            panel1.Controls.Add(cbRentPaymentFrequency);
            panel1.Controls.Add(dateTimePicker1);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(numericUpDown1);
            panel1.Location = new Point(14, 107);
            panel1.Name = "panel1";
            panel1.Size = new Size(921, 322);
            panel1.TabIndex = 46;
            // 
            // lbContractPaths
            // 
            lbContractPaths.FormattingEnabled = true;
            lbContractPaths.ItemHeight = 28;
            lbContractPaths.Location = new Point(513, 228);
            lbContractPaths.Name = "lbContractPaths";
            lbContractPaths.Size = new Size(364, 60);
            lbContractPaths.TabIndex = 48;
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
            groupBox1.Controls.Add(radioButton3);
            groupBox1.Controls.Add(radioButton2);
            groupBox1.Controls.Add(radioButton1);
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
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
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
        private NumericUpDown numericUpDown1;
        private Label label1;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private RadioButton radioButton3;
        private DateTimePicker dateTimePicker1;
        private DateTimePicker dateTimePicker2;
        private Label label3;
        private Label label4;
        private ComboBox cbItemForRent;
        private Label label9;
        private Button button1;
        private Panel panel1;
        private GroupBox groupBox1;
        private Button btnSelectImages;
        private ListBox lbContractPaths;
    }
}