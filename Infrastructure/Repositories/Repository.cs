using Business.Application.Abstractions;
using Business.Common.Pagination;
using Microsoft.EntityFrameworkCore;
using RentalManagement.Business.Domain.Entities;
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

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _db.Set<TEntity>().FindAsync(id);
            if (entity is null) return false;

            try
            {
                _db.Set<TEntity>().Remove(entity);
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
                
            return true;
        }

        public async Task<PaginatedResponse<TEntity>> GetAll(PaginatedQuery query)
        {
            var totalCount = await _db.Set<TEntity>().CountAsync();
            var items = await _db.Set<TEntity>()
                .Skip(query.Skip)
                .Take(query.PageSize)
                .ToListAsync();

            return new PaginatedResponse<TEntity>
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = query.PageNumber,
                PageSize = query.PageSize
            };
        }

        public async Task<TEntity?> GetById(Guid id)
        {
            return await _db.Set<TEntity>().FindAsync(id);
        }

        public bool Update(TEntity entity)
        {
            var entry = _db.Entry(entity);

            if (entry.State == EntityState.Detached)
                _db.Set<TEntity>().Attach(entity);

            entry.State = EntityState.Modified; 

            return true; 
        }

    }
}
