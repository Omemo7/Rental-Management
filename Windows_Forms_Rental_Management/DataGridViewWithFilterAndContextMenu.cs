using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Windows_Forms_Rental_Management
{
    public partial class DataGridViewWithFilterAndContextMenu : UserControl
    {
        public class ContextMenuItemClickedEventArgs : EventArgs
        {
            public string ClickedItem { get; set; }
            public int RecordId { get; set; }
            public ContextMenuItemClickedEventArgs(string item, int id)
            {
                ClickedItem = item;
                RecordId = id;
            }
        }


        
        public event EventHandler<ContextMenuItemClickedEventArgs>? ContextMenuItemClicked;
        private int CurrentSelectedRecordId = -1;
        public DataGridViewWithFilterAndContextMenu()
        {
            InitializeComponent();
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            OnRowsCountChange();
        }

        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            OnRowsCountChange();
        }

        private void BeautifyColumnHeaders()
        {
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.HeaderText = Regex.Replace(column.HeaderText, "(\\B[A-Z])", " $1");
            }
            
        }

        public void SetData<T>(IEnumerable<T>? data)
        {
            dataGridView1.DataSource = data;
            BeautifyColumnHeaders();
            HideColumnsWithID();
        }
        void OnRowsCountChange()
        {
            lblCount.Text = dataGridView1.Rows.Count.ToString();
        }

        void HideColumnsWithID()
        {
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                if (column.HeaderText.IndexOf("id", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    column.Visible = false;
                }
            }

        }
        public void SetContextMenuItems(List<string> items)
        {
            contextMenuStrip1.Items.Clear();
            foreach (var item in items)
            {
                var menuItem = new ToolStripMenuItem(item);
                menuItem.Click += OnContextMenuItemClicked;
                contextMenuStrip1.Items.Add(menuItem);
            }

        }

        private void OnContextMenuItemClicked(object? sender, EventArgs e)
        {
            if (sender == null || !(sender is ToolStripMenuItem))
            {
                MessageBox.Show("Invalid context menu item clicked.");
                return;
            }
            if (CurrentSelectedRecordId < 0)
            {
                MessageBox.Show("No record selected.");
                return;
            }
            ContextMenuItemClicked?.Invoke(this, new ContextMenuItemClickedEventArgs(((ToolStripMenuItem)sender).Text, CurrentSelectedRecordId));
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                var idValue = dataGridView1.CurrentRow.Cells["Id"].Value;
                if (idValue != null && int.TryParse(idValue.ToString(), out int id))
                {
                    CurrentSelectedRecordId = id;
                }
                else
                {
                    MessageBox.Show("Id value is not valid or not selected.");
                }
            }
            catch
            { MessageBox.Show("Id column doesn't exist"); }
            


        }
    }
}
