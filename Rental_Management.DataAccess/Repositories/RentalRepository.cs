using Microsoft.Extensions.Logging;
using Rental_Management.Business.Entities;
using Rental_Management.Business.Interfaces.Repositories;

namespace Rental_Management.DataAccess.Repositories;

public class RentalRepository : Repository<Rental>, IRentalRepository
{
    public RentalRepository(ILogger<RentalRepository> logger, ApplicationDbContext context)
        : base(logger, context)
    {
    }
}
