namespace Windows_Forms_Rental_Management
{
    partial class DataGridViewWithFilterAndContextMenu
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            txtFilter = new TextBox();
            label1 = new Label();
            cbFilter = new ComboBox();
            label2 = new Label();
            lblCount = new Label();
            dataGridView1 = new DataGridView();
            contextMenuStrip1 = new ContextMenuStrip(components);
            FilterRangePanel = new Panel();
            nudMax = new NumericUpDown();
            label4 = new Label();
            label3 = new Label();
            nudMin = new NumericUpDown();
            chkFilter = new CheckBox();
            tcFilterType = new TabControl();
            DatePage = new TabPage();
            btnFilterDate = new Button();
            dtpMax = new DateTimePicker();
            dtpMin = new DateTimePicker();
            label6 = new Label();
            label5 = new Label();
            CheckboxPage = new TabPage();
            MinMaxRangePage = new TabPage();
            btnFilter = new Button();
            TextboxPage = new TabPage();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            FilterRangePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudMax).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudMin).BeginInit();
            tcFilterType.SuspendLayout();
            DatePage.SuspendLayout();
            CheckboxPage.SuspendLayout();
            MinMaxRangePage.SuspendLayout();
            TextboxPage.SuspendLayout();
            SuspendLayout();
            // 
            // txtFilter
            // 
            txtFilter.Location = new Point(3, 6);
            txtFilter.Name = "txtFilter";
            txtFilter.Size = new Size(254, 34);
            txtFilter.TabIndex = 1;
            txtFilter.TextChanged += txtFilter_TextChanged;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label1.Location = new Point(2, 17);
            label1.Name = "label1";
            label1.Size = new Size(95, 28);
            label1.TabIndex = 2;
            label1.Text = "Filter by:";
            // 
            // cbFilter
            // 
            cbFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cbFilter.DropDownWidth = 300;
            cbFilter.FormattingEnabled = true;
            cbFilter.Location = new Point(95, 14);
            cbFilter.Name = "cbFilter";
            cbFilter.Size = new Size(231, 36);
            cbFilter.TabIndex = 3;
            cbFilter.SelectedIndexChanged += cbFilter_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label2.Location = new Point(814, 20);
            label2.Name = "label2";
            label2.Size = new Size(73, 28);
            label2.TabIndex = 4;
            label2.Text = "Count:";
            // 
            // lblCount
            // 
            lblCount.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            lblCount.AutoSize = true;
            lblCount.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblCount.Location = new Point(889, 20);
            lblCount.Name = "lblCount";
            lblCount.Size = new Size(30, 28);
            lblCount.TabIndex = 5;
            lblCount.Text = "??";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.ContextMenuStrip = contextMenuStrip1;
            dataGridView1.Location = new Point(3, 56);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(921, 311);
            dataGridView1.TabIndex = 6;
            dataGridView1.RowsAdded += dataGridView1_RowsAdded;
            dataGridView1.RowsRemoved += dataGridView1_RowsRemoved;
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // FilterRangePanel
            // 
            FilterRangePanel.Controls.Add(nudMax);
            FilterRangePanel.Controls.Add(label4);
            FilterRangePanel.Controls.Add(label3);
            FilterRangePanel.Controls.Add(nudMin);
            FilterRangePanel.Location = new Point(0, 0);
            FilterRangePanel.Name = "FilterRangePanel";
            FilterRangePanel.Size = new Size(265, 42);
            FilterRangePanel.TabIndex = 7;
            // 
            // nudMax
            // 
            nudMax.DecimalPlaces = 2;
            nudMax.Location = new Point(186, 3);
            nudMax.Maximum = new decimal(new int[] { 99999999, 0, 0, 0 });
            nudMax.Name = "nudMax";
            nudMax.Size = new Size(78, 34);
            nudMax.TabIndex = 3;
            nudMax.TextAlign = HorizontalAlignment.Center;
            nudMax.ValueChanged += nudMax_ValueChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(134, 5);
            label4.Name = "label4";
            label4.Size = new Size(53, 28);
            label4.TabIndex = 2;
            label4.Text = "Max:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(0, 5);
            label3.Name = "label3";
            label3.Size = new Size(50, 28);
            label3.TabIndex = 1;
            label3.Text = "Min:";
            // 
            // nudMin
            // 
            nudMin.DecimalPlaces = 2;
            nudMin.Location = new Point(50, 3);
            nudMin.Maximum = new decimal(new int[] { 99999999, 0, 0, 0 });
            nudMin.Name = "nudMin";
            nudMin.Size = new Size(78, 34);
            nudMin.TabIndex = 0;
            nudMin.TextAlign = HorizontalAlignment.Center;
            nudMin.ValueChanged += nudMin_ValueChanged;
            // 
            // chkFilter
            // 
            chkFilter.AutoSize = true;
            chkFilter.Location = new Point(3, 16);
            chkFilter.Name = "chkFilter";
            chkFilter.Size = new Size(18, 17);
            chkFilter.TabIndex = 8;
            chkFilter.UseVisualStyleBackColor = true;
            chkFilter.CheckedChanged += chkFilter_CheckedChanged;
            // 
            // tcFilterType
            // 
            tcFilterType.Appearance = TabAppearance.Buttons;
            tcFilterType.Controls.Add(DatePage);
            tcFilterType.Controls.Add(CheckboxPage);
            tcFilterType.Controls.Add(MinMaxRangePage);
            tcFilterType.Controls.Add(TextboxPage);
            tcFilterType.ItemSize = new Size(0, 1);
            tcFilterType.Location = new Point(329, 0);
            tcFilterType.Margin = new Padding(0);
            tcFilterType.Name = "tcFilterType";
            tcFilterType.SelectedIndex = 0;
            tcFilterType.Size = new Size(472, 55);
            tcFilterType.SizeMode = TabSizeMode.Fixed;
            tcFilterType.TabIndex = 9;
            // 
            // DatePage
            // 
            DatePage.Controls.Add(btnFilterDate);
            DatePage.Controls.Add(dtpMax);
            DatePage.Controls.Add(dtpMin);
            DatePage.Controls.Add(label6);
            DatePage.Controls.Add(label5);
            DatePage.Location = new Point(4, 5);
            DatePage.Name = "DatePage";
            DatePage.Padding = new Padding(3);
            DatePage.Size = new Size(464, 46);
            DatePage.TabIndex = 3;
            DatePage.Text = "DatePage";
            DatePage.UseVisualStyleBackColor = true;
            // 
            // btnFilterDate
            // 
            btnFilterDate.Location = new Point(420, 17);
            btnFilterDate.Name = "btnFilterDate";
            btnFilterDate.Size = new Size(32, 23);
            btnFilterDate.TabIndex = 11;
            btnFilterDate.Text = "button1";
            btnFilterDate.UseVisualStyleBackColor = true;
            btnFilterDate.Click += btnFilterDate_Click;
            // 
            // dtpMax
            // 
            dtpMax.Format = DateTimePickerFormat.Short;
            dtpMax.Location = new Point(270, 9);
            dtpMax.Name = "dtpMax";
            dtpMax.Size = new Size(144, 34);
            dtpMax.TabIndex = 10;
            // 
            // dtpMin
            // 
            dtpMin.Format = DateTimePickerFormat.Short;
            dtpMin.Location = new Point(62, 9);
            dtpMin.Name = "dtpMin";
            dtpMin.Size = new Size(144, 34);
            dtpMin.TabIndex = 9;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(211, 12);
            label6.Name = "label6";
            label6.Size = new Size(53, 28);
            label6.TabIndex = 1;
            label6.Text = "Max:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 12);
            label5.Name = "label5";
            label5.Size = new Size(50, 28);
            label5.TabIndex = 0;
            label5.Text = "Min:";
            // 
            // CheckboxPage
            // 
            CheckboxPage.Controls.Add(chkFilter);
            CheckboxPage.Location = new Point(4, 5);
            CheckboxPage.Name = "CheckboxPage";
            CheckboxPage.Padding = new Padding(3);
            CheckboxPage.Size = new Size(464, 46);
            CheckboxPage.TabIndex = 0;
            CheckboxPage.Text = "tabPage1";
            CheckboxPage.UseVisualStyleBackColor = true;
            // 
            // MinMaxRangePage
            // 
            MinMaxRangePage.Controls.Add(btnFilter);
            MinMaxRangePage.Controls.Add(FilterRangePanel);
            MinMaxRangePage.Location = new Point(4, 5);
            MinMaxRangePage.Name = "MinMaxRangePage";
            MinMaxRangePage.Padding = new Padding(3);
            MinMaxRangePage.Size = new Size(464, 46);
            MinMaxRangePage.TabIndex = 1;
            MinMaxRangePage.Text = "tabPage2";
            MinMaxRangePage.UseVisualStyleBackColor = true;
            // 
            // btnFilter
            // 
            btnFilter.Location = new Point(278, 12);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(40, 23);
            btnFilter.TabIndex = 8;
            btnFilter.Text = "T";
            btnFilter.UseVisualStyleBackColor = true;
            btnFilter.Click += btnFilter_Click;
            // 
            // TextboxPage
            // 
            TextboxPage.Controls.Add(txtFilter);
            TextboxPage.Location = new Point(4, 5);
            TextboxPage.Name = "TextboxPage";
            TextboxPage.Padding = new Padding(3);
            TextboxPage.Size = new Size(464, 46);
            TextboxPage.TabIndex = 2;
            TextboxPage.Text = "tabPage3";
            TextboxPage.UseVisualStyleBackColor = true;
            // 
            // DataGridViewWithFilterAndContextMenu
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(tcFilterType);
            Controls.Add(dataGridView1);
            Controls.Add(lblCount);
            Controls.Add(label2);
            Controls.Add(cbFilter);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 12F);
            Margin = new Padding(4);
            Name = "DataGridViewWithFilterAndContextMenu";
            Size = new Size(927, 370);
            Load += DataGridViewWithFilterAndContextMenu_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            FilterRangePanel.ResumeLayout(false);
            FilterRangePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudMax).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudMin).EndInit();
            tcFilterType.ResumeLayout(false);
            DatePage.ResumeLayout(false);
            DatePage.PerformLayout();
            CheckboxPage.ResumeLayout(false);
            CheckboxPage.PerformLayout();
            MinMaxRangePage.ResumeLayout(false);
            TextboxPage.ResumeLayout(false);
            TextboxPage.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtFilter;
        private Label label1;
        private ComboBox cbFilter;
        private Label label2;
        private Label lblCount;
        private DataGridView dataGridView1;
        private ContextMenuStrip contextMenuStrip1;
        private Panel FilterRangePanel;
        private NumericUpDown nudMax;
        private Label label4;
        private Label label3;
        private NumericUpDown nudMin;
        private CheckBox chkFilter;
        private TabControl tcFilterType;
        private TabPage CheckboxPage;
        private TabPage MinMaxRangePage;
        private TabPage TextboxPage;
        private Button btnFilter;
        private TabPage DatePage;
        private DateTimePicker dtpMax;
        private DateTimePicker dtpMin;
        private Label label6;
        private Label label5;
        private Button btnFilterDate;
    }
}
