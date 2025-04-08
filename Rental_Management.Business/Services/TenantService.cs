using AutoMapper;
using Microsoft.Extensions.Logging;
using Rental_Management.Business.DTOs.Tenant;
using Rental_Management.Business.Interfaces;
using Rental_Management.DataAccess.Entities;
using Rental_Management.DataAccess.Interfaces;
using Shared;
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
        public TenantService(ITenantRepository repository,ILogger<TenantService>logger,IMapper mapper) 
            : base(repository,logger,mapper)
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
    }
}
