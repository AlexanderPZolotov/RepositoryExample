using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RepositoryExample.DAO.Interfaces;
using RepositoryExample.DAO.Model.Base;

namespace RepositoryExample.DAO.Base
{
	/// <summary>
	/// Decorate logging for repository classes.
	/// Example of Decorator Pattern
	/// </summary>
	/// <typeparam name="T">Table class of repository</typeparam>
	public class RepositoryServiceDaoLogger<T> : IRepositoryServiceDao<T> where T : BaseGuidIdTable
	{
		private IRepositoryServiceDao<T> Decorator;

		private ILogger Logger;

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="decorator">Decorated Repository service class object</param>
		/// <param name="logger">ILogger instance</param>
		public RepositoryServiceDaoLogger(
			IRepositoryServiceDao<T> decorator,
			ILogger logger
		)
		{
			Decorator = decorator;

			Logger = logger;

			DataContext = decorator.DataContext;

		}
		public DbContext DataContext { get; set; }
		public async Task<T> Create(T entity, CancellationToken token = default)
		{
			try
			{
				return await Decorator.Create(entity, token);
			}
			catch (Exception e)
			{
				Log(e);

				throw;
			}

		}

		public async Task Delete(Guid id, CancellationToken token = default)
		{
			try
			{
				await Decorator.Delete(id, token);
			}
			catch (Exception e)
			{
				Log(e);

				throw;
			}

		}

		public void Dispose()
		{
			Decorator.Dispose();
		}

		public IQueryable<T> GetAll()
		{
			try
			{
				return  Decorator.GetAll();
			}
			catch (Exception e)
			{
				Log(e);

				throw;
			}
		}

		public async Task<T> GetSingle(Guid id, CancellationToken token = default)
		{
			try
			{
				return  await Decorator.GetSingle(id, token);
			}
			catch (Exception e)
			{
				Log(e);

				throw;
			}

		}

		public async Task<T> Update(T entity, CancellationToken token = default)
		{
			try
			{
				return await Decorator.Update(entity, token);
			}
			catch (Exception e)
			{
				Log(e);

				throw;
			}

		}

		private void Log(Exception e)
		{
			Logger.Log(LogLevel.Debug, e, e.Message);
		}
	}
}
