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
using Rental_Management.Business.DTOs.Tenant;
using Rental_Management.DataAccess.Entities;

namespace Windows_Forms_Rental_Management.Tenant
{
    public partial class ShowAllTenants : Form
    {
        public ShowAllTenants()
        {
            InitializeComponent();
        }
        
        private async void ShowAllTenants_Load(object sender, EventArgs e)
        {
            
            dataGridViewWithFilterAndContextMenu1.SetData(await Util.FetchAllDataFromApiAsync<TenantDTO>($"Landlord/GetAllTenantsForLandlord/{LocalLandlord.Id}"));
        }
    }
}
