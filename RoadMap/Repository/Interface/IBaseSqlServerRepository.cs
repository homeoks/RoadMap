using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
namespace Repository.Interface
{
	public interface IBaseSqlServerRepository<T> : IBaseRepository<T>
	{
		IQueryable<T> GetAll(Expression<Func<T, bool>> predicate, bool isTracking = false, bool isDeleted = false);
		IQueryable<T> GetAll(bool isTracking = false, bool isDeleted = false);
	}
}
