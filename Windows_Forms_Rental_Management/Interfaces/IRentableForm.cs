using Rental_Management.Business.DTOs.Rental;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Windows_Forms_Rental_Management.Interfaces
{
    public interface IRentableForm
    {
        public enum RentalType
        {
            Apartment,
            Car,
            Custom
        }
        RentalType GetRentalType();
        Task<int?>AddRental(RentalDTO dto ,int ItemForRentId);
        Task LoadComboBoxItemForRent(ComboBox cb);
        Task SaveContractImages();
        Task OpenAddNewRentalItemForm(ComboBox cbToRefresh);
    }
}
