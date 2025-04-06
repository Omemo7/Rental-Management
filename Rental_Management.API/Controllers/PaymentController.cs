using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rental_Management.Business.DTOs.Payment;
using Rental_Management.Business.Interfaces;

namespace Rental_Management.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : BaseController<PaymentDTO,AddPaymentDTO,UpdatePaymentDTO>
    {
        private readonly IPaymentService _paymentService;
        public PaymentController(IPaymentService service) : base(service)
        {
            _paymentService = service;
        }
        
    }
}
