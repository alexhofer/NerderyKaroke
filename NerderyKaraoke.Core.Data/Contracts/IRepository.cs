using System;
using System.Linq;
using System.Linq.Expressions;

namespace NerderyKaraoke.Core.Data
{
	public interface IRepository<T> where T : class
	{
		IQueryable<T> GetAll();

		IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);

		T Find(params object[] keyValues);

		void InsertOrUpdate(T entity);

		void Delete(T entity);

		void Save();

		bool IsNew(T entity);

	}
}