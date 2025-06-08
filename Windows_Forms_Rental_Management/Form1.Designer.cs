namespace Windows_Forms_Rental_Management
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            apartmentsToolStripMenuItem = new ToolStripMenuItem();
            addToolStripMenuItem = new ToolStripMenuItem();
            showAllToolStripMenuItem = new ToolStripMenuItem();
            tenantsToolStripMenuItem = new ToolStripMenuItem();
            addToolStripMenuItem1 = new ToolStripMenuItem();
            showAllTenantsToolStripMenuItem = new ToolStripMenuItem();
            carsToolStripMenuItem = new ToolStripMenuItem();
            paymentsToolStripMenuItem = new ToolStripMenuItem();
            rentalsToolStripMenuItem = new ToolStripMenuItem();
            addToolStripMenuItem2 = new ToolStripMenuItem();
            updateToolStripMenuItem1 = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Font = new Font("Stencil", 15F, FontStyle.Italic);
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { apartmentsToolStripMenuItem, tenantsToolStripMenuItem, carsToolStripMenuItem, paymentsToolStripMenuItem, rentalsToolStripMenuItem, toolStripMenuItem1 });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(10, 4, 0, 4);
            menuStrip1.Size = new Size(870, 42);
            menuStrip1.TabIndex = 2;
            menuStrip1.Text = "menuStrip1";
            // 
            // apartmentsToolStripMenuItem
            // 
            apartmentsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { addToolStripMenuItem, showAllToolStripMenuItem });
            apartmentsToolStripMenuItem.Name = "apartmentsToolStripMenuItem";
            apartmentsToolStripMenuItem.Size = new Size(186, 34);
            apartmentsToolStripMenuItem.Text = "Apartments";
            apartmentsToolStripMenuItem.Click += apartmentsToolStripMenuItem_Click;
            // 
            // addToolStripMenuItem
            // 
            addToolStripMenuItem.Name = "addToolStripMenuItem";
            addToolStripMenuItem.Size = new Size(224, 34);
            addToolStripMenuItem.Text = "Add";
            addToolStripMenuItem.Click += addToolStripMenuItem_Click_1;
            // 
            // showAllToolStripMenuItem
            // 
            showAllToolStripMenuItem.Name = "showAllToolStripMenuItem";
            showAllToolStripMenuItem.Size = new Size(224, 34);
            showAllToolStripMenuItem.Text = "Show All";
            showAllToolStripMenuItem.Click += showAllToolStripMenuItem_Click;
            // 
            // tenantsToolStripMenuItem
            // 
            tenantsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { addToolStripMenuItem1, showAllTenantsToolStripMenuItem });
            tenantsToolStripMenuItem.Name = "tenantsToolStripMenuItem";
            tenantsToolStripMenuItem.Size = new Size(135, 34);
            tenantsToolStripMenuItem.Text = "Tenants";
            // 
            // addToolStripMenuItem1
            // 
            addToolStripMenuItem1.Name = "addToolStripMenuItem1";
            addToolStripMenuItem1.Size = new Size(224, 34);
            addToolStripMenuItem1.Text = "Add";
            addToolStripMenuItem1.Click += addToolStripMenuItem1_Click;
            // 
            // showAllTenantsToolStripMenuItem
            // 
            showAllTenantsToolStripMenuItem.Name = "showAllTenantsToolStripMenuItem";
            showAllTenantsToolStripMenuItem.Size = new Size(224, 34);
            showAllTenantsToolStripMenuItem.Text = "Show All";
            showAllTenantsToolStripMenuItem.Click += showAllTenantsToolStripMenuItem_Click;
            // 
            // carsToolStripMenuItem
            // 
            carsToolStripMenuItem.Name = "carsToolStripMenuItem";
            carsToolStripMenuItem.Size = new Size(88, 34);
            carsToolStripMenuItem.Text = "Cars";
            // 
            // paymentsToolStripMenuItem
            // 
            paymentsToolStripMenuItem.Name = "paymentsToolStripMenuItem";
            paymentsToolStripMenuItem.Size = new Size(154, 34);
            paymentsToolStripMenuItem.Text = "Payments";
            // 
            // rentalsToolStripMenuItem
            // 
            rentalsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { addToolStripMenuItem2, updateToolStripMenuItem1 });
            rentalsToolStripMenuItem.Name = "rentalsToolStripMenuItem";
            rentalsToolStripMenuItem.Size = new Size(133, 34);
            rentalsToolStripMenuItem.Text = "Rentals";
            // 
            // addToolStripMenuItem2
            // 
            addToolStripMenuItem2.Name = "addToolStripMenuItem2";
            addToolStripMenuItem2.Size = new Size(224, 34);
            addToolStripMenuItem2.Text = "Add";
            addToolStripMenuItem2.Click += addToolStripMenuItem2_Click;
            // 
            // updateToolStripMenuItem1
            // 
            updateToolStripMenuItem1.Name = "updateToolStripMenuItem1";
            updateToolStripMenuItem1.Size = new Size(224, 34);
            updateToolStripMenuItem1.Text = "Show All";
            updateToolStripMenuItem1.Click += updateToolStripMenuItem1_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(124, 34);
            toolStripMenuItem1.Text = "Custom";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(14F, 35F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(870, 502);
            Controls.Add(menuStrip1);
            Font = new Font("Segoe UI", 15F);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip1;
            Margin = new Padding(5, 5, 5, 5);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Main";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private MenuStrip menuStrip1;
        private ToolStripMenuItem tenantsToolStripMenuItem;
        private ToolStripMenuItem carsToolStripMenuItem;
        private ToolStripMenuItem paymentsToolStripMenuItem;
        private ToolStripMenuItem rentalsToolStripMenuItem;
        private ToolStripMenuItem addToolStripMenuItem1;
        private ToolStripMenuItem showAllTenantsToolStripMenuItem;
        private ToolStripMenuItem addToolStripMenuItem2;
        private ToolStripMenuItem updateToolStripMenuItem1;
        private ToolStripMenuItem apartmentsToolStripMenuItem;
        private ToolStripMenuItem addToolStripMenuItem;
        private ToolStripMenuItem showAllToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem1;
    }
}
