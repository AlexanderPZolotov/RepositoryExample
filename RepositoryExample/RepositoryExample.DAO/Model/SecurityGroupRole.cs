using RepositoryExample.DAO.Model.Base;

namespace RepositoryExample.DAO.Model
{
	public class SecurityGroupRole: BaseGuidIdTable
	{

		public string Role { get; set; }

		public string Description { get; set; }

	}
}
