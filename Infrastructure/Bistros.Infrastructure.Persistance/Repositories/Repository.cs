using Bistros.Core.Application.Interfaces;
using Bistros.Infrastructure.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bistros.Infrastructure.Persistance.Repositories
{
	public class Repository<T> : IRepository<T> where T : class
	{
		private readonly BistrosContext _context;

		public Repository(BistrosContext context)
		{
			_context = context;
		}

		public async Task DeleteAsync(T t)
		{
			_context.Remove(t);
			await _context.SaveChangesAsync();
		}

		public async Task<T> GetByIdAsync(int id)
		{
			return await _context.Set<T>().FindAsync(id);
		}

		public async Task<List<T>> GetAllAsync()
		{
			return await _context.Set<T>().ToListAsync();
		}

		public async Task CreateAsync(T t)
		{
			await _context.AddAsync(t);
			await _context.SaveChangesAsync();
		}

		public async Task UpdateAsync(T t)
		{
			_context.Update(t);
			await _context.SaveChangesAsync();
		}

		public IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] includeProperties)
		{
			IQueryable<T> queryable = _context.Set<T>();
			return includeProperties.Aggregate(queryable,(current,includeProperty)=> current.Include(includeProperty));
		}
	}
}
