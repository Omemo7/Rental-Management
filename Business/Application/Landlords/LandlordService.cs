using Business.Application.Abstractions;
using Business.Application.Landlords.Commands;
using Business.Application.Landlords.Summaries;
using Business.Common;
using Business.Common.Errors;
using RentalManagement.Business.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Business.Application.Landlords
{
    public class LandlordService : ILandlordService
    {
        private readonly IIdentityService _identity;
        private readonly ILandlordRepository _landlordsRepo;
        private readonly IUnitOfWork _uow;

        public LandlordService(
            IIdentityService identity,
            ILandlordRepository landlords,
            IUnitOfWork uow)
        {
            _identity = identity;
            _landlordsRepo = landlords;
            _uow = uow;
        }

      
        public async Task<Result<Guid, Error>> AddAsync(AddLandlordCommand cmd)
        {
            var userId = await _identity.CreateUser(cmd.Email, cmd.Password);
            var landlord = new Landlord(userId, cmd.FirstName, cmd.LastName);
            return await Util.ResultReturnHandler(landlord.Id, _uow, async () =>
            {
                await _landlordsRepo.AddAsync(landlord);
            });
        }

       



        public async Task<Result<LandlordSummary, Error>> GetByIdAsync(Guid id)
        {
            var landlord = await _landlordsRepo.GetByIdAsync(id);
            if (landlord == null) return Error.NotFound("Landlord with this ID does not exist.");

            return await Util.ResultReturnHandler(LandlordSummary.FromLandlord(landlord));
        }

        public async Task<Result<LandlordSummary, Error>> UpdateAsync(UpdateLandlordCommand cmd)
        {
            var landlord = await _landlordsRepo.GetByIdAsync(cmd.Id);
            if (landlord == null) return Error.NotFound("Landlord with this ID does not exist.");

            landlord.ChangeFullName(cmd.FirstName, cmd.LastName);

            return await Util.ResultReturnHandler(LandlordSummary.FromLandlord(landlord),_uow,()=>_landlordsRepo.Update(landlord));
        }
    }
}
