using Rental_Management.Business.DTOs.Apartment;
using Rental_Management.Business.DTOs.Tenant;
using Rental_Management.DataAccess.Entities;
using Shared.DTOs.Tenant;
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

namespace Windows_Forms_Rental_Management.Tenant
{
    public partial class AddTenant : Form
    {
        public event EventHandler<int>? TenantAdded;
        public AddTenant()
        {
            InitializeComponent();
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            var dto = new AddTenantDTO
            {
                Email = txtEmail.Text.Trim(),
                LandlordId = LocalLandlord.Id, //todo
                Name = txtName.Text.Trim(),
                NationalNumber = txtNationalNO.Text.Trim(),
                Phones = lbPhones.Items.Cast<string>().Select(phone=>new TenantPhoneDTO { PhoneNumber= phone.Trim() }).ToList() 
            };
           



            HttpResponseMessage response = await LocalClientWithBaseAddress.client.PostAsJsonAsync("Tenant/Add", dto);

            if (response.IsSuccessStatusCode)
            {

                var location = response.Headers.Location?.ToString();

                if (location != null && int.TryParse(location.Split('/').Last(), out int id))
                {
                    MessageBox.Show($"Added successfully with ID: {id}");
                    TenantAdded?.Invoke(this, id);
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

        private void AddTenant_Load(object sender, EventArgs e)
        {

        }

        private void AddPhone_Click(object sender, EventArgs e)
        {
            string phone = txtPhone.Text.Trim();

            if (string.IsNullOrEmpty(phone))
            {
                MessageBox.Show("Please enter a phone number.");
                return;
            }



            if (lbPhones.Items.Contains(phone))
            {
                MessageBox.Show("This phone number is already added.");
                return;
            }

            lbPhones.Items.Add(phone);
            txtPhone.Clear();
            txtPhone.Focus();
        }

        private void RemovePhone_Click(object sender, EventArgs e)
        {
            if (lbPhones.SelectedItem != null)
            {
                lbPhones.Items.Remove(lbPhones.SelectedItem);
            }
            else
            {
                MessageBox.Show("Please select a phone number to remove.");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lbPhones.Items.Clear();
        }
    }
}
