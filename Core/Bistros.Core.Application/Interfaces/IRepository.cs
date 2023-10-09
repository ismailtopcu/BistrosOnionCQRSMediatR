using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bistros.Core.Application.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task CreateAsync(T t);
        Task DeleteAsync(T t);
        Task UpdateAsync(T t);
        Task<T> GetByIdAsync(int id);
        Task<List<T>> GetAllAsync();
		IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] includeProperties);
	}
}
