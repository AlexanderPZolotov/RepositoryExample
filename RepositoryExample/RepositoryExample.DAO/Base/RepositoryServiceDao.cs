using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RepositoryExample.DAO.Interfaces;
using RepositoryExample.DAO.Model.Base;

namespace RepositoryExample.DAO.Base
{
	public abstract class RepositoryServiceDao<T> : IDisposable, IRepositoryServiceDao<T> where T : BaseGuidIdTable
	{
		public DbContext DataContext { get; set; }

		protected RepositoryServiceDao(DbContext context)
		{
			DataContext = context;
		}
		public virtual IQueryable<T> GetAll()
		{
			return  DataContext.Set<T>().AsQueryable();
		}

		public async virtual Task<T> GetSingle(Guid id)
		{
			return await DataContext.Set<T>().FirstAsync(i => i.Id == id);
		}

		public virtual async Task<T> Create(T entity, CancellationToken token = default)
		{
			var newEntity = await DataContext.Set<T>().AddAsync(entity, token);

			await DataContext.SaveChangesAsync(token);

			return newEntity.Entity;
		}

		public virtual Task<T> Update(T entity, CancellationToken token = default)
		{
			throw new NotImplementedException();
		}

		public virtual async Task Delete(Guid id, CancellationToken token = default)
		{
			DataContext.Remove(GetSingle(id));

			await DataContext.SaveChangesAsync(token);
		}

		public void Dispose()
		{
			DataContext?.Dispose();
		}
	}
}
