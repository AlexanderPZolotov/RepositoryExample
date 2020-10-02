using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using RepositoryExample.DAO.Model.Base;

namespace RepositoryExample.DAO.Model
{
	public class User : BaseGuidIdTable
	{
		[StringLength(255)]
		public string FirstName { get; set; }

		[StringLength(255)]
		public string LastName { get; set; }

		[StringLength(255)]
		public string ParentName { get; set; }

		public int? Sex { get; set; }

		public DateTime? BirthDay { get; set; }

		[StringLength(255)]
		public string BirthPlace { get; set; }

		[StringLength(100)]
		public string MobilePhone { get; set; }

		[StringLength(100)]
		public string HomePhone { get; set; }

		[StringLength(100)]
		public string WorkPhone { get; set; }

		[StringLength(100)]
		public string WorkPhone2 { get; set; }
    }
}
