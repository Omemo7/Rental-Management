using Rental_Management.Business.Common;
using System.Threading.Tasks;

namespace Rental_Management.Business.Interfaces;

public interface IPaymentNotification
{
    Task NotifyAllLandlords();
}
