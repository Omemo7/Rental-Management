using Rental_Management.Business.DTOs.ApartmentRental;
using Rental_Management.DataAccess.Entities;
using Shared.DTOs.ApartmentRental;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Windows_Forms_Rental_Management.Apartment
{
    public partial class ApartmentDetails : Form
    {

        int _apartmentId;
        public ApartmentDetails(int apartmentId)
        {
            InitializeComponent();
            _apartmentId = apartmentId;
        }

        private async void ApartmentDetails_Load(object sender, EventArgs e)
        {
            var apartmentRentals = await Util.FetchAllDataFromApiAsync<ApartmentRentalDTOForUI>($"Landlord/GetAllApartmentRentalsForLandlordUI/{LocalLandlord.Id}");
            
            dataGridViewWithFilterAndContextMenu1.SetData(apartmentRentals);
        }
    }
}
