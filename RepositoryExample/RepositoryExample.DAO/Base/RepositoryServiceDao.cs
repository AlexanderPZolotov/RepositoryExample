using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RepositoryExample.DAO.Interfaces;
using RepositoryExample.DAO.Model;

namespace RepositoryExample.DAO.Base
{
	public abstract class RepositoryServiceDao<T> : IDisposable, IRepositoryServiceDAO<T> where T : BaseGuidIdTable
	{
		public DbContext _dbContext { get; set; }

		public virtual IQueryable<T> GetAll()
		{
			return  _dbContext.Set<T>().AsQueryable();
		}

		public async virtual Task<T> GetSingle(Guid id)
		{
			return await _dbContext.Set<T>().FirstAsync(i => i.Id == id);
		}

		public virtual async Task<T> Create(T entity, CancellationToken token = default)
		{
			var t = await _dbContext.Set<T>().AddAsync(entity, token);

			await _dbContext.SaveChangesAsync(token);

			return t.Entity;
		}

		public virtual Task<T> Update(T entity)
		{
			throw new NotImplementedException();
		}

		public virtual async Task Delete(Guid id)
		{
			_dbContext.Remove(GetSingle(id));

			await _dbContext.SaveChangesAsync();
		}

		public void Dispose()
		{
			_dbContext?.Dispose();
		}
	}
}
