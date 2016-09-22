using System;
using System.Linq;
using NerderyKaraoke.Core.Data;
using NerderyKaraoke.Core.Data.Models;

namespace NerderyKaraoke.Core.Services
{
	public class SongManager : ISongManager
	{
		private readonly IRepository<SongRequest> _songRepository;

		public SongManager(IRepository<SongRequest> songRepository)
		{
			_songRepository = songRepository;
			if (_songRepository == null)
				throw new ArgumentNullException();
		}

		public IQueryable<SongRequest> Get()
		{
			return _songRepository.GetAll();
		}

		public void Add(SongRequest entity)
		{
			_songRepository.InsertOrUpdate(entity);
			_songRepository.Save();
		}

		public void Update(SongRequest entity)
		{
			_songRepository.InsertOrUpdate(entity);
			_songRepository.Save();
		}

		public void Delete(SongRequest entity)
		{
			_songRepository.Delete(entity);
			_songRepository.Save();
		}

		public void DeleteAll()
		{
			foreach(var song in Get())
				Delete(song);
			_songRepository.Save();
		}
	}
}