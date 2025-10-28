using Rental_Management.Business.DTOs.Apartment;
using Rental_Management.Business.DTOs.Tenant;
using Rental_Management.Business.Entities;
using Rental_Management.Business.DTOs.Tenant;
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
    public partial class AddUpdateTenant : Form
    {
        public event EventHandler<int>? TenantAdded;
        int _tenantId = -1; 
        enum FormMode
        {
            Add,
            Update
        }

        FormMode _formMode;
        public AddUpdateTenant()
        {
            InitializeComponent();
            _formMode = FormMode.Add;
            ConfigureFormBasedOnMode();


        }

        public AddUpdateTenant(int tenantId)
        {
            InitializeComponent();
            _formMode = FormMode.Update;
            _tenantId = tenantId;
            ConfigureFormBasedOnMode();
        }

        void ConfigureFormBasedOnMode()
        {
            if (_formMode == FormMode.Update)
            {
                lblTitle.Text = "Update Tenant";
                this.Text = "Update Tenant";
                btnAddUpdate.Text = "Update";
            }
            else
            {
                lblTitle.Text = "Add Tenant";
                this.Text = "Add Tenant";
                btnAddUpdate.Text = "Add";
            }
        }

        async Task LoadTenantForUpdate()
        {
            if (_tenantId <= 0) return;
            string endpoint = $"Tenant/GetById/{_tenantId}";
            string phonesEndpoint = $"Tenant/GetPhones/{_tenantId}";
            var tenant = await Util.FetchSingleItemFromApiAsync<TenantDTO>(endpoint);
            var phones = await Util.FetchAllDataFromApiAsync<string>(phonesEndpoint);
            if (tenant != null)
            {
                txtName.Text = tenant.Name;
                txtEmail.Text = tenant.Email;
                txtNationalNO.Text = tenant.NationalNumber;
                if (phones != null && phones.Count > 0)
                    lbPhones.Items.AddRange(phones.ToArray());
                
            }
            else
            {
                MessageBox.Show("Tenant with this ID was not found.");
            }
        }
        async Task AddTenant()
        {
            var dto = new AddTenantDTO
            {
                Email = txtEmail.Text.Trim(),
                LandlordId = LocalLandlord.Id, //todo
                Name = txtName.Text.Trim(),
                NationalNumber = txtNationalNO.Text.Trim(),
                Phones = lbPhones.Items.Cast<string>().Select(phone => phone.Trim()).ToList()
            };




            HttpResponseMessage response = await LocalClientWithBaseAddress.client.PostAsJsonAsync("Tenant/Add", dto);

            if (response.IsSuccessStatusCode)
            {

                var location = response.Headers.Location?.ToString();

                if (location != null && int.TryParse(location.Split('/').Last(), out int id))
                {
                    MessageBox.Show($"Added successfully with ID: {id}");
                    TenantAdded?.Invoke(this, id);
                    _tenantId = id;
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
            _formMode = FormMode.Update;
            ConfigureFormBasedOnMode();
        }

        async Task UpdateTenant()
        {
            var dto = new UpdateTenantDTO
            {
                Email = txtEmail.Text.Trim(),
                Name = txtName.Text.Trim(),
                NationalNumber = txtNationalNO.Text.Trim(),
                Phones = lbPhones.Items.Cast<string>().Select(phone => phone.Trim()).ToList()
            };

            HttpResponseMessage response = await Util.UpdateItemAsync<UpdateTenantDTO>($"Tenant/Update/{_tenantId}", dto);

            if (response.IsSuccessStatusCode)
                MessageBox.Show("Updated successfully");
            else
                MessageBox.Show("Failed to update.");

        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (_formMode == FormMode.Update)
                UpdateTenant();
            else
                AddTenant();
        }

        private async void AddTenant_Load(object sender, EventArgs e)
        {
            if (_formMode == FormMode.Update)
            {
                await LoadTenantForUpdate();
            }
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
