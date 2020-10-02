using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using RepositoryExample.DAO.Model;
using RepositoryExample.DAO.Model.DataSeed;

namespace RepositoryExample.DAO.DbConnections
{
	public class DataContext : DbContext
	{
		private static DbContextOptions<DataContext> _options;
		public DataContext(DbContextOptions<DataContext> options) : base(options)
		{
			_options = options;
		}
		public DataContext(string connectionString) : base(GetOptions(connectionString))
		{
		}
		private static DbContextOptions GetOptions(string connectionString)
		{
			return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			ModelDataSeed.SeedAll(builder);

			base.OnModelCreating(builder);
		}

		public DbSet<User> Users { get; set; }

		public DbSet<SecurityGroupRole> SecurityGroupRoles { get; set; }

		public DbSet<SecurityRight> SecurityRights { get; set; }

		public DbSet<SecurityGroupAccess> SecurityGroupAccesses { get; set; }

		public DbSet<SecurityUserGroupAccess> SecurityUserGroupAccesses { get; set; }

	}
}
