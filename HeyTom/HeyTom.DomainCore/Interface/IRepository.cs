using System;
using System.Collections.Generic;
using System.Text;

namespace HeyTom.DomainCore.Interface
{
	public interface IRepository<T> where T:class ,new()
	{
		T GetOne(T entity);

		int Add(T entity);

		int Delete(T entity);

		int Update(T entity);
	}
}
