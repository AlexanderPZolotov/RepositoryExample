using System.ComponentModel.DataAnnotations;
using RepositoryExample.DAO.Model.Base;

namespace RepositoryExample.DAO.Model
{
	public class SecurityRight: BaseGuidIdTable
	{
		[StringLength(255)]
		public string Right { get; set; }

		[StringLength(255)]
		public string Description { get; set; }
	}
}
