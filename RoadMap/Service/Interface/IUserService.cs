using Repository.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using Service.ViewModel.User;

namespace Service.Interface
{
	public interface IUserService
	{
		List<UserEntity> Gets();
		string Login(string username,string password);
		UserEntity Insert(UserEntity user);
		List<Device> GetDevices();
		Device InsertDevice(string name);
		List<UserInfoViewModel> GetProfile(string name);
	}
}
