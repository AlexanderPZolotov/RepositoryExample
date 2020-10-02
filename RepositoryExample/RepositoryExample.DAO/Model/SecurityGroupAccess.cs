using System;
using System.ComponentModel.DataAnnotations.Schema;
using RepositoryExample.DAO.Model.Base;

namespace RepositoryExample.DAO.Model
{
	public class SecurityGroupAccess: BaseGuidIdTable
	{

		public Guid GroupId { get; set; }

		[ForeignKey(nameof(GroupId))]
		public SecurityGroupRole GroupRole { get; set; }

		public Guid RightId { get; set; }

		[ForeignKey(nameof(RightId))]
		public SecurityRight Right { get; set; }
	}
}
