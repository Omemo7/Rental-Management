namespace Windows_Forms_Rental_Management.Apartment
{
    partial class ApartmentDetails
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
            nudTotalProfit = new NumericUpDown();
            nudTotalMaintenance = new NumericUpDown();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)nudTotalProfit).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudTotalMaintenance).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewWithFilterAndContextMenu1
            // 
            dataGridViewWithFilterAndContextMenu1.BackColor = Color.White;
            dataGridViewWithFilterAndContextMenu1.Font = new Font("Segoe UI", 12F);
            dataGridViewWithFilterAndContextMenu1.Location = new Point(70, 197);
            dataGridViewWithFilterAndContextMenu1.Margin = new Padding(4);
            dataGridViewWithFilterAndContextMenu1.Name = "dataGridViewWithFilterAndContextMenu1";
            dataGridViewWithFilterAndContextMenu1.Size = new Size(961, 390);
            dataGridViewWithFilterAndContextMenu1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(629, 97);
            label1.Name = "label1";
            label1.Size = new Size(174, 28);
            label1.TabIndex = 1;
            label1.Text = "Total maintenance:";
            // 
            // nudTotalProfit
            // 
            nudTotalProfit.DecimalPlaces = 2;
            nudTotalProfit.Location = new Point(259, 97);
            nudTotalProfit.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            nudTotalProfit.Name = "nudTotalProfit";
            nudTotalProfit.ReadOnly = true;
            nudTotalProfit.Size = new Size(150, 34);
            nudTotalProfit.TabIndex = 2;
            nudTotalProfit.TextAlign = HorizontalAlignment.Center;
            // 
            // nudTotalMaintenance
            // 
            nudTotalMaintenance.DecimalPlaces = 2;
            nudTotalMaintenance.Location = new Point(809, 95);
            nudTotalMaintenance.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            nudTotalMaintenance.Name = "nudTotalMaintenance";
            nudTotalMaintenance.ReadOnly = true;
            nudTotalMaintenance.Size = new Size(150, 34);
            nudTotalMaintenance.TabIndex = 4;
            nudTotalMaintenance.TextAlign = HorizontalAlignment.Center;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(141, 97);
            label2.Name = "label2";
            label2.Size = new Size(112, 28);
            label2.TabIndex = 3;
            label2.Text = "Total profit:";
            // 
            // ApartmentDetails
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1100, 630);
            Controls.Add(nudTotalMaintenance);
            Controls.Add(label2);
            Controls.Add(nudTotalProfit);
            Controls.Add(label1);
            Controls.Add(dataGridViewWithFilterAndContextMenu1);
            Font = new Font("Segoe UI", 12F);
            Margin = new Padding(4);
            Name = "ApartmentDetails";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ApartmentDetails";
            Load += ApartmentDetails_Load;
            ((System.ComponentModel.ISupportInitialize)nudTotalProfit).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudTotalMaintenance).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridViewWithFilterAndContextMenu dataGridViewWithFilterAndContextMenu1;
        private Label label1;
        private NumericUpDown nudTotalProfit;
        private NumericUpDown nudTotalMaintenance;
        private Label label2;
    }
}