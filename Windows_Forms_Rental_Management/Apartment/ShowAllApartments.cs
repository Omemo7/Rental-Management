using Rental_Management.Business.DTOs.Apartment;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Windows_Forms_Rental_Management.Apartment
{
    public partial class ShowAllApartments : Form
    {
        enum ContextMenuItemsEnum
        {
            AddRental,
            AllRentals,
            Edit,
            Delete,
            MoreDetails
        }
        List<string> ContextMenuItems = new List<string>
            {
                "Add rental",
                "All rentals",
                "Edit",
                "Delete",
                "More details"

            };
        public ShowAllApartments()
        {
            InitializeComponent();
        }


        private async void ShowAllApartments_Load(object sender, EventArgs e)
        {
            dataGridViewWithFilterAndContextMenu1.SetData(await Util.FetchAllDataFromApiAsync<ApartmentDTO>($"Landlord/GetAllApartmentsForLandlord/{LocalLandlord.Id}"));
            SetContextMenuItems();
        }

        void SetContextMenuItems()
        {
            dataGridViewWithFilterAndContextMenu1.SetContextMenuItems(ContextMenuItems);
            dataGridViewWithFilterAndContextMenu1.ContextMenuItemClicked += DataGridViewWithFilterAndContextMenu1_ContextMenuItemClicked;
        }

        private void DataGridViewWithFilterAndContextMenu1_ContextMenuItemClicked(object? sender, DataGridViewWithFilterAndContextMenu.ContextMenuItemClickedEventArgs e)
        {
            
            switch (e.ClickedItem)
            {
                case var t when t == ContextMenuItems[(int)ContextMenuItemsEnum.AddRental]:
                    MessageBox.Show($"Add rental not implemented yet ,record id {e.RecordId}");
                    break;
                case var t when t == ContextMenuItems[(int)ContextMenuItemsEnum.AllRentals]:
                   
                    break;
                case var t when t == ContextMenuItems[(int)ContextMenuItemsEnum.Edit]:
                    throw new NotImplementedException();
                case var t when t == ContextMenuItems[(int)ContextMenuItemsEnum.Delete]:
                    throw new NotImplementedException();
                case var t when t == ContextMenuItems[(int)ContextMenuItemsEnum.MoreDetails]:
                    throw new NotImplementedException();


            }
        }
    }
}
