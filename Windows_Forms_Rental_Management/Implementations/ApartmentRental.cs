using Rental_Management.Business.DTOs.Apartment;
using Rental_Management.Business.DTOs.ApartmentRental;
using Rental_Management.Business.DTOs.Rental;
using Rental_Management.Business.Entities;
using Rental_Management.Business.DTOs.Apartment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Windows_Forms_Rental_Management.Interfaces;
using static Windows_Forms_Rental_Management.Interfaces.IRentableForm;

namespace Windows_Forms_Rental_Management.Implementations
{
    public class ApartmentRental : IRentableForm
    {
        public async Task<int?> AddRental(RentalDTO dto, int ItemForRentId)
        {
            var apartmentDto = new AddApartmentRentalDTO
            {
                ApartmentId = ItemForRentId,
                Rental = dto
            };
            return await Util.AddItemAsync("ApartmentRental/Add", apartmentDto);
        }
        
        

       


        public RentalType GetRentalType()
        {
            return RentalType.Apartment;
        }

        public async Task LoadComboBoxItemForRent(ComboBox cb)
        {
            await Util.LoadComboBox<ApartmentIdAndNameDTO>(
    cb,
    $"Landlord/GetAllApartmentsIdAndNameForLandlord/{LocalLandlord.Id}",
    "Name",
    "Id");
        }

        public async Task OpenAddNewRentalItemForm(ComboBox cbItemForRent)
        {
            AddUpdateApartment addApartment = new AddUpdateApartment();
            addApartment.FormClosing += async (s, args) =>
            {
                await Util.LoadComboBox<ApartmentIdAndNameDTO>(
cbItemForRent,
$"Landlord/GetAllApartmentsIdAndNameForLandlord/{LocalLandlord.Id}",
"Name",
"Id");

            };
            addApartment.ShowDialog();
        }

        public Task SaveContractImages()
        {
            throw new NotImplementedException();
        }
    }
}
