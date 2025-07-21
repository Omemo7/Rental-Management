namespace Windows_Forms_Rental_Management.Tenant
{
    partial class TenantDetails
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
            dataGridViewWithFilterAndContextMenu1 = new DataGridViewWithFilterAndContextMenu();
            label1 = new Label();
            nudProfitFromTenant = new NumericUpDown();
            lbPhones = new ListBox();
            label2 = new Label();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)nudProfitFromTenant).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewWithFilterAndContextMenu1
            // 
            dataGridViewWithFilterAndContextMenu1.BackColor = Color.White;
            dataGridViewWithFilterAndContextMenu1.Font = new Font("Segoe UI", 12F);
            dataGridViewWithFilterAndContextMenu1.Location = new Point(28, 241);
            dataGridViewWithFilterAndContextMenu1.Margin = new Padding(4);
            dataGridViewWithFilterAndContextMenu1.Name = "dataGridViewWithFilterAndContextMenu1";
            dataGridViewWithFilterAndContextMenu1.Size = new Size(1159, 462);
            dataGridViewWithFilterAndContextMenu1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(112, 82);
            label1.Name = "label1";
            label1.Size = new Size(226, 28);
            label1.TabIndex = 1;
            label1.Text = "Profit made from tenant:";
            // 
            // nudProfitFromTenant
            // 
            nudProfitFromTenant.DecimalPlaces = 2;
            nudProfitFromTenant.Location = new Point(344, 80);
            nudProfitFromTenant.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            nudProfitFromTenant.Name = "nudProfitFromTenant";
            nudProfitFromTenant.ReadOnly = true;
            nudProfitFromTenant.Size = new Size(150, 34);
            nudProfitFromTenant.TabIndex = 2;
            nudProfitFromTenant.TextAlign = HorizontalAlignment.Center;
            // 
            // lbPhones
            // 
            lbPhones.FormattingEnabled = true;
            lbPhones.ItemHeight = 28;
            lbPhones.Location = new Point(830, 61);
            lbPhones.Name = "lbPhones";
            lbPhones.Size = new Size(158, 116);
            lbPhones.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(733, 72);
            label2.Name = "label2";
            label2.Size = new Size(79, 28);
            label2.TabIndex = 4;
            label2.Text = "Phones:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(28, 209);
            label3.Name = "label3";
            label3.Size = new Size(177, 28);
            label3.TabIndex = 5;
            label3.Text = "Apartment Rentals:";
            // 
            // TenantDetails
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1212, 734);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(lbPhones);
            Controls.Add(nudProfitFromTenant);
            Controls.Add(label1);
            Controls.Add(dataGridViewWithFilterAndContextMenu1);
            Font = new Font("Segoe UI", 12F);
            Margin = new Padding(4);
            Name = "TenantDetails";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "TenantDetails";
            Load += TenantDetails_Load;
            ((System.ComponentModel.ISupportInitialize)nudProfitFromTenant).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridViewWithFilterAndContextMenu dataGridViewWithFilterAndContextMenu1;
        private Label label1;
        private NumericUpDown nudProfitFromTenant;
        private ListBox lbPhones;
        private Label label2;
        private Label label3;
    }
}