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
        public AddPayment(int RentalId)
        {
            InitializeComponent();
            _rentalId = RentalId;
        }
    }
}
