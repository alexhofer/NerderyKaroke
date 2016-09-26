using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
