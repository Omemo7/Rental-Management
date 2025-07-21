using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Windows_Forms_Rental_Management.Payment
{
    public partial class AddPayment : Form
    {

        int _rentalId;
        decimal _rentValue;
        public AddPayment(int RentalId, decimal rentValue)
        {
            InitializeComponent();
            _rentalId = RentalId;
            _rentValue = rentValue;
        }

        private void AddPayment_Load(object sender, EventArgs e)
        {
            nudPaidAmount.Value = _rentValue;
        }
    }
}
