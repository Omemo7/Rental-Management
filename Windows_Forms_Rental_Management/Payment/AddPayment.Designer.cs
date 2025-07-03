namespace Windows_Forms_Rental_Management.Payment
{
    partial class AddPayment
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
            nudPaidAmount = new NumericUpDown();
            dtpPaymentDate = new DateTimePicker();
            label2 = new Label();
            txtTenant = new TextBox();
            label3 = new Label();
            label4 = new Label();
            txtItem = new TextBox();
            btnAdd = new Button();
            ((System.ComponentModel.ISupportInitialize)nudPaidAmount).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(89, 169);
            label1.Name = "label1";
            label1.Size = new Size(135, 28);
            label1.TabIndex = 0;
            label1.Text = "Payment date:";
            // 
            // nudPaidAmount
            // 
            nudPaidAmount.DecimalPlaces = 2;
            nudPaidAmount.Location = new Point(221, 219);
            nudPaidAmount.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            nudPaidAmount.Name = "nudPaidAmount";
            nudPaidAmount.Size = new Size(150, 34);
            nudPaidAmount.TabIndex = 1;
            nudPaidAmount.TextAlign = HorizontalAlignment.Center;
            // 
            // dtpPaymentDate
            // 
            dtpPaymentDate.Format = DateTimePickerFormat.Short;
            dtpPaymentDate.Location = new Point(221, 169);
            dtpPaymentDate.Name = "dtpPaymentDate";
            dtpPaymentDate.Size = new Size(150, 34);
            dtpPaymentDate.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(89, 221);
            label2.Name = "label2";
            label2.Size = new Size(126, 28);
            label2.TabIndex = 3;
            label2.Text = "Paid amount:";
            // 
            // txtTenant
            // 
            txtTenant.Location = new Point(168, 114);
            txtTenant.Name = "txtTenant";
            txtTenant.ReadOnly = true;
            txtTenant.Size = new Size(203, 34);
            txtTenant.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(89, 114);
            label3.Name = "label3";
            label3.Size = new Size(73, 28);
            label3.TabIndex = 5;
            label3.Text = "Tenant:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(89, 55);
            label4.Name = "label4";
            label4.Size = new Size(55, 28);
            label4.TabIndex = 7;
            label4.Text = "Item:";
            // 
            // txtItem
            // 
            txtItem.Location = new Point(168, 55);
            txtItem.Name = "txtItem";
            txtItem.ReadOnly = true;
            txtItem.Size = new Size(203, 34);
            txtItem.TabIndex = 6;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(178, 292);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(104, 38);
            btnAdd.TabIndex = 8;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            // 
            // AddPayment
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(479, 354);
            Controls.Add(btnAdd);
            Controls.Add(label4);
            Controls.Add(txtItem);
            Controls.Add(label3);
            Controls.Add(txtTenant);
            Controls.Add(label2);
            Controls.Add(dtpPaymentDate);
            Controls.Add(nudPaidAmount);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 12F);
            Margin = new Padding(4, 4, 4, 4);
            Name = "AddPayment";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AddPayment";
            ((System.ComponentModel.ISupportInitialize)nudPaidAmount).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private NumericUpDown nudPaidAmount;
        private DateTimePicker dtpPaymentDate;
        private Label label2;
        private TextBox txtTenant;
        private Label label3;
        private Label label4;
        private TextBox txtItem;
        private Button btnAdd;
    }
}