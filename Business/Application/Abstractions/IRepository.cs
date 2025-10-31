namespace Business.Application.Abstractions;

public interface IRepository<TEntity> where TEntity : class
{
    Task<Guid> Add(TEntity entity);
    Task<TEntity?> GetById(Guid id);

}
