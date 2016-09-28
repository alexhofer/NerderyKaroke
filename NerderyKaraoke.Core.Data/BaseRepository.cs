using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace NerderyKaraoke.Core.Data
{
	public abstract class BaseRepository<TDbContext, TEntity> : IRepository<TEntity>
		where TEntity: class
		where TDbContext: DbContext, new()
	{
		private readonly DbContext _context;

		protected BaseRepository(TDbContext context)
		{
			_context = context;

			if (_context == null)
				throw new ArgumentNullException();
		}


		public IQueryable<TEntity> GetAll()
		{
			var query = _context.Set<TEntity>();
			return query;
		}

		public IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate)
		{
			var query = _context.Set<TEntity>().Where(predicate);
			return query;
		}

		public TEntity Find(params object[] keyValues)
		{
			var result = _context.Set<TEntity>().Find(keyValues);
			return result;
		}

		public void InsertOrUpdate(TEntity entity)
		{
			_context.Entry(entity).State = IsNew(entity) ? EntityState.Added : EntityState.Modified;
			Save();
		}

		public void Delete(TEntity entity)
		{
			_context.Set<TEntity>().Remove(entity);
		}

		public void Save()
		{
			_context.SaveChanges();
		}

		public abstract bool IsNew(TEntity entity);
	}
}
