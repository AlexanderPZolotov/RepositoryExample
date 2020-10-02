using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RepositoryExample.DAO.Model.Base;

namespace RepositoryExample.DAO.Interfaces
{
	public interface IRepositoryServiceDao<T> where T : BaseGuidIdTable
	{
		DbContext DataContext { get; set; }

		Task<T> Create(T entity, CancellationToken token = default);
		Task Delete(Guid id, CancellationToken token = default);
		void Dispose();
		IQueryable<T> GetAll();
		Task<T> GetSingle(Guid id, CancellationToken token = default);
		Task<T> Update(T entity, CancellationToken token = default);
	}
}