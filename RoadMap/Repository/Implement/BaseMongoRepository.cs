using Microsoft.EntityFrameworkCore;
using Repository.ApplicationDbContext;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Junior.AppConstant;
using MongoDB.Driver;
using Repository.Entity;
using Repository.Entity.BaseEntity;

namespace Repository.Implement
{
	public class BaseMongoRepository<T> : IBaseMongoRepository<T> where T:IdentityEntity
	{
		private readonly IMongoCollection<T> _entity;
		public BaseMongoRepository()
		{
			var settings = AppConfiguration.BookstoreDatabaseSettings;
			var client = new MongoClient(settings.ConnectionString);
			var db = client.GetDatabase(settings.DatabaseName);
			_entity = db.GetCollection<T>(typeof(T).Name);
		}

		public List<T> Get()
		{
			return _entity.Find(x => true).ToList();
		}
		public List<T> Get(Expression<Func<T, bool>> predicate)
		{
			return _entity.Find(predicate).ToList();
		}


		public T Get(string id)
		{
			return _entity.Find<T>(x => x.Id == id).FirstOrDefault();
		}
		

		public T Insert(T newEntity)
		{
			_entity.InsertOne(newEntity);
			return newEntity;
		}

		public bool Update(string id, T updateEntity)
		{
			_entity.ReplaceOne(x => x.Id == id, updateEntity);
			return true;
		}
			

		public bool Delete(string id)
		{
			_entity.DeleteOne(x => x.Id == id);
			return true;
		}

	}
}

