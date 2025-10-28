using AutoMapper;
using Microsoft.Extensions.Logging;
using Rental_Management.Business.DTOs.Tenant;
using Rental_Management.Business.Interfaces;
using Rental_Management.Business.Entities;
using Rental_Management.Business.Interfaces.Repositories;
using Rental_Management.Business.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rental_Management.Business.Services
{
    public class TenantService : BaseService<Tenant, TenantDTO, AddTenantDTO, UpdateTenantDTO>, ITenantService
    {
        ITenantRepository _tenantRepository;
        public TenantService(ITenantRepository repository, ILogger<TenantService> logger, IMapper mapper)
            : base(repository, logger, mapper)
        {
            _tenantRepository = repository;
        }

        public OperationResultStatus AddPhones(ICollection<string> phones, int tenantId)
        {
            return _tenantRepository.AddPhones(phones, tenantId);
        }

        public ICollection<string> GetPhones(int tenantId)
        {
            return _tenantRepository.GetPhones(tenantId);
        }

        public override async Task<OperationResultStatus> UpdateAsync(UpdateTenantDTO dto)
        {

            if (dto == null)
            {
                _logger.LogWarning($"Invalid Update Tenant DTO");
                return OperationResultStatus.Failure;
            }
            var tenantToUpdate = await _tenantRepository.GetByIdAsync(dto.Id);
            if (tenantToUpdate == null)
            {
                _logger.LogWarning($"Tenant with ID {dto.Id} not found.");
                return OperationResultStatus.NotFound;
            }

            tenantToUpdate.Email = dto.Email;
            tenantToUpdate.Name = dto.Name;
            tenantToUpdate.NationalNumber = dto.NationalNumber;
            bool Cleared = _tenantRepository.ClearPhones(tenantToUpdate.Id).Result;
            tenantToUpdate.Phones = dto.Phones.Select(phone => new TenantPhone { PhoneNumber = phone }).ToList();


            if (!Cleared)
            {
                _logger.LogWarning($"Failed to clear phones for tenant with ID {dto.Id} for new update.");
                return OperationResultStatus.Failure;
            }
            return await _tenantRepository.UpdateAsync(tenantToUpdate);
        }
        public override async Task<int> AddAsync(AddTenantDTO dto)
        {
            if (dto == null)
            {
                _logger.LogWarning($"Invalid Add Tenant DTO");
                return -1;
            }

            var entity = new Tenant
            {
                Email = dto.Email,
                Name = dto.Name,
                NationalNumber = dto.NationalNumber,
                LandlordId = dto.LandlordId,
                Phones = dto.Phones.Select(phone => new TenantPhone { PhoneNumber = phone }).ToList(),
            };
            return await _repository.AddAsync(entity);
        }

        public decimal GetTotalPaidAmount(int tenantId)
        {
            return _tenantRepository.GetTotalPaidAmount(tenantId);
        }
    }
}
