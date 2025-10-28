using Microsoft.Extensions.Logging;
using Rental_Management.Business.Entities;
using Rental_Management.Business.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rental_Management.DataAccess.Repositories
{
    public class PaymentRepository:Repository<Payment>, IPaymentRepository
    {

        public PaymentRepository(ILogger<PaymentRepository> logger, ApplicationDbContext context) : base(logger, context)
        {

        }
       
    }
}
