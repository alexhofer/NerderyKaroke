using System;
using NerderyKaraoke.Core.Data.Models;

namespace NerderyKaraoke.Core.Data.Repositories
{
	public class SongRequestRepository : BaseRepository<NerderyKaraokeDbContext, SongRequest>
	{
		public SongRequestRepository(NerderyKaraokeDbContext context) : base(context)
		{
		}

		public override bool IsNew(SongRequest entity)
		{
			return entity.Id == default(Guid);
		}
	}
}
