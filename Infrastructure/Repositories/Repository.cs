using Business.Application.Abstractions;
using RentalManagement.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        AppDbContext _db;
        public Repository(AppDbContext db)
        {
            _db = db;
        }
        public async Task<Guid> Add(TEntity entity)
        {
            await _db.Set<TEntity>().AddAsync(entity);

           
            var idProp = typeof(TEntity).GetProperty("Id");
            if (idProp is null)
                throw new InvalidOperationException($"{typeof(TEntity).Name} must have an Id property.");

            var value = idProp.GetValue(entity);
            if (value is not Guid id)
                throw new InvalidOperationException("Id property must be a Guid.");

            return id;
        }

        public async Task<TEntity?> GetById(Guid id)
        {
            return await _db.Set<TEntity>().FindAsync(id);
        }
    }
}
