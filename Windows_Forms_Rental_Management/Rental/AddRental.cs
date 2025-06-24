using Humanizer;
using NuGet.Configuration;
using Rental_Management.Business.DTOs.ApartmentRental;
using Rental_Management.Business.DTOs.Rental;
using Shared.DTOs.Apartment;
using Shared.DTOs.ApartmentBuilding;
using Shared.DTOs.RentPaymentFrequency;
using Shared.DTOs.Tenant;
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
using Windows_Forms_Rental_Management.Tenant;

namespace Windows_Forms_Rental_Management.Rental
{
    public partial class AddRental : Form
    {

        private string ContractImagesFolder = "C:\\Users\\Omsr\\Desktop\\f";
       
        public enum RentalType
        {
            Apartment,
            Car,
            Custom
        }

        public AddRental()
        {
            InitializeComponent();

            dtpStartDate.MinDate = DateTime.Now;
            dtpEndDate.MinDate = DateTime.Now.AddDays(1);
        }

        public AddRental(int itemId,RentalType chosenRentalType)
        {
            InitializeComponent();

            cbItemForRent.SelectedValue = itemId;
            cbItemForRent.Enabled = false;
            groupBox1.Enabled = false;  
            btnAddNewItem.Enabled = false;

            groupBox1.Controls.OfType<RadioButton>()
                .Where(rb => rb.Text == chosenRentalType.ToString())
                .ToList().ForEach(rb => rb.Checked = true);
        }


        private void SaveSelectedImagesOnRental(string rentalType,int rentalId)
        {
           
            string newRentalFolderPath = Path.Combine(ContractImagesFolder,rentalType,rentalId.ToString());

           
            if (!Directory.Exists(newRentalFolderPath))
            {
                Directory.CreateDirectory(newRentalFolderPath);
            }
        
           
            foreach (var sourcePath in openFileDialog1.FileNames)
            {
                string fileName = Path.GetFileName(sourcePath);
                string destinationPath = Path.Combine(newRentalFolderPath, fileName);
                try
                {
                    File.Copy(sourcePath, destinationPath, true);
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error copying file: {ex.Message}");
                }
            }
            MessageBox.Show($"Files copied successfully");

        }

        private void btnSelectImages_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Select Rental Contract Images";
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            openFileDialog1.Multiselect = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                string[] SelectedImages =openFileDialog1.FileNames.Select(x=>Path.GetFileName(x)).ToArray();


