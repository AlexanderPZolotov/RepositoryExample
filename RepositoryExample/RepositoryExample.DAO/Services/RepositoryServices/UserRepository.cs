using RepositoryExample.DAO.Base;
using RepositoryExample.DAO.DbConnections;
using RepositoryExample.DAO.Model;

namespace RepositoryExample.DAO.Services.RepositoryServices
{
	public class UserRepository : RepositoryServiceDao<User>
	{
		public UserRepository(DataContext context) : base(context)
		{
			DataContext = context;
		}
	}
}
