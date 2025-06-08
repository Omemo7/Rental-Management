using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Rental_Management.DataAccess.Entities;
using Rental_Management.DataAccess.Interfaces;
using Rental_Management.DataAccess.Migrations;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rental_Management.DataAccess.Repositories
{
    public class TenantRepository:Repository<Tenant>, ITenantRepository
    {
        public TenantRepository(ILogger<TenantRepository>logger,ApplicationDbContext context) : base(logger,context)
        {
           
        }
        public ICollection<string> GetPhones(int tenantId)
        {
            var tenant = _context.Tenants.Include(t=>t.Phones).FirstOrDefault(t => t.Id == tenantId);
            if(tenant == null)
            {
                _logger.LogWarning($"Tenant with ID {tenantId} not found.");
                return new List<string>();
            }

            if(tenant.Phones == null || !tenant.Phones.Any())
            {
                _logger.LogWarning($"No phones found for tenant with ID {tenantId}.");
                return new List<string>();
            }
            return tenant.Phones.Select(p=>p.PhoneNumber).ToList();
        }
        
        public OperationResultStatus AddPhones(ICollection<string> phones, int tenantId)
        {
            try
            {
                var tenant = _context.Tenants.FirstOrDefault(t => t.Id == tenantId);
                if (tenant == null)
                {
                    _logger.LogWarning($"Tenant with ID {tenantId} not found.");
                    return OperationResultStatus.NotFound;
                }

                var newPhones = phones.Select(p => new TenantPhone
                {
                    PhoneNumber = p,
                    TenantId = tenantId
                }).ToList();

                _context.TenantsPhones.AddRange(newPhones);
                _context.SaveChanges();

                _logger.LogInformation($"Phones added successfully for tenant with ID {tenantId}.");
                return OperationResultStatus.Success;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to add phones for tenant with ID {tenantId}\n" +
                    $"Exception Message: {ex.Message}\n" +
                    $"Inner Exception: {ex.InnerException?.Message ?? "No inner exception"}");
                return OperationResultStatus.Failure;
            }
        }


    }
}
