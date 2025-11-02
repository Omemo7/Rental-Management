using Business.Common.Pagination;

namespace Business.Application.Abstractions;

public interface IRepository<TEntity>:IReadRepository<TEntity> where TEntity : class
{
    Task<Guid> AddAsync(TEntity entity);
    Task<TEntity?> GetByIdAsync(Guid id);
    bool Update(TEntity entity);
    Task<bool> DeleteAsync(Guid id);

    

}
