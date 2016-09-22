using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NerderyKaraoke.Core.Data
{
	public class BaseRepository<TDbContext, TEntity> : IRepository<TEntity>
		where TEntity: class, IHasId
		where TDbContext: DbContext, new()
	{
		private readonly DbContext _context;

		public BaseRepository(TDbContext context)
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

		public bool IsNew(TEntity entity)
		{
			return entity.Id == default(Guid);
		}
	}
}
