using Business.Application.Landlords.Commands;
using RentalManagement.Business.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Application.Landlords
{
    public interface ILandlordService
    {
        public Task<Guid> Add(AddLandlordCommand cmd);
        public Task<Landlord> GetById(Guid id);

    }
}
