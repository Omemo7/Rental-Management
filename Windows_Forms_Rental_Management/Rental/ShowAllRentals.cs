using Rental_Management.Business.DTOs.Apartment;
using Rental_Management.Business.DTOs.ApartmentRental;
using Rental_Management.Business.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows_Forms_Rental_Management.Payment;
using static Windows_Forms_Rental_Management.Rental.AddRental;

namespace Windows_Forms_Rental_Management.Rental
{
    public partial class ShowAllRentals : Form
    {

        public enum ContextMenuItemsEnum
        {
            [Description("Add payment")]
            AddPayment,

            [Description("End rental")]
            EndRental,

            [Description("Edit")]
            Edit,

            [Description("More details")]
            MoreDetails
        }
        public ShowAllRentals()
        {
            InitializeComponent();
        }

        public ShowAllRentals(int itemId, RentalType rentalType)
        {
            InitializeComponent();
            
        }

        void SetContextMenuItems()
        {
            dgvApartments.SetContextMenuItems<ContextMenuItemsEnum>();
            dgvApartments.ContextMenuItemClicked += DgvApartments_ContextMenuItemClicked;
        }

        private void DgvApartments_ContextMenuItemClicked(object? sender, DataGridViewWithFilterAndContextMenu.ContextMenuItemClickedEventArgs e)
        {
            switch(e.ClickedItem)
            {
                case ContextMenuItemsEnum.AddPayment:
                    var rentalId = (int)e.CurrentRow?.Cells["RentalId"].Value;
                    var rentValue = (decimal)e.CurrentRow?.Cells["RentValue"].Value;
                    AddPayment addPaymentForm = new AddPayment(rentalId,rentValue);
                    addPaymentForm.ShowDialog();
                    break;
                //case ContextMenuItemsEnum.EndRental:
                //    var endRentalId = (int)dgvApartments.SelectedRows[0].Cells["Id"].Value;
                //    var endRentalForm = new EndRental(endRentalId);
                //    endRentalForm.ShowDialog();
                //    break;
                case ContextMenuItemsEnum.Edit:
                    // Implement edit functionality here
                    break;
                case ContextMenuItemsEnum.MoreDetails:
                    // Implement more details functionality here
                    break;
            }
        }

        private async void ShowAllRentals_Load(object sender, EventArgs e)
        {
            SetContextMenuItems();
            var apartmentRentals= await Util.FetchAllDataFromApiAsync<ApartmentRentalDTOForUI>($"ApartmentRental/GetAllApartmentRentalsForLandlordUI/{LocalLandlord.Id}");
           
            dgvApartments.SetData(apartmentRentals);
        }
    }
}
