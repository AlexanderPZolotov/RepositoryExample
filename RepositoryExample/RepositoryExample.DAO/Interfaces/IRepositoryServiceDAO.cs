using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RepositoryExample.DAO.Model;

namespace RepositoryExample.DAO.Interfaces
{
	public interface IRepositoryServiceDAO<T> where T : BaseGuidIdTable
	{
		DbContext _dbContext { get; set; }

		Task<T> Create(T entity, CancellationToken token = default);
		Task Delete(Guid id);
		void Dispose();
		IQueryable<T> GetAll();
		Task<T> GetSingle(Guid id);
		Task<T> Update(T entity);
	}
}