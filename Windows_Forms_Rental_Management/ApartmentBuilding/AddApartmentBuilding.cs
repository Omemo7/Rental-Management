
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;

using Rental_Management.Business.DTOs.ApartmentBuilding;


namespace Windows_Forms_Rental_Management.ApartmentBuilding
{
    public partial class AddApartmentBuilding : Form
    {
       
        public event EventHandler<int>? ApartmentBuildingAdded;
        public AddApartmentBuilding()
        {
            InitializeComponent();
            
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {

            var dto = new AddApartmentBuildingDTO
            {
                BuildingNumber = txtBuildingNO.Text,
                StreetAddress = txtStreetAddress.Text,
                City = txtCity.Text,
                Neighborhood = txtNeighborhood.Text,
                landLordId = LocalLandlord.Id//todo,landlord local for now
            };

           


            HttpResponseMessage response = await LocalClientWithBaseAddress.client.PostAsJsonAsync("ApartmentBuilding/Add", dto);

            if (response.IsSuccessStatusCode)
            {
                
                var location = response.Headers.Location?.ToString();

                if (location != null && int.TryParse(location.Split('/').Last(), out int id))
                {
                    MessageBox.Show($"Added successfully with ID: {id}");
                    ApartmentBuildingAdded?.Invoke(this, id); 
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







