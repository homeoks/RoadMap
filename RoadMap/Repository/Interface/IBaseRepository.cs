using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
namespace Repository.Interface
{
	public interface IBaseRepository<T>
	{
		List<T> Get();
		List<T> Get(Expression<Func<T, bool>> predicate);
		T Get(string id);
		T Insert(T newEntity);
		bool Update(string id, T updateEntity);
		bool Delete(string id);
	}
}
