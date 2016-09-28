using System;
using System.Configuration.Provider;
using System.Linq;
using System.Web.Security;

using NerderyKaraoke.Core.Data;
using NerderyKaraoke.Core.Data.Models;
using NerderyKaraoke.Core.Data.Repositories;

namespace NerderyKaraoke.UI.Providers
{
	public class AdminRoleProvider : RoleProvider
	{
		private readonly IRepository<UserRole> _adminRepository;

		public AdminRoleProvider()
		{
			var context = new NerderyKaraokeDbContext();
			_adminRepository = new UserRoleRepository(context);
		}


		public override bool IsUserInRole(string username, string roleName)
		{
			var entry = _adminRepository.Find(username, roleName);
			return entry != null;
		}

		public override string[] GetRolesForUser(string username)
		{
			var roles = _adminRepository
									.FindBy(ur => string.Equals(ur.UserName, username))
									.Select(ur => ur.Role)
									.ToArray();
			return roles;
		}

		public override void CreateRole(string roleName)
		{
			throw new NotSupportedException();
		}

		public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
		{
			throw new NotSupportedException();
		}

		public override bool RoleExists(string roleName)
		{
			return GetAllRoles().Contains(roleName, StringComparer.OrdinalIgnoreCase);
		}

		public override void AddUsersToRoles(string[] usernames, string[] roleNames)
		{
			if (!roleNames.Any(RoleExists))
				throw new ProviderException("Role does not exist.");

			foreach (var entry in usernames.SelectMany(u => roleNames.Select(r => new UserRole {UserName = u, Role = r })))
			{
				_adminRepository.InsertOrUpdate(entry);
			}
		}

		public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
		{
			if (!roleNames.Any(RoleExists))
				throw new ProviderException("Role does not exist.");

			foreach (var entry in usernames.SelectMany(u => roleNames.Select(r => new UserRole {UserName = u, Role = r})))
			{
				_adminRepository.Delete(entry);
			}
		}

		public override string[] GetUsersInRole(string roleName)
		{
			if(!RoleExists(roleName))
				throw new ProviderException("Role does not exist.");

			var users = _adminRepository
									.GetAll()
									.Select(ur => ur.UserName)
									.ToArray();

			return users;
		}

		public override string[] GetAllRoles()
		{
			return new[] { "Administrator" };
		}

		public override string[] FindUsersInRole(string roleName, string usernameToMatch)
		{
			if(!RoleExists(roleName))
				throw new ProviderException("Role does not exist.");

			var users = _adminRepository.FindBy(ur => string.Equals(ur.Role, roleName, StringComparison.OrdinalIgnoreCase) && ur.UserName.Contains(usernameToMatch))
									.Select(ur => ur.UserName)
									.ToArray();
			return users;
		}

		public override string ApplicationName { get; set; }
	}
}