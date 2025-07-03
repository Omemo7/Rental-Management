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
using Windows_Forms_Rental_Management.Rental;

namespace Windows_Forms_Rental_Management.Apartment
{
    public partial class ShowAllApartments : Form
    {



        public enum ContextMenuItemsEnum
        {
            [Description("Add rental")]
            AddRental,



            [Description("Edit")]
            Edit,

            [Description("Delete")]
            Delete,

            [Description("More details")]
            MoreDetails
        }


        public ShowAllApartments()
        {
            InitializeComponent();
        }


        private async void ShowAllApartments_Load(object sender, EventArgs e)
        {
            RefreshAndLoadData(null, null);
            SetContextMenuItems();
        }

        void SetContextMenuItems()
        {
            dataGridViewWithFilterAndContextMenu1.SetContextMenuItems<ContextMenuItemsEnum>();
            dataGridViewWithFilterAndContextMenu1.ContextMenuItemClicked += DataGridViewWithFilterAndContextMenu1_ContextMenuItemClicked;
        }

        private async void DataGridViewWithFilterAndContextMenu1_ContextMenuItemClicked(object? sender, DataGridViewWithFilterAndContextMenu.ContextMenuItemClickedEventArgs e)
        {
            
            switch (e.ClickedItem)
            {
                case ContextMenuItemsEnum.AddRental:
                    AddRental addRentalForm = new AddRental(e.RecordId,AddRental.RentalType.Apartment);
                    addRentalForm.FormClosed += RefreshAndLoadData;
                    addRentalForm.ShowDialog();
                    break;
                
                case ContextMenuItemsEnum.Edit:
                    AddUpdateApartment form = new AddUpdateApartment(e.RecordId);
                    form.FormClosed += RefreshAndLoadData;
                    form.ShowDialog();
                    break;
                case ContextMenuItemsEnum.Delete:
                        await DeleteApartment(e.RecordId);
                    break;
                case ContextMenuItemsEnum.MoreDetails:
                    ApartmentDetails frm=new ApartmentDetails(e.RecordId);
                    frm.FormClosed += RefreshAndLoadData;
                    frm.ShowDialog();
                    break;



            }
        }

       

        async void RefreshAndLoadData(object? sender, FormClosedEventArgs e)
        {
            dataGridViewWithFilterAndContextMenu1.SetData(await
                    Util.FetchAllDataFromApiAsync<ApartmentDTO>($"Landlord/GetAllApartmentsForLandlord/{LocalLandlord.Id}"));

        }
        async Task DeleteApartment(int apartmentId)
        {
            if (MessageBox.Show("Are you sure you want to delete apartment?\nNote: apartment will not be deleted if it has relations", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                HttpResponseMessage response = await Util.DeleteItemAsync($"Apartment/Delete/{apartmentId}");
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Apartment deleted successfully.");
                    RefreshAndLoadData(null, null);
                }
                else
                {
                    MessageBox.Show("Failed to delete apartment. It may have related rentals or other dependencies.");
                }
            }
        }
    }
}
