using Business.Common.Pagination;

namespace Business.Application.Abstractions;

public interface IRepository<TEntity> where TEntity : class
{
    Task<Guid> Add(TEntity entity);
    Task<TEntity?> GetById(Guid id);
    bool Update(TEntity entity);
    Task<bool> Delete(Guid id);

    Task<PaginatedResponse<TEntity>> GetAll(PaginatedQuery query);

}
