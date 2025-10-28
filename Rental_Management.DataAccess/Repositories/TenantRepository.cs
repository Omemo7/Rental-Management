using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Rental_Management.Business.Entities;
using Rental_Management.Business.Interfaces.Repositories;
using Rental_Management.DataAccess.Migrations;
using Rental_Management.Business.Common;
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

        public decimal GetTotalPaidAmount(int tenantId)
        {

            if (_dbSet.Find(tenantId)==null)
            {
                _logger.LogWarning($"Invalid tenant: {tenantId}");
                return -1;
            }
            return _dbSet.Where(t=>t.Id == tenantId)
                .SelectMany(t => t.Rentals)
                .SelectMany(r=>r.Payments)
                .Sum(p=>p.PaidAmount);
        }
        public async Task<bool> ClearPhones(int tenantId)
        {
            try
            {
                var phones = await _context.TenantsPhones
        .Where(p => p.TenantId == tenantId)
        .ToListAsync();

                if (phones.Any())
                {
                    _context.TenantsPhones.RemoveRange(phones);
                    await _context.SaveChangesAsync();
                    _logger.LogInformation($"Phones removed successfully for tenant with ID {tenantId}.");
                    return true;
                }
                else
                {
                    _logger.LogWarning($"No phones found for tenant with ID {tenantId}.");
                    return false;


                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to remove phones for tenant with ID {tenantId}\n" +
                    $"Exception Message: {ex.Message}\n" +
                    $"Inner Exception: {ex.InnerException?.Message ?? "No inner exception"}");
                return false;
            }
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
