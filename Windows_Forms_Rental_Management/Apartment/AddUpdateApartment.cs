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
    public partial class AddUpdateApartment : Form
    {
        public event EventHandler<int>? ApartmentAdded;
        int _apartmentId = -1; 
        enum FormMode
        {
            Add,
            Update
        }
        FormMode _formMode;
        public AddUpdateApartment()
        {
            InitializeComponent();
            _formMode = FormMode.Add;
            ConfigureFormBasedOnMode();
        }
        public AddUpdateApartment(int apartmentId)
        {
            InitializeComponent();
            _formMode = FormMode.Update;
            _apartmentId = apartmentId;
            ConfigureFormBasedOnMode();
        }

        void ConfigureFormBasedOnMode()
        {
            if (_formMode == FormMode.Update)
            {
                lblTitle.Text = "Update Apartment";
                this.Text = "Update Apartment";
                btnAddUpdate.Text = "Update";
                cbApartmentBuilding.Enabled = false; // Assuming you don't want to change the building when updating
            }
            else
            {
                lblTitle.Text = "Add Apartment";
                this.Text = "Add Apartment";
                btnAddUpdate.Text = "Add";
            }
        }

        async Task LoadApartmentForUpdate()
        {
            if (_apartmentId <= 0) return;
            string endpoint = $"Apartment/GetById/{_apartmentId}";
            var apartment = await Util.FetchSingleItemFromApiAsync<ApartmentDTO>(endpoint);
            if (apartment != null)
            {
                cbApartmentBuilding.SelectedValue = apartment.ApartmentBuildingId;
                txtName.Text = apartment.Name;
                nudFloorNO.Value = apartment.FloorNumber;
                nudNumberOfRooms.Value = apartment.NumberOfRooms;
                nudNumberOfBathrooms.Value = apartment.NumberOfBathrooms;
                nudSquaredMeters.Value = apartment.SquaredMeters;
            }
            else
            {
                MessageBox.Show("Apartment with this id not found.");
            }
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
            if (_formMode == FormMode.Update)
            {
                await LoadApartmentForUpdate();
            }

        }

        async Task LoadApartmentBuildingsComboBox()
        {
            string endpoint = $"Landlord/GetAllApartmentBuildingsIdAndNOForLandlord/{LocalLandlord.Id}";
            await Util.LoadComboBox<ApartmentBuildingIdAndNODTO>(cbApartmentBuilding, endpoint, "NO", "Id");
            
        }


        async void AddApartment()
        {

            int newApartmentId;
            var dto = new AddApartmentDTO
            {
                ApartmentBuildingId = Convert.ToInt32(cbApartmentBuilding.SelectedValue),
                Name = txtName.Text.Trim(),
                FloorNumber = (int)nudFloorNO.Value,
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
                    newApartmentId = id;
                    MessageBox.Show($"Added successfully with ID: {newApartmentId}");
                    ApartmentAdded?.Invoke(this, newApartmentId);
                }
                else
                {
                    MessageBox.Show("Added, but failed to get ID.");
                    return; 
                }
            }
            else
            {
                MessageBox.Show("Failed to add.");
                return; 
            }

            _formMode = FormMode.Update; // Change mode to Update after adding
            _apartmentId = newApartmentId;
            ConfigureFormBasedOnMode(); 


        }


        async void UpdateApartment()
        {
            var dto = new UpdateApartmentDTO
            {
                
                Name = txtName.Text.Trim(),
                FloorNumber = (int)nudFloorNO.Value,
                NumberOfRooms = (int)nudNumberOfRooms.Value,
                NumberOfBathrooms = (int)nudNumberOfBathrooms.Value,
                SquaredMeters = nudSquaredMeters.Value
            };



            
            HttpResponseMessage response = await Util.UpdateItemAsync<UpdateApartmentDTO>($"Apartment/Update/{_apartmentId}", dto);

            if (response.IsSuccessStatusCode)
                MessageBox.Show($"updated successfully");
            else
            {
                MessageBox.Show("Failed to update.");
            }
            Close();


        }
        private async void btnAdd_Click(object sender, EventArgs e)
        {

            if(_formMode == FormMode.Update)
            {
               UpdateApartment();
            }
            else
            {
                AddApartment();
            }

        }
    }
}
