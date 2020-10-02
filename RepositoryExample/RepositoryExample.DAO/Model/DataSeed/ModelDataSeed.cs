using System;
using Microsoft.EntityFrameworkCore;

namespace RepositoryExample.DAO.Model.DataSeed
{
	/// <summary>
	/// Fiil model tables default data
	/// </summary>
	public class ModelDataSeed
	{
		/// <summary>
		/// Owner Guid - Id
		/// </summary>
		public static readonly string OwnerGuidTxt = "BF5F7EB0-8592-4C78-BA1F-73731FD3381E";

		/// <summary>
		/// Admin Guid - Id
		/// </summary>
		public static readonly string AdminGuidTxt = "A4597002-5840-45FF-B29C-B5039AE6411A";

		/// <summary>
		/// User Guid - Id
		/// </summary>
		public static readonly string UserGuidTxt = "892045B0-7DA0-4698-8813-9A2A0BFB2951";

		private static readonly string AddDeleteNewUsers = "8230607C-55A7-4B88-A45E-32CD704258E5";
		private static readonly string PasswordChangeYourself = "21FB111D-B39D-4775-BC57-860A60B37C43";
		private static readonly string ViewAll = "D9B909EB-DEE8-4A24-B6A0-AAE675B3CD48";
		private static readonly string CanChangeTags = "EEA40A40-A089-478D-990D-EE2772AF78C8";


		/// <summary>
		/// Fill all tables by  default data
		/// </summary>
		/// <param name="builder"></param>
		public static void SeedAll(ModelBuilder builder)
		{
			SecurityGroupRoleSeed(builder);

			SecurityRightSeed(builder);

			SecurityGroupAccessSeed(builder);
		}

		/// <summary>
		/// Fill SecurityGroupRole
		/// </summary>
		/// <param name="builder"></param>
		public static void SecurityGroupRoleSeed(ModelBuilder builder)
		{
			builder.Entity<SecurityGroupRole>().HasData(
				new SecurityGroupRole
				{
					Id = new Guid(OwnerGuidTxt),
					Role = "Owner",
					Description = "Owner"
				},
				new SecurityGroupRole
				{
					Id = new Guid(AdminGuidTxt),
					Role = "Admin",
					Description = "Admin"
				},
				new SecurityGroupRole
				{
					Id = new Guid(UserGuidTxt),
					Role = "User",
					Description = "User"
				}

			);
		}

		/// <summary>
		/// Fill SecurityRight
		/// </summary>
		/// <param name="builder"></param>
		public static void SecurityRightSeed(ModelBuilder builder)
		{
			builder.Entity<SecurityRight>().HasData(
				new SecurityRight
				{
					Id = new Guid(AddDeleteNewUsers),
					Right = "AddDeleteNewUsers",
					Description = "Add or delete Users"
				},
				new SecurityRight
				{
					Id = new Guid(PasswordChangeYourself),
					Right = "PasswordChangeYourself",
					Description = "Can password change by yourself"
				},
				new SecurityRight
				{
					Id = new Guid(ViewAll),
					Right = "ViewAll",
					Description = "Can view all objects"
				},
				new SecurityRight
				{
					Id = new Guid(CanChangeTags),
					Right = "CanChangeTags",
					Description = "Can change tags"
				} 
			);
		}


		/// <summary>
		/// Fill SecurityRight
		/// </summary>
		/// <param name="builder"></param>
		public static void SecurityGroupAccessSeed(ModelBuilder builder)
		{
			var ownerGroupGuid = new Guid(OwnerGuidTxt);

			var userGroupGuid = new Guid(UserGuidTxt);

			var adminGroupGuid = new Guid(AdminGuidTxt);


			builder.Entity<SecurityGroupAccess>().HasData(
				new SecurityGroupAccess {Id = new Guid("DD4C2CC3-65E2-4DD1-A620-723B5ADB8758"), GroupId = ownerGroupGuid, RightId = new Guid(AddDeleteNewUsers) },
				new SecurityGroupAccess { Id = new Guid("23CD8B4E-A572-4335-B1EF-2EF115E14947"), GroupId = ownerGroupGuid, RightId = new Guid(PasswordChangeYourself) },
				new SecurityGroupAccess { Id = new Guid("6A6A3A41-1103-46BD-B482-AB59903172D9"), GroupId = ownerGroupGuid, RightId = new Guid(ViewAll) },
				new SecurityGroupAccess { Id = new Guid("EB133F40-AB3B-4094-9AE7-EF6FD853F36B"), GroupId = ownerGroupGuid, RightId = new Guid(CanChangeTags) },

				new SecurityGroupAccess { Id = new Guid("29EE3EDA-08ED-46F1-9EF7-79A2D4021E86"), GroupId = adminGroupGuid, RightId = new Guid(PasswordChangeYourself) },
				new SecurityGroupAccess { Id = new Guid("59309220-F49B-4E30-B265-CB2ED71867B0"), GroupId = adminGroupGuid, RightId = new Guid(ViewAll) },
				new SecurityGroupAccess { Id = new Guid("F2F3FDF3-1ABC-46FF-BB62-E19B3F48E0AC"), GroupId = adminGroupGuid, RightId = new Guid(CanChangeTags) },

				new SecurityGroupAccess { Id = new Guid("7AC0F6A1-A585-40D6-B09B-DD6B86772935"), GroupId = userGroupGuid, RightId = new Guid(PasswordChangeYourself) }

			);



		}
	}
}
