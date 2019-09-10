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
	public class BaseRepository<T> : BaseMongoRepository<T> where T:IdentityEntity
	{
		
	}
}

