using Microsoft.Extensions.Logging;
using Rental_Management.DataAccess.Entities;
using Rental_Management.DataAccess.Interfaces;

namespace Rental_Management.DataAccess.Repositories;

public class RentalRepository : Repository<Rental>, IRentalRepository
{
    public RentalRepository(ILogger<RentalRepository> logger, ApplicationDbContext context)
        : base(logger, context)
    {
    }
}
