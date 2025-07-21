using Shared.DTOs.ApartmentRental;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Windows_Forms_Rental_Management.Tenant
{
    public partial class TenantDetails : Form
    {

        int _tenantId;
        public TenantDetails(int tenantId)
        {
            InitializeComponent();
            _tenantId=tenantId;
        }

        private async void TenantDetails_Load(object sender, EventArgs e)
        {
            nudProfitFromTenant.Value=await Util.FetchSingleItemFromApiAsync<decimal>($"Tenant/GetTotalPaidAmount/{_tenantId}");
            dataGridViewWithFilterAndContextMenu1.SetData(await Util.FetchAllDataFromApiAsync<ApartmentRentalDTOForTenant>($"ApartmentRental/GetAllApartmentRentalsForTenant/{_tenantId}"));
            var phones = await Util.FetchAllDataFromApiAsync<string>($"Tenant/GetPhones/{_tenantId}");
            if (phones != null)
                lbPhones.Items.AddRange(phones.ToArray());

        }
    }
}
