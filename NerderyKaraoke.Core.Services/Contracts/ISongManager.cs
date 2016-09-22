using System.Linq;
using NerderyKaraoke.Core.Data.Models;

namespace NerderyKaraoke.Core.Services
{
	public interface ISongManager
	{
		IQueryable<SongRequest> Get();
		void Add(SongRequest entity);
		void Update(SongRequest entity);
		void Delete(SongRequest entity);
		void DeleteAll();
	}
}