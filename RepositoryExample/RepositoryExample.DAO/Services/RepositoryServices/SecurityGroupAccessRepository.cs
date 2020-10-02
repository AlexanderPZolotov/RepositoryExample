using RepositoryExample.DAO.Base;
using RepositoryExample.DAO.DbConnections;
using RepositoryExample.DAO.Model;

namespace RepositoryExample.DAO.Services.RepositoryServices
{
	public class SecurityGroupAccessRepository: RepositoryServiceDao<SecurityGroupAccess>
	{
		public SecurityGroupAccessRepository(DataContext context) : base(context)
		{
			DataContext = context;
		}
	}
}
