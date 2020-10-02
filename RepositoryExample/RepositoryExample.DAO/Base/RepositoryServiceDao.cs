using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RepositoryExample.DAO.DbConnections;
using RepositoryExample.DAO.Interfaces;
using RepositoryExample.DAO.Model.Base;
using RepositoryExample.DAO.Utilites;

namespace RepositoryExample.DAO.Base
{
	/// <summary>
	/// Abstraction for repository service classes.
	/// Example of "Unit of Work" Pattern
	/// </summary>
	/// <typeparam name="T">Repository table class</typeparam>
	public abstract class RepositoryServiceDao<T> : IDisposable, IRepositoryServiceDao<T> where T : BaseGuidIdTable
	{
		public DbContext DataContext { get; set; }

		protected RepositoryServiceDao(DataContext context)
		{
			DataContext = context;
		}
		public virtual IQueryable<T> GetAll()
		{
			return  DataContext.Set<T>().AsQueryable();
		}

		public virtual async Task<T> GetSingle(Guid id, CancellationToken token = default)
		{
			return await DataContext.Set<T>().FirstAsync(i => i.Id == id,token);
		}

		public virtual async Task<T> Create(T entity, CancellationToken token = default)
		{
			var ret = entity;

			await using (var t = await DataContext.Database.BeginTransactionAsync(token))
			{
				try
				{ 
					var newEntity = await DataContext.Set<T>().AddAsync(entity, token);
					
					await DataContext.SaveChangesAsync(token);
					
					ret = newEntity.Entity;

					await t.CommitAsync(token);
				}
				catch (Exception e)
				{
					await t.RollbackAsync(token);

					throw;
				}
			}

			return ret;
		}

		public virtual async Task<T> Update(T entity, CancellationToken token = default)
		{
			await using (var t = await DataContext.Database.BeginTransactionAsync(token))
			{
				try
				{

					var exists = await DataContext.Set<T>().FirstOrDefaultAsync(e => e.Id == entity.Id, token);

					if (exists == null)
					{
						return await Create(entity,token);
					}

					ClassPropertyesCopier<T, T>.Copy(entity, exists);

					await DataContext.SaveChangesAsync(token);

					t.Commit();

					return exists;

				}
				catch (Exception e)
				{
					await t.RollbackAsync(token);

					throw;
				}
			}

		}

		public virtual async Task Delete(Guid id, CancellationToken token = default)
		{
			await using (var t = await DataContext.Database.BeginTransactionAsync(token))
			{
				try
				{
					DataContext.Remove(GetSingle(id));

					await DataContext.SaveChangesAsync(token);

					await t.CommitAsync(token);
				}
				catch (Exception e)
				{
					await t.RollbackAsync(token);

					throw;
				}
			}
		}

		public void Dispose()
		{
			DataContext?.Dispose();
		}
	}
}