                lbContractImagesNames.Items.Clear();
                lbContractImagesNames.Items.AddRange(SelectedImages);
                lblSelectedImagesCount.Text = $"{SelectedImages.Length}";

            }
        }


        async Task LoadComboBoxesAsync()
        {


            await Util.LoadComboBox<ApartmentIdAndNameDTO>(
    cbItemForRent,
    $"Landlord/GetAllApartmentsIdAndNameForLandlord/{LocalLandlord.Id}",
    "Name",
    "Id");

            await Util.LoadComboBox<TenantIdAndNameDTO>(
                cbTenant,
                $"Landlord/GetAllTenantsIdAndNameForLandlord/{LocalLandlord.Id}",
                "Name",
                "Id");

            await Util.LoadComboBox<RentPaymentFrequencyWithIdDTO>(
                cbRentPaymentFrequency,
                "RentPaymentFrequency/GetRentPaymentFrequenciesWithId",
                "Frequency",
                "Id");

        }
        private async void AddRental_Load(object sender, EventArgs e)
        {

            await LoadComboBoxesAsync();


        }


      

        private async Task<int?> PostRentalAsync<T>(string url, T rentalDto)
        {
            var response = await LocalClientWithBaseAddress.client.PostAsJsonAsync(url, rentalDto);

            if (response.IsSuccessStatusCode)
            {
                var location = response.Headers.Location?.ToString();
                if (!string.IsNullOrEmpty(location) && int.TryParse(location.Split('/').Last(), out int id))
                {
                    return id;
                }
            }

            return null;
        }

        private RentalDTO CreateRentalDTO()
        {
            return new RentalDTO
            {
                StartDate = DateOnly.FromDateTime(dtpStartDate.Value),
                EndDate = DateOnly.FromDateTime(dtpEndDate.Value),
                RentPaymentFrequencyId = (int)cbRentPaymentFrequency.SelectedValue,
                TenantId = (int)cbTenant.SelectedValue,
                RentValue = nudRentValue.Value,
               
            };
        }


        private async void btnAdd_Click(object sender, EventArgs e)
        {
           
            if (dtpEndDate.Value <= dtpStartDate.Value)
            {
                MessageBox.Show("End date must be after start date.");
                return;
            }

            var selectedType = groupBox1.Controls
               .OfType<RadioButton>()
               .FirstOrDefault(rb => rb.Checked)?.Text;

            int selectedItemForRentId=(int)cbItemForRent.SelectedValue;


            var rentalDTO = CreateRentalDTO();

            int? rentalId = null;

            switch (selectedType)
            {
                case "Apartment":
                    var apartmentDto = new AddApartmentRentalDTO
                    {
                        ApartmentId =selectedItemForRentId ,
                        Rental = rentalDTO
                    };
                    rentalId = await PostRentalAsync("ApartmentRental/Add", apartmentDto);
                    
                    break;

                case "Car": throw new NotImplementedException("Car rental not implemented yet.");
                    //todo
                //    var carDto = new AddCarRentalDTO
                //    {
                //        CarId = selectedItemForRentId,
                //        Rental = rentalDTO
                //    };
                //    rentalId = await PostRentalAsync("CarRental/Add", carDto);
                //    break;

                case "Custom": throw new NotImplementedException("Custom rental not implemented yet.");
                    //    var customDto = new AddCustomRentalDTO
                    //    {
                    //        customItemID = selectedItemForRentId,
                    //        Rental = rentalDTO
                    //    };
                    //    rentalId = await PostRentalAsync("CustomRental/Add", customDto);
                    //    break;
            }

            if (rentalId.HasValue)
            {
                MessageBox.Show($"Added successfully with ID: {rentalId}");
                SaveSelectedImagesOnRental(selectedType, rentalId.Value);
            }
            else
            {
                MessageBox.Show("Failed to add rental or retrieve ID.");
            }

            this.Close();
        }


        private async void btnAddNewItem_Click(object sender, EventArgs e)
        {
            var checkedrb = groupBox1.Controls.OfType<RadioButton>().FirstOrDefault(rb => rb.Checked);

            switch (checkedrb?.Text)
            {
                case "Apartment":
                    AddApartment addApartment = new AddApartment();
                    addApartment.FormClosing += async (s, args) =>
                    {
                        await Util.LoadComboBox<ApartmentIdAndNameDTO>(
   cbItemForRent,
   $"Landlord/GetAllApartmentsIdAndNameForLandlord/{LocalLandlord.Id}",
   "Name",
   "Id");

                    };
                    addApartment.ShowDialog();
                    break;
                case "Car":
                    MessageBox.Show("Car rental not implemented yet.");
                    break;
                case "Custom":
                    MessageBox.Show("Car rental not implemented yet.");
                    break;
                default:
                    MessageBox.Show("Please select a rental type.");
                    return;
            }
        }

        private void btnAddTenant_Click(object sender, EventArgs e)
        {
            AddTenant addTenant = new AddTenant();
            addTenant.FormClosing += async (s, args) =>
            {
                await Util.LoadComboBox<TenantIdAndNameDTO>(
                    cbTenant,
                    $"Landlord/GetAllTenantsIdAndNameForLandlord/{LocalLandlord.Id}",
                    "Name",
                    "Id");
            };
            addTenant.ShowDialog();
        }

       
    }
}
