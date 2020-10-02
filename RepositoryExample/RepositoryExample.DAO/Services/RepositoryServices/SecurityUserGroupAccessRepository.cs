using RepositoryExample.DAO.Base;
using RepositoryExample.DAO.DbConnections;
using RepositoryExample.DAO.Model;

namespace RepositoryExample.DAO.Services.RepositoryServices
{
	public class SecurityUserGroupAccessRepository: RepositoryServiceDao<SecurityUserGroupAccess>
	{
		public SecurityUserGroupAccessRepository(DataContext context) : base(context)
		{
			DataContext = context;
		}
	}
}
