using System.Linq;
using HeyTom.Domain.Model;
using HeyTom.DomainCore.Interface;
using HeyTom.Infr.Dal;
using Microsoft.EntityFrameworkCore;

namespace HeyTom.DomainCore.Implementation
{
	public class Repository<T> : IRepository<T> where T : class, new()
	{
		protected readonly BaseDbContext _baseDbContext;
		protected DbSet<T> _set; 

		public Repository(BaseDbContext baseDbContext)
		{
			_baseDbContext = baseDbContext;
			_set = _baseDbContext.Set<T>();
		}

		public int Add(T entity)
		{
			var result = _set.Add(entity);
			return _baseDbContext.SaveChanges();
		}

		public int Delete(T entity)
		{
			_set.Remove(entity);
			return _baseDbContext.SaveChanges();
		}

		public T GetOne(T entity)
		{
			return _set.Find();
		}

		public int Update(T entity)
		{
			_set.Update(entity);
			return _baseDbContext.SaveChanges();
		}
	}
}
