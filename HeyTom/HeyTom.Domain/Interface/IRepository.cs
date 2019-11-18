using System;
using System.Collections.Generic;
using System.Text;
using HeyTom.Domain.Models;
using HeyTom.Infra.Util;

namespace HeyTom.Domain.Interface
{
	public interface IRepository<T> where T:Entity
	{
		T GetOne(long Id);

		int Add(T entity);

		int Delete(T entity);

		int Update(T entity);

		PagedData<TResult> GetViewPager<TResult>(ListParam param) where TResult : class, new();
	}
}
