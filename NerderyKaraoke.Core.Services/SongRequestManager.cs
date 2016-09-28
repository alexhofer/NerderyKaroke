using System;
using System.Linq;
using NerderyKaraoke.Core.Data;
using NerderyKaraoke.Core.Data.Models;

namespace NerderyKaraoke.Core.Services
{
	public class SongRequestManager : ISongRequestManager
	{
		private readonly IRepository<SongRequest> _songRepository;

		public SongRequestManager(IRepository<SongRequest> songRepository)
		{
			_songRepository = songRepository;
			if (_songRepository == null)
				throw new ArgumentNullException();
		}

		public IQueryable<SongRequest> GetAll()
		{
			return _songRepository.GetAll();
		}

		public SongRequest Get(Guid id)
		{
			return _songRepository.Find(id);
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
			foreach(var song in GetAll().ToList())
				Delete(song);
			_songRepository.Save();
		}
	}
}