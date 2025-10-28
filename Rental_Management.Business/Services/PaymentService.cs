using AutoMapper;
using Microsoft.Extensions.Logging;
using Rental_Management.Business.DTOs.Payment;
using Rental_Management.Business.Interfaces;
using Rental_Management.Business.Entities;
using Rental_Management.Business.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rental_Management.Business.Services
{
    public class PaymentService:BaseService<Payment,PaymentDTO, AddPaymentDTO, UpdatePaymentDTO>, IPaymentService
    {
        private IPaymentRepository _paymentRepository;
        public PaymentService(IPaymentRepository repository,ILogger<PaymentService>logger,IMapper mapper) : base(repository,logger,mapper)
        {
           _paymentRepository = repository;
        }
    }
   
}
