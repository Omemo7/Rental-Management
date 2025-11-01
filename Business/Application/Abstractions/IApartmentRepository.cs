using RentalManagement.Business.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Application.Abstractions
{
    public interface IApartmentRepository: IRepository<Apartment>
    {
    }
}
