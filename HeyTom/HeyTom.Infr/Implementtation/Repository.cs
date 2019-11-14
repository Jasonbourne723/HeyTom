using System.Linq;
using HeyTom.DomainCore.Interface;
using HeyTom.Infr.Dal;

namespace HeyTom.DomainCore.Implementation
{
	public class Repository<T> : IRepository<T> where T : class, new()
	{
		protected readonly BaseDbContext<T> _baseDbContext;

		public Repository(BaseDbContext<T> baseDbContext)
		{
			_baseDbContext = baseDbContext;
		}

		public int Add(T entity)
		{
			var result = _baseDbContext.List.Add(entity);
			return _baseDbContext.SaveChanges();
		}

		public int Delete(T entity)
		{
			_baseDbContext.List.Remove(entity);
			return _baseDbContext.SaveChanges();
		}

		public T GetOne(T entity)
		{
			return _baseDbContext.List.SingleOrDefault();
		}

		public int Update(T entity)
		{
			_baseDbContext.List.Update(entity);
			return _baseDbContext.SaveChanges();
		}
	}
}
