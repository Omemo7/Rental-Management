using Windows_Forms_Rental_Management.Apartment;
using Windows_Forms_Rental_Management.Rental;
using Windows_Forms_Rental_Management.Tenant;

namespace Windows_Forms_Rental_Management
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void apartmentsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }





        private void addToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            AddUpdateApartment form = new AddUpdateApartment();
            form.ShowDialog();
        }

        private void showAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowAllApartments form = new ShowAllApartments();
            form.ShowDialog();
        }

        private void addToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AddUpdateTenant form = new AddUpdateTenant();
            form.ShowDialog();
        }

        private void showAllTenantsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowAllTenants form = new ShowAllTenants();
            form.ShowDialog();
        }

        private async void addToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            AddRental form = await AddRental.CreateAsync();
            form.ShowDialog();
        }

        private void updateToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ShowAllRentals form = new ShowAllRentals();
            form.ShowDialog();
        }
    }
}
