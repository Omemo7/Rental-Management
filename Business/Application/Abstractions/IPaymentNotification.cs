using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rental_Management.Business.Application.Abstractions
{
    public interface IPaymentNotification
    {
        public Task NotifyAllLandlords();
    }
}
