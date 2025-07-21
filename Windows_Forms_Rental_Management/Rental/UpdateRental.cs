using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Windows_Forms_Rental_Management.Rental.UpdateRental;

namespace Windows_Forms_Rental_Management.Rental
{
    public partial class UpdateRental : Form
    {


        interface IUpdateRental
        {
            RentalType GetRentalType();
            int RentalId { get; }
        }
        public enum RentalType
        {
            Car,
            Apartment,
            Custom
        }

        int _rentalId;
       
        public UpdateRental(int rentalId,RentalType rentalType)
        {
            InitializeComponent();
            _rentalId=rentalId;

            var rb = groupBox2.Controls.OfType<RadioButton>()
            .FirstOrDefault(rb => rb.Text == rentalType.ToString());

            if (rb != null)
                rb.Checked = true;
            else
                throw new ArgumentException("Invalid rental type provided.", nameof(rentalType));


        }


        RentalType GetRentalType()
        {

            RentalType rentalType;
            var rb = groupBox2.Controls.OfType<RadioButton>()
                .FirstOrDefault(r => r.Checked);
            if (rb != null && Enum.TryParse(rb.Text, out rentalType))
                return rentalType;
            throw new InvalidOperationException("No rental type to get.");
        }


        private void UpdateRental_Load(object sender, EventArgs e)
        {

        }
    }
}
