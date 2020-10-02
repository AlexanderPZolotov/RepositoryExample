using RepositoryExample.DAO.Base;
using RepositoryExample.DAO.DbConnections;
using RepositoryExample.DAO.Model;

namespace RepositoryExample.DAO.Services.RepositoryServices
{
	public class SecurityGroupRoleRepository:RepositoryServiceDao<SecurityGroupRole>
	{
		public SecurityGroupRoleRepository(DataContext context) : base(context)
		{
			DataContext = context;
		}
	}
	
}