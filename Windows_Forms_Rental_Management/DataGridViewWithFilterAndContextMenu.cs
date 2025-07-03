using Microsoft.IdentityModel.Tokens;
using RangeSelection;
using Rental_Management.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static RangeSelection.RangeSlider;

namespace Windows_Forms_Rental_Management
{
    public partial class DataGridViewWithFilterAndContextMenu : UserControl
    {
        public class ContextMenuItemClickedEventArgs : EventArgs
        {
            public Enum ClickedItem { get; }
            public DataGridViewRow? CurrentRow {  get; }
            public int RecordId { get; }

            public ContextMenuItemClickedEventArgs(Enum item, int id, DataGridViewRow? currentRow)
            {
                ClickedItem = item;
                RecordId = id;
                CurrentRow = currentRow;
            }
        }

        public static class EnumHelper
        {
            public static List<(T EnumValue, string Description)> GetEnumValuesWithDescriptions<T>() where T : Enum
            {
                return Enum.GetValues(typeof(T))
                           .Cast<T>()
                           .Select(e => (e, GetEnumDescription(e)))
                           .ToList();
            }

            public static string GetEnumDescription(Enum value)
            {
                var field = value.GetType().GetField(value.ToString());
                var attr = (DescriptionAttribute?)Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute));
                return attr?.Description ?? value.ToString();
            }
        }



        enum ColumnType
        {
            Numerical,
            Categorical,
            Boolean,
            Date,
        }
        private object? OriginalData;
        Dictionary<string, ColumnType> VisibleColumnsNamesAndTypes = new Dictionary<string, ColumnType>();
        public event EventHandler<ContextMenuItemClickedEventArgs>? ContextMenuItemClicked;
        

       
        public DataGridViewWithFilterAndContextMenu()
        {
            InitializeComponent();
            BeautifytcFilterType();
           

        }

        void BeautifytcFilterType()
        {
            tcFilterType.DrawMode = TabDrawMode.OwnerDrawFixed;
            tcFilterType.Appearance = TabAppearance.Normal;
            tcFilterType.BackColor = Color.White;
            tcFilterType.Region = new Region(tcFilterType.DisplayRectangle);

            tcFilterType.DrawItem += (s, e) =>
            {
                TabPage page = tcFilterType.TabPages[e.Index];
                Rectangle tabBounds = e.Bounds;

                using (Brush backBrush = new SolidBrush(Color.White))
                    e.Graphics.FillRectangle(backBrush, tabBounds);

                TextRenderer.DrawText(
                    e.Graphics,
                    page.Text,
                    tcFilterType.Font,
                    tabBounds,
                    Color.Black,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter
                );
            };

            foreach (TabPage tabPage in tcFilterType.TabPages)
            {
                tabPage.BackColor = Color.White;
            }
            tcFilterType.Location = new Point(tcFilterType.Location.X, tcFilterType.Location.Y+3 - tcFilterType.ItemSize.Height);
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
            if(data.IsNullOrEmpty())
            {
                MessageBox.Show("No data to display.");
                return;
            }    
            OriginalData = data;
            SetDataGridViewDataWithGoodUI(OriginalData);
            SaveVisibleColumnNamesWithTypes();
            FillcbFilterWithColumnNamesAndTypesItems();
        }

        void FillcbFilterWithColumnNamesAndTypesItems()
        {

            cbFilter.DataSource = new BindingSource(VisibleColumnsNamesAndTypes, null);
            cbFilter.DisplayMember = "Key";
            cbFilter.ValueMember = "Value";

            if (cbFilter.Items.Count > 0)
            {
                cbFilter.SelectedIndex = 0;
            }


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
       
        public void SetContextMenuItems<T>() where T : Enum
        {

            var items = EnumHelper.GetEnumValuesWithDescriptions<T>();
            contextMenuStrip1.Items.Clear();
            foreach (var item in items)
            {
                var menuItem = new ToolStripMenuItem(item.Description);
                menuItem.Tag = item.EnumValue;
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
            

            if (sender is ToolStripMenuItem menuItem && menuItem.Tag is Enum enumValue)
            {
                var currentRow = dataGridView1.CurrentRow;
                int recordId = (int)currentRow.Cells["Id"].Value;
                

                var args = new ContextMenuItemClickedEventArgs(enumValue, recordId,currentRow);
                ContextMenuItemClicked?.Invoke(this, args);
            }
        }

       
        void SaveVisibleColumnNamesWithTypes()
        {
            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                if (!col.Visible || col.HeaderText == "Id")
                {
                    continue;
                }
                Type type = col.ValueType;
                ColumnType columnType;

                if (type == typeof(int) || type == typeof(double) || type == typeof(decimal) || type == typeof(float))
                {
                    columnType = ColumnType.Numerical;
                }
                else if (type == typeof(string) || type.IsEnum)
                {
                    columnType = ColumnType.Categorical;
                }
                else if (type == typeof(bool))
                {
                    columnType = ColumnType.Boolean;
                }
                else if (type == typeof(DateTime) || type == typeof(DateOnly))
                {
                    columnType = ColumnType.Date;
                }
                else
                {
                    MessageBox.Show($"Unsupported column type: {type.Name} for column: {col.HeaderText}.");
                    return;
                }
                VisibleColumnsNamesAndTypes[col.HeaderText] = columnType;
            }
        }
        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {

            SetDataGridViewDataWithGoodUI(OriginalData);
            if (cbFilter.SelectedItem == null)
            {
                return;
            }
            switch (((KeyValuePair<string, ColumnType>)cbFilter.SelectedItem).Value)
            {
                case ColumnType.Numerical:
                    tcFilterType.SelectedTab = MinMaxRangePage;
                    break;
                case ColumnType.Categorical:
                    tcFilterType.SelectedTab = TextboxPage;
                    break;
                case ColumnType.Boolean:
                    tcFilterType.SelectedTab = CheckboxPage;
                    chkFilter.Checked = true;
                    break;
                case ColumnType.Date:
                    tcFilterType.SelectedTab = DatePage;
                    break;
            }


        }

        private void DataGridViewWithFilterAndContextMenu_Load(object sender, EventArgs e)
        {

        }


        void FilterDataGridBasedOnTextbox()
        {
            if (cbFilter.SelectedItem == null || string.IsNullOrWhiteSpace(txtFilter.Text))
            {
                SetDataGridViewDataWithGoodUI(OriginalData);
                return;
            }
            string filterColumn = ((KeyValuePair<string, ColumnType>)cbFilter.SelectedItem).Key.Replace(" ", "");
            string filterText = txtFilter.Text.Trim().ToLower();
            var filteredData = ((IEnumerable<object>)OriginalData)
                .Where(row => row.GetType().GetProperty(filterColumn)?.GetValue(row, null)?.ToString().ToLower().Contains(filterText) ?? false)
                .ToList();
            SetDataGridViewDataWithGoodUI(filteredData);
        }

        void FilterDataGridBasedOnMinMaxRange()
        {
            if (cbFilter.SelectedItem == null)
            {
                SetDataGridViewDataWithGoodUI(OriginalData);
                return;
            }
            string filterColumn = ((KeyValuePair<string, ColumnType>)cbFilter.SelectedItem).Key.Replace(" ", "");

            var filteredData = ((IEnumerable<object>)OriginalData)
                .Where(row =>
                {
                    var value = row.GetType().GetProperty(filterColumn)?.GetValue(row, null);


                    if (value is decimal decimalValue)
                    {
                        return decimalValue <= nudMax.Value && decimalValue >= nudMin.Value;
                    }
                    else if (value is int intValue)
                    {
                        return intValue <= (int)nudMax.Value && intValue >= (int)nudMin.Value;
                    }
                    else if (value is double doubleValue)
                    {
                        return doubleValue <= (double)nudMax.Value && doubleValue >= (double)nudMin.Value;
                    }
                    throw new Exception("not supported numerical filter type");

                })
                .ToList();
            SetDataGridViewDataWithGoodUI(filteredData);
        }

        void SetDataGridViewDataWithGoodUI(object? data)
        {
            dataGridView1.DataSource = data;
            BeautifyColumnHeaders();
            HideColumnsWithID();
        }
        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            FilterDataGridBasedOnTextbox();
        }

        private void nudMin_ValueChanged(object sender, EventArgs e)
        {

        }

        private void nudMax_ValueChanged(object sender, EventArgs e)
        {



        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            if (nudMin.Value > nudMax.Value)
            {
                MessageBox.Show("Minimum value cannot be greater than maximum value.");
                nudMin.Value = nudMax.Value;
            }
            FilterDataGridBasedOnMinMaxRange();
        }
        void FilterDataGridBasedOnCheckbox()
        {
            if (cbFilter.SelectedItem == null)
            {
                SetDataGridViewDataWithGoodUI(OriginalData);
                return;
            }
            string filterColumn = ((KeyValuePair<string, ColumnType>)cbFilter.SelectedItem).Key.Replace(" ", "");
            bool isChecked = chkFilter.Checked;
            var filteredData = ((IEnumerable<object>)OriginalData)
                .Where(row => row.GetType().GetProperty(filterColumn)?.GetValue(row, null) is bool value && value == isChecked)
                .ToList();
            SetDataGridViewDataWithGoodUI(filteredData);
        }
        private void chkFilter_CheckedChanged(object sender, EventArgs e)
        {
            FilterDataGridBasedOnCheckbox();
        }
        void FilterDataGridBasedOnDate()
        {
            if (cbFilter.SelectedItem == null)
            {
                SetDataGridViewDataWithGoodUI(OriginalData);
                return;
            }
            string filterColumn = ((KeyValuePair<string, ColumnType>)cbFilter.SelectedItem).Key.Replace(" ", "");
            DateTime minDate = dtpMin.Value.Date;
            DateTime maxDate = dtpMax.Value.Date;
            var filteredData = ((IEnumerable<object>)OriginalData)
                .Where(row =>
                {
                    var value = row.GetType().GetProperty(filterColumn)?.GetValue(row, null);
                    if (value is DateTime dateValue)
                    {
                        return dateValue >= minDate && dateValue <= maxDate;
                    }
                    else if (value is DateOnly dateOnlyValue)
                    {
                        return dateOnlyValue.ToDateTime(new TimeOnly()) >= minDate && dateOnlyValue.ToDateTime(new TimeOnly()) <= maxDate;
                    }
                    throw new Exception("not supported date filter type");
                })
                .ToList();
            SetDataGridViewDataWithGoodUI(filteredData);
        }
        private void btnFilterDate_Click(object sender, EventArgs e)
        {
            if(dtpMin.Value > dtpMax.Value)
            {
                MessageBox.Show("Minimum date cannot be greater than maximum date.");
                dtpMin.Value = dtpMax.Value;
            }

            FilterDataGridBasedOnDate();


        }
    }
}
