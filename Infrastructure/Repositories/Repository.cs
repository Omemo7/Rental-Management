using Business.Application.Abstractions;
using Business.Common.Pagination;
using Microsoft.EntityFrameworkCore;
using RentalManagement.Business.Domain.Entities;
using RentalManagement.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
        public async Task<Guid> AddAsync(TEntity entity)
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

        public async Task<bool> DeleteAsync(Guid id)
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

        public async Task<PaginatedResponse<TEntity>> GetAllAsync(PaginatedQuery query)
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

        public async Task<PaginatedResponse<TOut>> GetAllAsync<TOut>(
      PaginatedQuery p,
      Expression<Func<TEntity, bool>>? where = null,
      Expression<Func<TEntity, object>>? defaultSort = null,
      Dictionary<string, LambdaExpression>? sortMap = null,
      Expression<Func<TEntity, TOut>>? select = null,
      Func<IQueryable<TEntity>, IQueryable<TEntity>>? include = null)
        {
            var page = Math.Max(1, p.PageNumber);
            var size = Math.Clamp(p.PageSize, 1, 100);

            IQueryable<TEntity> q = _db.Set<TEntity>().AsNoTracking();

            if (include is not null) q = include(q);
            if (where is not null) q = q.Where(where);

            // Search (optional): if you want repo to do it, pass a predicate via 'where' that closes over p.Search.
            // Or keep search entirely in service; both are fine.

            // Sort
            if (!string.IsNullOrWhiteSpace(p.SortBy) && sortMap != null && sortMap.TryGetValue(p.SortBy, out var keySel))
            {
                q = ApplyOrder(q, keySel, p.Descending);
            }
            else if (defaultSort is not null)
            {
                q = p.Descending ? q.OrderByDescending(defaultSort) : q.OrderBy(defaultSort);
            }

            var total = await q.CountAsync();

            // Project
            if (select is null)
            {
                // If caller didn’t specify projection, use identity cast.
                // This will throw at runtime if TOut != TEntity, by design.
                var itemsRaw = await q.Skip((page - 1) * size).Take(size).Cast<object>().ToListAsync();
                var items = itemsRaw.Cast<TOut>().ToList();
                return PaginatedResponse<TOut>.Create(items, total, page, size);
            }
            else
            {
                var items = await q.Skip((page - 1) * size).Take(size).Select(select).ToListAsync();
                return PaginatedResponse<TOut>.Create(items, total, page, size);
            }
        }
        private static IQueryable<TEntity> ApplyOrder(IQueryable<TEntity> source, LambdaExpression keySelector, bool desc)
        {
            var method = desc ? nameof(Queryable.OrderByDescending) : nameof(Queryable.OrderBy);
            var call = Expression.Call(
                typeof(Queryable),
                method,
                new[] { typeof(TEntity), keySelector.Body.Type },
                source.Expression,
                Expression.Quote(keySelector));

            return source.Provider.CreateQuery<TEntity>(call);
        }

        public async Task<TEntity?> GetByIdAsync(Guid id)
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
