namespace Windows_Forms_Rental_Management.Tenant
{
    partial class ShowAllTenants
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
            dataGridViewWithFilterAndContextMenu1 = new DataGridViewWithFilterAndContextMenu();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 22.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Firebrick;
            label1.Location = new Point(359, 44);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(298, 50);
            label1.TabIndex = 45;
            label1.Text = "Show All Tenants";
            // 
            // dataGridViewWithFilterAndContextMenu1
            // 
            dataGridViewWithFilterAndContextMenu1.BackColor = Color.White;
            dataGridViewWithFilterAndContextMenu1.Dock = DockStyle.Bottom;
            dataGridViewWithFilterAndContextMenu1.Font = new Font("Segoe UI", 12F);
            dataGridViewWithFilterAndContextMenu1.Location = new Point(0, 143);
            dataGridViewWithFilterAndContextMenu1.Margin = new Padding(4);
            dataGridViewWithFilterAndContextMenu1.Name = "dataGridViewWithFilterAndContextMenu1";
            dataGridViewWithFilterAndContextMenu1.Size = new Size(976, 444);
            dataGridViewWithFilterAndContextMenu1.TabIndex = 46;
            dataGridViewWithFilterAndContextMenu1.ContextMenuItemClicked += dataGridViewWithFilterAndContextMenu1_ContextMenuItemClicked;
            // 
            // ShowAllTenants
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(976, 587);
            Controls.Add(dataGridViewWithFilterAndContextMenu1);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 12F);
            Margin = new Padding(4);
            Name = "ShowAllTenants";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ShowAllTenants";
            Load += ShowAllTenants_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private DataGridViewWithFilterAndContextMenu dataGridViewWithFilterAndContextMenu1;
    }
}