using RepositoryExample.DAO.Base;
using RepositoryExample.DAO.DbConnections;
using RepositoryExample.DAO.Model;

namespace RepositoryExample.DAO.Services.RepositoryServices
{
	public class SecurityRightRepository:RepositoryServiceDao<SecurityRight>
	{
		public SecurityRightRepository(DataContext context) : base(context)
		{
			DataContext = context;
		}
	}
}
