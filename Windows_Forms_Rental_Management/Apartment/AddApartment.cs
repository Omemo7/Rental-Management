using Rental_Management.Business.DTOs.Apartment;
using Rental_Management.Business.DTOs.ApartmentBuilding;
using Rental_Management.Business.DTOs.Tenant;
using Rental_Management.Business.Interfaces;
using Rental_Management.Business.Services;
using Rental_Management.DataAccess.Entities;
using Shared.DTOs.ApartmentBuilding;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows_Forms_Rental_Management.ApartmentBuilding;

namespace Windows_Forms_Rental_Management
{
    public partial class AddApartment : Form
    {
        public event EventHandler<int>? ApartmentAdded;
        public AddApartment()
        {
            InitializeComponent();
        }

        private void btnAddApartmentBuilding_Click(object sender, EventArgs e)
        {
            AddApartmentBuilding form = new AddApartmentBuilding();
            form.ApartmentBuildingAdded += async (s, ApartmentBuildingId) =>
            {
                await LoadApartmentBuildingsComboBox();
            };
            form.ShowDialog();
            
        }
       
        private async void AddApartment_Load(object sender, EventArgs e)
        {
            await LoadApartmentBuildingsComboBox();

        }

        async Task LoadApartmentBuildingsComboBox()
        {
            var buildings = await Util.FetchAllDataFromApiAsync<ApartmentBuildingIdAndNODTO>($"Landlord/GetAllApartmentBuildingsIdAndNOForLandlord/{LocalLandlord.Id}");
            if (buildings != null)
            {
                cbApartmentBuilding.DataSource = buildings;
                cbApartmentBuilding.DisplayMember = "NO";
                cbApartmentBuilding.ValueMember = "Id";
            }
        }



        private async void btnAdd_Click(object sender, EventArgs e)
        {
            var dto = new AddApartmentDTO
            {
                ApartmentBuildingId = Convert.ToInt32(cbApartmentBuilding.SelectedValue),
                Name = txtName.Text.Trim(),
                FloorNumber =(int)nudFloorNO.Value,
                NumberOfRooms = (int)nudNumberOfRooms.Value,
                NumberOfBathrooms = (int)nudNumberOfBathrooms.Value,
                SquaredMeters = nudSquaredMeters.Value
            };




            HttpResponseMessage response = await LocalClientWithBaseAddress.client.PostAsJsonAsync("Apartment/Add", dto);

            if (response.IsSuccessStatusCode)
            {

                var location = response.Headers.Location?.ToString();

                if (location != null && int.TryParse(location.Split('/').Last(), out int id))
                {
                    MessageBox.Show($"Added successfully with ID: {id}");
                    ApartmentAdded?.Invoke(this, id);
                }
                else
                {
                    MessageBox.Show("Added, but failed to get ID.");
                }
            }
            else
            {
                MessageBox.Show("Failed to add.");
            }

            this.Close();
        
        }
    }
}
