using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using HeyTom.Domain.Interface;
using HeyTom.Domain.Models;
using HeyTom.Infra.DataContext;
using HeyTom.Infra.Util;
using Microsoft.EntityFrameworkCore;

namespace HeyTom.Infra.Implementation
{
	public abstract class Repository<T> : IRepository<T> where T : Entity
	{
		protected readonly DataContext.HeyTomContext _baseDbContext;
		protected DbSet<T> _set;

		public Repository(DataContext.HeyTomContext baseDbContext)
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

		public T GetOne(long Id)
		{
			return _set.SingleOrDefault(x => x.Id == Id);
		}

		public int Update(T entity)
		{
			_set.Update(entity);
			return _baseDbContext.SaveChanges();
		}

		public PagedData<TResult> GetViewPager<TResult>(ListParam param) where TResult : class, new()
		{
			var result = new PagedData<TResult>() { PageIndex = param.PageIndex, PageSize = param.PageSize };
			var sb = new StringBuilder();
			var from = $" From {GetTableName()} ";
			sb.Append(GetSelect(param, out var selecter));
			sb.Append(from);
			sb.Append(GetWhere(param));
			sb.Append(GetOrderBy(param));
			sb.Append(GetLimit(param));
			var expression = CreateSelecter<T, TResult>(param.Select);
			result.TModel = _baseDbContext.Set<T>().FromSql(sb.ToString(), GetParameters(param)).Select(expression)?.ToList();
			result.RecordCount = GetRecordCount(param,from);
			return result;
		}

		public abstract string GetTableName();

		public long GetRecordCount(ListParam param,string from)
		{
			var sb = new StringBuilder();
			sb.Append(GetSelect(param, out var selecter));
			sb.Append(from);
			sb.Append(GetWhere(param));
			return _baseDbContext.Set<T>().FromSql(sb.ToString(), GetParameters(param)).Count();
		}

		private static Expression<Func<TSource, TResult>> CreateSelecter<TSource, TResult>(List<SelectModel> fieldDic)
		{
			Expression<Func<TSource, TResult>> selector = null;


			//(rec)
			var param = Expression.Parameter(typeof(TSource), "x");
			//new ParadigmSearchListData 
			var v0 = Expression.New(typeof(TResult));
			//Number
			var bindingList = new List<MemberBinding>();
			foreach (var item in fieldDic)
			{
				var p = typeof(TResult).GetProperty(item.Value);
				var right = GetProperty<TSource>(null, item.Key, param);
				//right= Expression.Constant(right, p.PropertyType);
				var v = Expression.Convert(GetProperty<TSource>(null, item.Key, param), p.PropertyType);
				var m = Expression.Bind(p, v);
				bindingList.Add(m);
			}
			Expression body = Expression.MemberInit(v0, bindingList);


			selector = (Expression<Func<TSource, TResult>>)Expression.Lambda(body, param);


			return selector;
		}

		public static Expression GetProperty<T>(Expression source, string Name, ParameterExpression Param)
		{
			Name = Name.Replace(")", "");
			string[] propertys = null;
			if (Name.Contains("=>"))
			{
				propertys = Name.Split('.').Skip(1).ToArray();
			}
			else
			{
				propertys = Name.Split('.');
			}
			if (source == null)
			{
				source = Expression.Property(Param, typeof(T).GetProperty(propertys.First()));
			}
			else
			{
				source = Expression.Property(source, propertys.First());
			}
			foreach (var item in propertys.Skip(1))
			{
				source = GetProperty<T>(source, item, Param);
			}
			return source;
		}

		protected string GetSelect(ListParam listParam, out dynamic selecter)
		{
			var sb = new StringBuilder();
			if (listParam == null || listParam.Select == null || listParam.Select.Count == 0)
			{
				selecter = null;
				return string.Empty;
			}
			selecter = new System.Dynamic.ExpandoObject();
			sb.Append("Select ");
			var i = 0;
			foreach (var item in listParam.Select)
			{
				if (i++ == 0)
				{
					sb.Append($"{item.Key}");
					((IDictionary<string, object>)selecter).Add(item.Key, item.Key);
				}
				else
				{
					sb.Append($" , {item.Key} ");
					((IDictionary<string, object>)selecter).Add(item.Key, item.Key);
				}
			}
			return sb.ToString();
		}

		protected string GetWhere(ListParam listParam)
		{
			var sb = new StringBuilder();
			sb.Append(" Where 1=1 ");
			var i = 0;
			listParam?.Filter?.ForEach(ea =>
			{
				sb.Append($" {ea.Connector} {ea.DbField} {ea.Operator} " + "{" + i++ + "}");
			});
			return sb.ToString();
		}

		public object[] GetParameters(ListParam listParam)
		{
			var args = new object[listParam?.Filter?.Count ?? 0];
			var i = 0;
			listParam.Filter?.ForEach(p => args[i++] = p.Value);
			return args;
		}

		protected string GetLimit(ListParam listParam)
		{
			var sb = new StringBuilder();
			var index = listParam.PageIndex >= 1 ? listParam.PageIndex - 1 : 0;
			var count = listParam.PageSize > 20 ? 20 : listParam.PageSize;

			sb.Append($" limit {index},{count} ");

			return sb.ToString();
		}

		protected string GetOrderBy(ListParam listParam)
		{
			var sb = new StringBuilder();
			if (listParam == null || listParam.Sort == null || listParam.Sort.Count == 0)
			{
				return string.Empty;
			}
			sb.Append(" Order By ");
			for (var i = 0; i < listParam.Sort.Count; i++)
			{
				if (i == 0)
				{
					sb.Append($"{listParam.Sort[i].DbField} {listParam.Sort[i].Value}");

				}
				else
				{
					sb.Append($", {listParam.Sort[i].DbField} {listParam.Sort[i].Value}");
				}
			}
			return sb.ToString();
		}
	}
}
