using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Shared;

namespace Rental_Management.DataAccess.Interfaces
{
    public interface IRepository<T> where T:class
    {
        Task<T?> GetByIdAsync(int id);
        Task<int> AddAsync(T entity);
        Task<OperationResultStatus> UpdateAsync(T entity);
        Task<OperationResultStatus> DeleteAsync(int id);
        Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate);
    }
}
