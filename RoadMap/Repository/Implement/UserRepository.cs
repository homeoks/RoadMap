using Microsoft.EntityFrameworkCore;
using Repository.ApplicationDbContext;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Repository.Entity.BaseEntity;
using Repository.Entity;
namespace Repository.Implement
{
	public class UserRepository : BaseRepository<UserEntity>, IUserRepository
	{
		
	}
	public class DeviceRepository : BaseRepository<Device>, IDeviceRepository
	{
		
	}
}
