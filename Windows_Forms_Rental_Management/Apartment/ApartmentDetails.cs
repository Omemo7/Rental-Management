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
            nudTotalProfit.Value =await Util.FetchSingleItemFromApiAsync<decimal>($"Apartment/GetApartmentTotalProfit/{_apartmentId}");
            nudTotalMaintenance.Value = await Util.FetchSingleItemFromApiAsync<decimal>($"Apartment/GetApartmentTotalMaintenance/{_apartmentId}");
            var apartmentRentals = await Util.FetchAllDataFromApiAsync<ApartmentRentalDTOForUI>($"ApartmentRental/GetAllApartmentRentalsForApartment/{_apartmentId}");
            
            dataGridViewWithFilterAndContextMenu1.SetData(apartmentRentals);


        }
    }
}
