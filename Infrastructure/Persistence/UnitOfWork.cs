// Infrastructure/Persistence/UnitOfWork.cs
using Business.Application.Abstractions;


namespace RentalManagement.Infrastructure.Persistence;

public sealed class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _db;

    public UnitOfWork(AppDbContext db)
    {
        _db = db;
    }

    public Task<int> SaveChanges()
        => _db.SaveChangesAsync();
}
