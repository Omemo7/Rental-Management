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
using Rental_Management.Business.Entities;
using Windows_Forms_Rental_Management.Rental;

namespace Windows_Forms_Rental_Management.Tenant
{
    public partial class ShowAllTenants : Form
    {

        public enum ContextMenuItemsEnum
        {
            [Description("Add rental")]
            AddRental,

            [Description("Edit")]
            Edit,

            [Description("Delete")]
            Delete,

            [Description("More details")]
            MoreDetails
        }

        public ShowAllTenants()
        {
            InitializeComponent();
        }

        private async void ShowAllTenants_Load(object sender, EventArgs e)
        {

            dataGridViewWithFilterAndContextMenu1.SetContextMenuItems<ContextMenuItemsEnum>();
            dataGridViewWithFilterAndContextMenu1.SetData(await Util.FetchAllDataFromApiAsync<TenantDTO>($"Landlord/GetAllTenantsForLandlord/{LocalLandlord.Id}"));
        }

        private async void dataGridViewWithFilterAndContextMenu1_ContextMenuItemClicked(object sender, Windows_Forms_Rental_Management.DataGridViewWithFilterAndContextMenu.ContextMenuItemClickedEventArgs e)
        {
            switch (e.ClickedItem)
            {
                case ContextMenuItemsEnum.AddRental:
                    AddRental form = await AddRental.CreateAsync(tenantId:e.RecordId);
                    form.ShowDialog();
                    break;
                case ContextMenuItemsEnum.Edit:
                    AddUpdateTenant frm = new AddUpdateTenant(e.RecordId);
                    frm.FormClosed +=async (s,e)=>
                    {
                        dataGridViewWithFilterAndContextMenu1.SetData(await Util.FetchAllDataFromApiAsync<TenantDTO>($"Landlord/GetAllTenantsForLandlord/{LocalLandlord.Id}"));
                    };
                    frm.ShowDialog();
                    break;

                case ContextMenuItemsEnum.Delete:
                    await DeleteTenantWithPones(e.RecordId);
                    break;
                case ContextMenuItemsEnum.MoreDetails:
                    TenantDetails detailsForm = new TenantDetails(e.RecordId);
                    detailsForm.ShowDialog();
                    break;


            }
        }


        async Task DeleteTenantWithPones(int tenantId)
        {
            if (MessageBox.Show("Are you sure you want to delete this tenant with all phones?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                var response = await Util.DeleteItemAsync($"Tenant/Delete/{tenantId}");
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Tenant deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridViewWithFilterAndContextMenu1.SetData(await Util.FetchAllDataFromApiAsync<TenantDTO>($"Landlord/GetAllTenantsForLandlord/{LocalLandlord.Id}"));
                }
                else
                {
                    MessageBox.Show("Failed to delete tenant.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        
    }
}
