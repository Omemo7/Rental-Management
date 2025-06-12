namespace Windows_Forms_Rental_Management
{
    partial class AddApartment
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            cbApartmentBuilding = new ComboBox();
            nudFloorNO = new NumericUpDown();
            nudNumberOfRooms = new NumericUpDown();
            nudNumberOfBathrooms = new NumericUpDown();
            nudSquaredMeters = new NumericUpDown();
            btnAddApartmentBuilding = new Button();
            btnAdd = new Button();
            label6 = new Label();
            txtName = new TextBox();
            label7 = new Label();
            ((System.ComponentModel.ISupportInitialize)nudFloorNO).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudNumberOfRooms).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudNumberOfBathrooms).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudSquaredMeters).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(102, 278);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(97, 28);
            label1.TabIndex = 0;
            label1.Text = "Floor NO:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(102, 335);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(172, 28);
            label2.TabIndex = 2;
            label2.Text = "Number of rooms:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(102, 385);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(212, 28);
            label3.TabIndex = 4;
            label3.Text = "Number of bathrooms:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(102, 437);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(153, 28);
            label4.TabIndex = 6;
            label4.Text = "Squared meters:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(102, 138);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(188, 28);
            label5.TabIndex = 8;
            label5.Text = "Apartment building:";
            // 
            // cbApartmentBuilding
            // 
            cbApartmentBuilding.DropDownStyle = ComboBoxStyle.DropDownList;
            cbApartmentBuilding.FormattingEnabled = true;
            cbApartmentBuilding.Location = new Point(305, 132);
            cbApartmentBuilding.Margin = new Padding(4);
            cbApartmentBuilding.Name = "cbApartmentBuilding";
            cbApartmentBuilding.Size = new Size(206, 36);
            cbApartmentBuilding.TabIndex = 9;
            // 
            // nudFloorNO
            // 
            nudFloorNO.Location = new Point(209, 275);
            nudFloorNO.Margin = new Padding(4);
            nudFloorNO.Name = "nudFloorNO";
            nudFloorNO.Size = new Size(65, 34);
            nudFloorNO.TabIndex = 10;
            nudFloorNO.TextAlign = HorizontalAlignment.Center;
            // 
            // nudNumberOfRooms
            // 
            nudNumberOfRooms.Location = new Point(289, 332);
            nudNumberOfRooms.Margin = new Padding(4);
            nudNumberOfRooms.Name = "nudNumberOfRooms";
            nudNumberOfRooms.Size = new Size(65, 34);
            nudNumberOfRooms.TabIndex = 11;
            nudNumberOfRooms.TextAlign = HorizontalAlignment.Center;
            // 
            // nudNumberOfBathrooms
            // 
            nudNumberOfBathrooms.Location = new Point(330, 383);
            nudNumberOfBathrooms.Margin = new Padding(4);
            nudNumberOfBathrooms.Name = "nudNumberOfBathrooms";
            nudNumberOfBathrooms.Size = new Size(65, 34);
            nudNumberOfBathrooms.TabIndex = 12;
            nudNumberOfBathrooms.TextAlign = HorizontalAlignment.Center;
            // 
            // nudSquaredMeters
            // 
            nudSquaredMeters.DecimalPlaces = 2;
            nudSquaredMeters.Location = new Point(270, 434);
            nudSquaredMeters.Margin = new Padding(4);
            nudSquaredMeters.Name = "nudSquaredMeters";
            nudSquaredMeters.Size = new Size(84, 34);
            nudSquaredMeters.TabIndex = 13;
            nudSquaredMeters.TextAlign = HorizontalAlignment.Center;
            // 
            // btnAddApartmentBuilding
            // 
            btnAddApartmentBuilding.FlatStyle = FlatStyle.Flat;
            btnAddApartmentBuilding.Location = new Point(521, 132);
            btnAddApartmentBuilding.Margin = new Padding(4);
            btnAddApartmentBuilding.Name = "btnAddApartmentBuilding";
            btnAddApartmentBuilding.Size = new Size(37, 36);
            btnAddApartmentBuilding.TabIndex = 15;
            btnAddApartmentBuilding.Text = "+";
            btnAddApartmentBuilding.UseVisualStyleBackColor = true;
            btnAddApartmentBuilding.Click += btnAddApartmentBuilding_Click;
            // 
            // btnAdd
            // 
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Location = new Point(409, 427);
            btnAdd.Margin = new Padding(4);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(149, 46);
            btnAdd.TabIndex = 16;
            btnAdd.Text = "Add ";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 22.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.Firebrick;
            label6.Location = new Point(171, 35);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(276, 50);
            label6.TabIndex = 17;
            label6.Text = "Add Apartment";
            // 
            // txtName
            // 
            txtName.Location = new Point(177, 211);
            txtName.Name = "txtName";
            txtName.Size = new Size(206, 34);
            txtName.TabIndex = 18;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(102, 211);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(68, 28);
            label7.TabIndex = 19;
            label7.Text = "Name:";
            // 
            // AddApartment
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(641, 574);
            Controls.Add(label7);
            Controls.Add(txtName);
            Controls.Add(label6);
            Controls.Add(btnAdd);
            Controls.Add(btnAddApartmentBuilding);
            Controls.Add(nudSquaredMeters);
            Controls.Add(nudNumberOfBathrooms);
            Controls.Add(nudNumberOfRooms);
            Controls.Add(nudFloorNO);
            Controls.Add(cbApartmentBuilding);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "AddApartment";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AddApartment";
            Load += AddApartment_Load;
            ((System.ComponentModel.ISupportInitialize)nudFloorNO).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudNumberOfRooms).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudNumberOfBathrooms).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudSquaredMeters).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private ComboBox cbApartmentBuilding;
        private NumericUpDown nudFloorNO;
        private NumericUpDown nudNumberOfRooms;
        private NumericUpDown nudNumberOfBathrooms;
        private NumericUpDown nudSquaredMeters;
        private Button btnAddApartmentBuilding;
        private Button btnAdd;
        private Label label6;
        private TextBox txtName;
        private Label label7;
    }
}