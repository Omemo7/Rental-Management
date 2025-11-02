using Business.Application.Abstractions;
using Business.Application.Buildings.Commands;
using Business.Application.Buildings.Summaries;
using Business.Common;
using Business.Common.Errors;
using Business.Common.Pagination;
using RentalManagement.Business.Domain.Entities;
using RentalManagement.Business.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Application.Buildings
{
    public class BuildingService : IBuildingService
    {
        IBuildingRepository _buildingRepository;
        IUnitOfWork _unitOfWork;
        public BuildingService(IBuildingRepository buildingRepository, IUnitOfWork unitOfWork)
        {
            _buildingRepository = buildingRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Guid,Error>> AddAsync(AddBuildingCommand cmd)
        {
            var building = new Building(
                Guid.NewGuid(),
                cmd.Name,
                new Address(
                    cmd.Street,
                    cmd.Neighborhood,
                    cmd.City,
                    cmd.Country,
                    cmd.PostalCode
                )
            );

            return await Util.ResultReturnHandler(building.Id, _unitOfWork, async () =>
            {
                await _buildingRepository.AddAsync(building);
            });
            
        }

       
       
        public async Task<PaginatedResponse<BuildingSummary>> GetAllAsync(Guid LandlordId, PaginatedQuery query)
        {
            throw new NotImplementedException();
        }

        public async Task<Result<BuildingSummary,Error>> GetByIdAsync(Guid buildingId)
        {
            var building = await _buildingRepository.GetByIdAsync(buildingId);
            if (building == null) return Error.NotFound($"Building with ID {buildingId} not found.");

            return await Util.ResultReturnHandler(BuildingSummary.FromBuilding(building), _unitOfWork);
        }

        public Task<bool> RemoveAsync(Guid buildingId)
        {
            throw new NotImplementedException();
        }

        public async Task<Result<BuildingSummary, Error>> ChangeAddressAsync(ChangeAddressCommand cmd)
        {
            Building? building = await _buildingRepository.GetByIdAsync(cmd.BuildingId);
            if (building == null) return Error.NotFound($"Building with ID {cmd.BuildingId} not found.");

            building.ChangeAddress(new Address(
                cmd.Street,
                cmd.Neighborhood,
                cmd.City,
                cmd.Country,
                cmd.PostalCode
            ));
            return await Util.ResultReturnHandler(BuildingSummary.FromBuilding(building), _unitOfWork, () =>
            {
                _buildingRepository.Update(building);
            });
        }

        public async Task<Result<BuildingSummary, Error>> ChangeNameAsync(Guid buildingId, string newName)
        {
            Building? building = await _buildingRepository.GetByIdAsync(buildingId);
            if (building == null) return Error.NotFound($"Building with ID {buildingId} not found.");

            building.Rename(newName);
            return await Util.ResultReturnHandler(BuildingSummary.FromBuilding(building), _unitOfWork,() =>
            {
                _buildingRepository.Update(building);
            });
           
        }

        
        Task<Result<bool, Error>> IBuildingService.DeleteAsync(Guid buildingId)
        {
            throw new NotImplementedException();
        }
    }
}
