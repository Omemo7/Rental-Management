using Humanizer;
using NuGet.Configuration;
using Rental_Management.Business.DTOs.Apartment;
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
using Windows_Forms_Rental_Management.Implementations;
using Windows_Forms_Rental_Management.Interfaces;
using Windows_Forms_Rental_Management.Tenant;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using RadioButton = System.Windows.Forms.RadioButton;

namespace Windows_Forms_Rental_Management.Rental
{
    public partial class AddRental : Form
    {
        
      
        private string ContractImagesFolder = "C:\\Users\\Omsr\\Desktop\\f";
        int _rentalId = -1;
        IRentableForm _rental = new ApartmentRental();
        public enum RentalType
        {
            Apartment,
            Car,
            Custom
        }


        private AddRental()
        {
            InitializeComponent();

            foreach (RadioButton rb in groupBox1.Controls.OfType<RadioButton>())
            {
                rb.CheckedChanged += RadioButton_CheckedChanged;
            }


        }

        private void RadioButton_CheckedChanged(object? sender, EventArgs e)
        {
            var rb = sender as RadioButton;
            if (rb != null && rb.Checked)
            {
                if (rb.Text == RentalType.Apartment.ToString())
                {
                    _rental = new ApartmentRental();

                }
                else if (rb.Text == RentalType.Car.ToString())
                {
                  MessageBox.Show("Car rental is not implemented yet.");
                  rbApartment.Checked = true; // Reset to Apartment if Car is selected
                }
                else if (rb.Text == RentalType.Custom.ToString())
                {
                    MessageBox.Show("Custom rental is not implemented yet.");
                    rbApartment.Checked = true; // Reset to Apartment if Car is selected
                }
                _rental.LoadComboBoxItemForRent(cbItemForRent);
            }

        }

        public static async Task<AddRental> CreateAsync(
            IRentableForm? rentalType=null,
    int? tenantId = null,
    int? itemId = null)
        {

            
            var form = new AddRental();

            if (rentalType != null)
            {

                var rb = form.groupBox1.Controls.OfType<RadioButton>()
                    .FirstOrDefault(rb => rb.Text == rentalType.GetRentalType().ToString());
                if (rb != null)
                    rb.Checked = true;
                else
                    throw new ArgumentException("Invalid rental type provided.", nameof(rentalType));


            }
            
            await form.LoadComboBoxesAsync();


            if (tenantId.HasValue)
            {
                form.cbTenant.SelectedValue = tenantId.Value;
                form.cbTenant.Enabled = false;
            }

            if (itemId.HasValue)
            {
                form.cbItemForRent.SelectedValue = itemId.Value;
                form.cbItemForRent.Enabled = false;
                form.groupBox1.Enabled = false;
                form.btnAddNewItem.Enabled = false;

                
            }

            return form;
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


            await _rental.LoadComboBoxItemForRent(cbItemForRent);

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
        private void AddRental_Load(object sender, EventArgs e)
        {
            dtpStartDate.MinDate = DateTime.Now;
            dtpEndDate.MinDate = DateTime.Now.AddDays(1);
            


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
                IsActive = true 

            };
        }


        private async void btnAdd_Click(object sender, EventArgs e)
        {
           
            if (dtpEndDate.Value <= dtpStartDate.Value)
            {
                MessageBox.Show("End date must be after start date.");
                return;
            }

            var rentalDTO = CreateRentalDTO();
            var selectedItemIdForRent = (int)cbItemForRent.SelectedValue;

            int? rentalId =await _rental.AddRental(rentalDTO,selectedItemIdForRent);



            if (rentalId.HasValue)
            {
                MessageBox.Show($"Added successfully with ID: {rentalId}");

                if (lbContractImagesNames.Items.Count > 0)
                {
                    //todo, convert this to a method in the interface
                    //SaveSelectedImagesOnRental(selectedType, rentalId.Value);
                    await _rental.SaveContractImages();
                }
                else
                {
                    MessageBox.Show("No images selected. Rental added without images.");
                }
                
            }
            else
            {
                MessageBox.Show("Failed to add rental or retrieve ID.");
            }

            this.Close();
        }


        private async void btnAddNewItem_Click(object sender, EventArgs e)
        {
            
            await _rental.OpenAddNewRentalItemForm(cbItemForRent);

        }

        private void btnAddTenant_Click(object sender, EventArgs e)
        {
            AddUpdateTenant addTenant = new AddUpdateTenant();
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
