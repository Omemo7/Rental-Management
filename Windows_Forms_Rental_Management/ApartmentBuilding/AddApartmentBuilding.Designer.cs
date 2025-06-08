namespace Windows_Forms_Rental_Management.ApartmentBuilding
{
    partial class AddApartmentBuilding
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
            txtBuildingNO = new TextBox();
            label1 = new Label();
            label2 = new Label();
            txtStreetAddress = new TextBox();
            label3 = new Label();
            txtNeighborhood = new TextBox();
            label4 = new Label();
            txtCity = new TextBox();
            btnAdd = new Button();
            label6 = new Label();
            SuspendLayout();
            // 
            // txtBuildingNO
            // 
            txtBuildingNO.Location = new Point(259, 137);
            txtBuildingNO.Margin = new Padding(4, 4, 4, 4);
            txtBuildingNO.Name = "txtBuildingNO";
            txtBuildingNO.Size = new Size(170, 34);
            txtBuildingNO.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(122, 142);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(123, 28);
            label1.TabIndex = 1;
            label1.Text = "Building NO:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(122, 202);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(139, 28);
            label2.TabIndex = 3;
            label2.Text = "Street address:";
            // 
            // txtStreetAddress
            // 
            txtStreetAddress.Location = new Point(276, 198);
            txtStreetAddress.Margin = new Padding(4, 4, 4, 4);
            txtStreetAddress.Name = "txtStreetAddress";
            txtStreetAddress.Size = new Size(170, 34);
            txtStreetAddress.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(122, 266);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(147, 28);
            label3.TabIndex = 5;
            label3.Text = "Neighborhood:";
            // 
            // txtNeighborhood
            // 
            txtNeighborhood.Location = new Point(276, 262);
            txtNeighborhood.Margin = new Padding(4, 4, 4, 4);
            txtNeighborhood.Name = "txtNeighborhood";
            txtNeighborhood.Size = new Size(170, 34);
            txtNeighborhood.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(122, 326);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(50, 28);
            label4.TabIndex = 7;
            label4.Text = "City:";
            // 
            // txtCity
            // 
            txtCity.Location = new Point(181, 322);
            txtCity.Margin = new Padding(4, 4, 4, 4);
            txtCity.Name = "txtCity";
            txtCity.Size = new Size(170, 34);
            txtCity.TabIndex = 6;
            // 
            // btnAdd
            // 
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Location = new Point(218, 378);
            btnAdd.Margin = new Padding(4, 4, 4, 4);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(133, 41);
            btnAdd.TabIndex = 8;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 22.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.Firebrick;
            label6.Location = new Point(74, 40);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(420, 50);
            label6.TabIndex = 18;
            label6.Text = "Add Apartment Building";
            // 
            // AddApartmentBuilding
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(568, 460);
            Controls.Add(label6);
            Controls.Add(btnAdd);
            Controls.Add(label4);
            Controls.Add(txtCity);
            Controls.Add(label3);
            Controls.Add(txtNeighborhood);
            Controls.Add(label2);
            Controls.Add(txtStreetAddress);
            Controls.Add(label1);
            Controls.Add(txtBuildingNO);
            Font = new Font("Segoe UI", 12F);
            Margin = new Padding(4, 4, 4, 4);
            Name = "AddApartmentBuilding";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AddApartmentBuilding";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtBuildingNO;
        private Label label1;
        private Label label2;
        private TextBox txtStreetAddress;
        private Label label3;
        private TextBox txtNeighborhood;
        private Label label4;
        private TextBox txtCity;
        private Button btnAdd;
        private Label label6;
    }
}