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
            SuspendLayout();
            // 
            // dataGridViewWithFilterAndContextMenu1
            // 
            dataGridViewWithFilterAndContextMenu1.BackColor = Color.White;
            dataGridViewWithFilterAndContextMenu1.Font = new Font("Segoe UI", 12F);
            dataGridViewWithFilterAndContextMenu1.Location = new Point(71, 146);
            dataGridViewWithFilterAndContextMenu1.Margin = new Padding(4);
            dataGridViewWithFilterAndContextMenu1.Name = "dataGridViewWithFilterAndContextMenu1";
            dataGridViewWithFilterAndContextMenu1.Size = new Size(902, 462);
            dataGridViewWithFilterAndContextMenu1.TabIndex = 0;
            dataGridViewWithFilterAndContextMenu1.UseWaitCursor = true;
            // 
            // ApartmentDetails
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1100, 630);
            Controls.Add(dataGridViewWithFilterAndContextMenu1);
            Font = new Font("Segoe UI", 12F);
            Margin = new Padding(4);
            Name = "ApartmentDetails";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ApartmentDetails";
            UseWaitCursor = true;
            Load += ApartmentDetails_Load;
            ResumeLayout(false);
        }

        #endregion

        private DataGridViewWithFilterAndContextMenu dataGridViewWithFilterAndContextMenu1;
    }
}