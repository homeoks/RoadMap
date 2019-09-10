using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using Repository.Entity;
namespace Repository.Interface
{
	public interface IUserRepository : IBaseRepository<UserEntity>
	{
	}
	public interface IDeviceRepository : IBaseRepository<Device>
	{
	}
}
