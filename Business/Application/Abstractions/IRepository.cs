namespace Business.Application.Abstractions;

public interface IRepository<TEntity> where TEntity : class
{
    Task<TEntity?> GetById(Guid id);
    Task Add(TEntity entity);
    Task Update(TEntity entity);
    Task Remove(Guid id);
}
