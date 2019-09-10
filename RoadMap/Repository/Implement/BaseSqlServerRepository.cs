using Microsoft.EntityFrameworkCore;
using Repository.ApplicationDbContext;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Repository.Entity.BaseEntity;

namespace Repository.Implement
{
	public class BaseSqlServerRepository<T> : IBaseSqlServerRepository<T> where T : IdentityEntity
	{
		public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate,bool isTracking=false,bool isDeleted=false)
		{
			using(var db=new AppDbContext())
			{
				var entities = db.Set<T>().Where(predicate);
				if (!isTracking)
					entities=entities.AsNoTracking();
				if (!isDeleted || !(typeof(T) is ISoftDeleted))
					entities = entities.Where(x => ((ISoftDeleted)x).IsDeleted == false);
				return entities;
			}
		}
		public IQueryable<T> GetAll(bool isTracking = false, bool isDeleted = false)
		{
			using (var db = new AppDbContext())
			{
				var entities = db.Set<T>().Where(x=>true);
				if (!isTracking)
					entities = entities.AsNoTracking();
				if (!isDeleted || !(typeof(T) is ISoftDeleted))
					entities = entities.Where(x => ((ISoftDeleted)x).IsDeleted == false);
				return entities;
			}
		}

		public List<T> Get()
		{
			using (var db = new AppDbContext())
			{
				var entities = db.Set<T>().Where(x => true);
				
				return entities.ToList();
			}
		}

		public List<T> Get(Expression<Func<T, bool>> predicate)
		{
			throw new NotImplementedException();
		}

		public T Get(string id)
		{
			throw new NotImplementedException();
		}

		public T Insert(T entity)
		{
			using (var db = new AppDbContext())
			{
				var entities = db.Set<T>().Add(entity);
				db.SaveChanges();
				return entities.Entity;
			}
		}

		public bool Update(string id, T updateEntity)
		{
			throw new NotImplementedException();
		}

		public bool Delete(string id)
		{
			throw new NotImplementedException();
		}
	}
}
