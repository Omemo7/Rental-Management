namespace Windows_Forms_Rental_Management.Tenant
{
    partial class AddTenant
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
            label5 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            txtNationalNO = new TextBox();
            txtName = new TextBox();
            txtEmail = new TextBox();
            txtPhone = new TextBox();
            btnAddPhone = new Button();
            btnRemovePhone = new Button();
            lbPhones = new ListBox();
            label4 = new Label();
            btnClear = new Button();
            SuspendLayout();
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 22.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.Firebrick;
            label6.Location = new Point(388, 29);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(208, 50);
            label6.TabIndex = 30;
            label6.Text = "Add Tenant";
            // 
            // btnAdd
            // 
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Location = new Point(412, 349);
            btnAdd.Margin = new Padding(4);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(149, 47);
            btnAdd.TabIndex = 29;
            btnAdd.Text = "Add ";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(121, 155);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(126, 28);
            label5.TabIndex = 22;
            label5.Text = "National NO:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(502, 226);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(79, 28);
            label3.TabIndex = 20;
            label3.Text = "Phones:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(121, 267);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(63, 28);
            label2.TabIndex = 19;
            label2.Text = "Email:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(121, 211);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(68, 28);
            label1.TabIndex = 18;
            label1.Text = "Name:";
            // 
            // txtNationalNO
            // 
            txtNationalNO.Location = new Point(254, 152);
            txtNationalNO.Name = "txtNationalNO";
            txtNationalNO.Size = new Size(177, 34);
            txtNationalNO.TabIndex = 31;
            // 
            // txtName
            // 
            txtName.Location = new Point(254, 208);
            txtName.Name = "txtName";
            txtName.Size = new Size(177, 34);
            txtName.TabIndex = 32;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(254, 264);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(177, 34);
            txtEmail.TabIndex = 33;
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(591, 146);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(177, 34);
            txtPhone.TabIndex = 34;
            // 
            // btnAddPhone
            // 
            btnAddPhone.FlatStyle = FlatStyle.Flat;
            btnAddPhone.Location = new Point(773, 140);
            btnAddPhone.Margin = new Padding(4);
            btnAddPhone.Name = "btnAddPhone";
            btnAddPhone.Size = new Size(46, 47);
            btnAddPhone.TabIndex = 35;
            btnAddPhone.Text = "+";
            btnAddPhone.UseVisualStyleBackColor = true;
            btnAddPhone.Click += AddPhone_Click;
            // 
            // btnRemovePhone
            // 
            btnRemovePhone.FlatStyle = FlatStyle.Flat;
            btnRemovePhone.Location = new Point(827, 140);
            btnRemovePhone.Margin = new Padding(4);
            btnRemovePhone.Name = "btnRemovePhone";
            btnRemovePhone.Size = new Size(46, 47);
            btnRemovePhone.TabIndex = 36;
            btnRemovePhone.Text = "-";
            btnRemovePhone.UseVisualStyleBackColor = true;
            btnRemovePhone.Click += RemovePhone_Click;
            // 
            // lbPhones
            // 
            lbPhones.FormattingEnabled = true;
            lbPhones.ItemHeight = 28;
            lbPhones.Location = new Point(591, 200);
            lbPhones.Name = "lbPhones";
            lbPhones.SelectionMode = SelectionMode.MultiSimple;
            lbPhones.Size = new Size(177, 116);
            lbPhones.TabIndex = 37;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(505, 152);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(71, 28);
            label4.TabIndex = 38;
            label4.Text = "Phone:";
            // 
            // btnClear
            // 
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Location = new Point(773, 202);
            btnClear.Margin = new Padding(4);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(98, 47);
            btnClear.TabIndex = 39;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // AddTenant
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(950, 464);
            Controls.Add(btnClear);
            Controls.Add(label4);
            Controls.Add(lbPhones);
            Controls.Add(btnRemovePhone);
            Controls.Add(btnAddPhone);
            Controls.Add(txtPhone);
            Controls.Add(txtEmail);
            Controls.Add(txtName);
            Controls.Add(txtNationalNO);
            Controls.Add(label6);
            Controls.Add(btnAdd);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 12F);
            Margin = new Padding(4);
            Name = "AddTenant";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AddTenant";
            Load += AddTenant_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label6;
        private Button btnAdd;
        private Label label5;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox txtNationalNO;
        private TextBox txtName;
        private TextBox txtEmail;
        private TextBox txtPhone;
        private Button btnAddPhone;
        private Button btnRemovePhone;
        private ListBox lbPhones;
        private Label label4;
        private Button btnClear;
    }
}