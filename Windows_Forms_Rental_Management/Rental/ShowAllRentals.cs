using Rental_Management.Business.DTOs.Apartment;
using Rental_Management.Business.DTOs.ApartmentRental;
using Rental_Management.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Windows_Forms_Rental_Management.Rental
{
    public partial class ShowAllRentals : Form
    {
        public ShowAllRentals()
        {
            InitializeComponent();
        }

        private async void ShowAllRentals_Load(object sender, EventArgs e)
        {
            var apartmentRentals= await Util.FetchAllDataFromApiAsync<ApartmentRentalDTOForUI>($"Landlord/GetAllApartmentRentalsForLandlordUI/{LocalLandlord.Id}");
           
            dgvApartments.SetData(apartmentRentals);
        }
    }
}
