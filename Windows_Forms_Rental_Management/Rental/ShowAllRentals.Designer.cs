namespace Windows_Forms_Rental_Management.Rental
{
    partial class ShowAllRentals
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
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            dgvApartments = new DataGridViewWithFilterAndContextMenu();
            tabPage2 = new TabPage();
            dataGridViewWithFilterAndContextMenu2 = new DataGridViewWithFilterAndContextMenu();
            tabPage3 = new TabPage();
            dataGridViewWithFilterAndContextMenu3 = new DataGridViewWithFilterAndContextMenu();
            label6 = new Label();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            tabPage3.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Dock = DockStyle.Bottom;
            tabControl1.Location = new Point(0, 135);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1044, 413);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(dgvApartments);
            tabPage1.Location = new Point(4, 37);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1036, 372);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Apartments";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgvApartments
            // 
            dgvApartments.BackColor = Color.White;
            dgvApartments.Font = new Font("Segoe UI", 12F);
            dgvApartments.Location = new Point(7, 6);
            dgvApartments.Margin = new Padding(4);
            dgvApartments.Name = "dgvApartments";
            dgvApartments.Size = new Size(1020, 361);
            dgvApartments.TabIndex = 0;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(dataGridViewWithFilterAndContextMenu2);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(732, 380);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Cars";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridViewWithFilterAndContextMenu2
            // 
            dataGridViewWithFilterAndContextMenu2.BackColor = Color.White;
            dataGridViewWithFilterAndContextMenu2.Font = new Font("Segoe UI", 12F);
            dataGridViewWithFilterAndContextMenu2.Location = new Point(7, 6);
            dataGridViewWithFilterAndContextMenu2.Margin = new Padding(4);
            dataGridViewWithFilterAndContextMenu2.Name = "dataGridViewWithFilterAndContextMenu2";
            dataGridViewWithFilterAndContextMenu2.Size = new Size(719, 361);
            dataGridViewWithFilterAndContextMenu2.TabIndex = 1;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(dataGridViewWithFilterAndContextMenu3);
            tabPage3.Location = new Point(4, 29);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new Size(732, 380);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Custom";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // dataGridViewWithFilterAndContextMenu3
            // 
            dataGridViewWithFilterAndContextMenu3.BackColor = Color.White;
            dataGridViewWithFilterAndContextMenu3.Font = new Font("Segoe UI", 12F);
            dataGridViewWithFilterAndContextMenu3.Location = new Point(7, 6);
            dataGridViewWithFilterAndContextMenu3.Margin = new Padding(4);
            dataGridViewWithFilterAndContextMenu3.Name = "dataGridViewWithFilterAndContextMenu3";
            dataGridViewWithFilterAndContextMenu3.Size = new Size(719, 361);
            dataGridViewWithFilterAndContextMenu3.TabIndex = 1;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 22.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.Firebrick;
            label6.Location = new Point(373, 39);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(292, 50);
            label6.TabIndex = 31;
            label6.Text = "Show All Rentals";
            // 
            // ShowAllRentals
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1044, 548);
            Controls.Add(label6);
            Controls.Add(tabControl1);
            Font = new Font("Segoe UI", 12F);
            Margin = new Padding(4);
            Name = "ShowAllRentals";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ShowAllRentals";
            Load += ShowAllRentals_Load;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            tabPage3.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private Label label6;
        private DataGridViewWithFilterAndContextMenu dgvApartments;
        private DataGridViewWithFilterAndContextMenu dataGridViewWithFilterAndContextMenu2;
        private DataGridViewWithFilterAndContextMenu dataGridViewWithFilterAndContextMenu3;
    }
}