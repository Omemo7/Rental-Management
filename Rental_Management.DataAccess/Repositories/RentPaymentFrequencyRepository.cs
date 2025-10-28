using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Rental_Management.Business.Entities;
using Rental_Management.Business.Interfaces.Repositories;
using System;
using System.Collections.Generic;

namespace Rental_Management.DataAccess.Repositories;

public class RentPaymentFrequencyRepository : IRentPaymentFrequencyRepository
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<RentPaymentFrequencyRepository> _logger;

    public RentPaymentFrequencyRepository(ApplicationDbContext context, ILogger<RentPaymentFrequencyRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<List<RentPaymentFrequency>> GetRentPaymentFrequenciesAsync()
    {
        try
        {
            return await _context.RentPaymentFrequency.ToListAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to load rent payment frequencies");
            return new List<RentPaymentFrequency>();
        }
    }
}
