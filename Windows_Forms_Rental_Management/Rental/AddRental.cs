using Rental_Management.Business.DTOs.ApartmentRental;
using Shared.DTOs.Apartment;
using Shared.DTOs.ApartmentBuilding;
using Shared.DTOs.Tenant;
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

namespace Windows_Forms_Rental_Management.Rental
{
    public partial class AddRental : Form
    {

        private string ContractImagesFolder;


        public AddRental()
        {
            InitializeComponent();
        }


        private void SaveSelectedImages()
        {
            foreach (var sourcePath in openFileDialog1.FileNames)
            {
                string fileName = Path.GetFileName(sourcePath);
                string destinationPath = Path.Combine(ContractImagesFolder, fileName);
                try
                {
                    File.Copy(sourcePath, destinationPath, true);
                    MessageBox.Show($"File copied to: {destinationPath}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error copying file: {ex.Message}");
                }
            }


        }

        private void btnSelectImages_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Select Rental Contract Images";
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            openFileDialog1.Multiselect = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                string[] SelectedImages = openFileDialog1.FileNames;


                lbContractPaths.Items.Clear();
                lbContractPaths.Items.AddRange(SelectedImages);

            }
        }
       
        async Task LoadApartmentsAndTenantsComboBoxesAsync()
        {
            var apartments = await Util.FetchAllDataFromApiAsync<ApartmentIdAndNameDTO>($"Landlord/GetAllApartmentsIdAndNameForLandlord/{LocalLandlord.Id}");
            if (apartments != null)
            {
                cbItemForRent.DataSource = apartments;
                cbItemForRent.DisplayMember = "Name";
                cbItemForRent.ValueMember = "Id";
            }


            var tenants = await Util.FetchAllDataFromApiAsync<TenantIdAndNameDTO>($"Landlord/GetAllTenantsIdAndNameForLandlord/{LocalLandlord.Id}");
            if (tenants != null)
            {
                cbTenant.DataSource = tenants;
                cbTenant.DisplayMember = "Name";
                cbTenant.ValueMember = "Id";
            }
        }
        private async void AddRental_Load(object sender, EventArgs e)
        {

            await LoadApartmentsAndTenantsComboBoxesAsync();

           
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddApartmentRentalDTO dto = new AddApartmentRentalDTO
            {
               // ApartmentId = Convert.ToInt32(txtApartmentId.Text),
            };
        }
    }
}
