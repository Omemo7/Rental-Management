using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rental_Management.Business.Interfaces
{
    public interface IPaymentNotification
    {
        public Task<OperationResultStatus> NotifyAllLandlords();
    }
}
