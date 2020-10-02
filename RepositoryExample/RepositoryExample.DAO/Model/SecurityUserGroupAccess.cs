using System;
using System.ComponentModel.DataAnnotations.Schema;
using RepositoryExample.DAO.Model.Base;

namespace RepositoryExample.DAO.Model
{
	public class SecurityUserGroupAccess : BaseGuidIdTable
	{
		public Guid GroupId { get; set; }

		[ForeignKey(nameof(GroupId))]
		public SecurityGroupRole GroupRole { get; set; }

		public string UserId { get; set; }

		[ForeignKey(nameof(UserId))]
		public User User { get; set; }
	}
}
