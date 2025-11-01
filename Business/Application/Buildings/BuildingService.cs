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
            try
            {
                await _buildingRepository.Add(building);
                await _unitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                return Error.BadRequest("An error occurred while adding the building: " + ex.Message);
            }

            return building.Id;
        }

        public Task<bool> ChangeAddressAsync(ChangeAddressCommand cmd)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ChangeNameAsync(Guid buildingId, string newName)
        {
            throw new NotImplementedException();
        }

        public Task<PaginatedResponse<BuildingSummary>> GetAllAsync(Guid LandlordId, PaginatedQuery query)
        {
            throw new NotImplementedException();
        }

        public async Task<Result<BuildingSummary,Error>> GetByIdAsync(Guid buildingId)
        {
            var building = await _buildingRepository.GetById(buildingId);
            if (building == null) return Error.NotFound($"Building with ID {buildingId} not found.");
            var bs = BuildingSummary.FromBuilding(building);
            return bs;
        }

        public Task<bool> RemoveAsync(Guid buildingId)
        {
            throw new NotImplementedException();
        }
    }
}
