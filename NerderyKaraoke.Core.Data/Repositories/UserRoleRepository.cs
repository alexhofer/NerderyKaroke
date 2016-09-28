using NerderyKaraoke.Core.Data.Models;

namespace NerderyKaraoke.Core.Data.Repositories
{
	public class UserRoleRepository : BaseRepository<NerderyKaraokeDbContext, UserRole>
	{
		public UserRoleRepository(NerderyKaraokeDbContext context) : base(context)
		{
		}

		public override bool IsNew(UserRole entity)
		{
			var entry = Find(entity.UserName, entity.Role);
			return entry == null;
		}
	}
}
