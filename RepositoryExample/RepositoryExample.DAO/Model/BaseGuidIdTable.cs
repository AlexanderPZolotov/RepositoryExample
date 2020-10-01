using System;
using System.ComponentModel.DataAnnotations;

namespace RepositoryExample.DAO.Model
{
	public class BaseGuidIdTable
	{
		[Key]
		public Guid Id { get; set; }
	}
}
