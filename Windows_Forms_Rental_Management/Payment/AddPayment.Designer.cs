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
            nudPaidAmount = new NumericUpDown();
            label2 = new Label();
            btnAdd = new Button();
            ((System.ComponentModel.ISupportInitialize)nudPaidAmount).BeginInit();
            SuspendLayout();
            // 
            // nudPaidAmount
            // 
            nudPaidAmount.DecimalPlaces = 2;
            nudPaidAmount.Location = new Point(155, 26);
            nudPaidAmount.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            nudPaidAmount.Name = "nudPaidAmount";
            nudPaidAmount.Size = new Size(150, 34);
            nudPaidAmount.TabIndex = 1;
            nudPaidAmount.TextAlign = HorizontalAlignment.Center;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(23, 28);
            label2.Name = "label2";
            label2.Size = new Size(126, 28);
            label2.TabIndex = 3;
            label2.Text = "Paid amount:";
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(112, 99);
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
            ClientSize = new Size(334, 162);
            Controls.Add(btnAdd);
            Controls.Add(label2);
            Controls.Add(nudPaidAmount);
            Font = new Font("Segoe UI", 12F);
            Margin = new Padding(4);
            Name = "AddPayment";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AddPayment";
            Load += AddPayment_Load;
            ((System.ComponentModel.ISupportInitialize)nudPaidAmount).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private NumericUpDown nudPaidAmount;
        private Label label2;
        private Button btnAdd;
    }
}