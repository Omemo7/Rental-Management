using Business.Common.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Application.Abstractions
{
    public interface IReadRepository<TEntity>
    where TEntity : class
    {
        Task<PaginatedResponse<TOut>> GetAllAsync<TOut>(
            PaginatedQuery query,
            Expression<Func<TEntity, bool>>? where = null,
            Expression<Func<TEntity, object>>? defaultSort = null,
            Dictionary<string, LambdaExpression>? sortMap = null,
            Expression<Func<TEntity, TOut>>? select = null,
            Func<IQueryable<TEntity>, IQueryable<TEntity>>? include = null);
    }
}
