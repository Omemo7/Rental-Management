using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Rental_Management.Business.Interfaces.Repositories;
using Rental_Management.Business.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
namespace Rental_Management.DataAccess.Repositories
{
    public class Repository<T>:IRepository<T> where T : class
    {
        readonly protected ILogger<Repository<T>> _logger;
        readonly protected ApplicationDbContext _context;
        readonly protected DbSet<T> _dbSet;

        public Repository(ILogger<Repository<T>> logger,ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
            _dbSet = context.Set<T>();
        }
        public async Task<ICollection<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }
        public virtual async Task<T?> GetByIdAsync(int id)
        {
            
            return await _dbSet.FindAsync(id);
         
        }

        public virtual async Task<int> AddAsync(T entity)
        {
            try
            {
                await _dbSet.AddAsync(entity);
                await _context.SaveChangesAsync();

                
                var idProperty = typeof(T).GetProperty("Id");

                if (idProperty != null)
                {
                    var idValue = idProperty.GetValue(entity);
                    if (idValue is int id)
                    {
                        _logger.LogInformation("Added entity of type {0} successfully with ID {1}", typeof(T).Name, id);
                        return id;
                    }
                }

                _logger.LogWarning("Entity does not have an 'Id' property.");
                return -1;  
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to add entity of type {typeof(T).Name}\n" +
                                  $"Exception Message: {ex.Message}\n" +
                                  $"Inner Exception: {ex.InnerException?.Message ?? "No inner exception"}");

                return -1; 
            }
        }


        public virtual async Task<OperationResultStatus> UpdateAsync(T entity)
        {
            try
            {
                _context.Entry(entity).State = EntityState.Modified;
                int rowsAffected=await _context.SaveChangesAsync();
               
                _logger.LogInformation($"Updated entity of type {typeof(T).Name} successfully");
                return OperationResultStatus.Success;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to update entity of type {typeof(T).Name}\n" +
                   $" Exception Message: {ex.Message}\n" +
                   $" Inner Exception: {ex.InnerException?.Message ?? "No inner exception"}");
                return OperationResultStatus.Failure;
            }
        }
        public virtual async Task<OperationResultStatus> DeleteAsync(int id)
        {
            try
            {
                var entity = await GetByIdAsync(id);
                if (entity == null)
                {
                    _logger.LogWarning($"Entity of type {typeof(T).Name} with id {id} not found");
                    return OperationResultStatus.NotFound;
                }
                   
               
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
                _logger.LogInformation($"Deleted entity of type {typeof(T).Name} with id {id} successfully");
                return OperationResultStatus.Success;
            }
            catch(Exception ex)
            {
                _logger.LogError($"Failed to delete entity of type {typeof(T).Name}\n" +
                   $" Exception Message: {ex.Message}\n" +
                   $" Inner Exception: {ex.InnerException?.Message ?? "No inner exception"}");
                return OperationResultStatus.Failure;
            }
           

        }

        public virtual async Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate)
        {
             return await _dbSet.AnyAsync(predicate);
        }

       
    }
}
