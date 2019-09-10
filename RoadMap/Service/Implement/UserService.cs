using Repository.Entity;
using Repository.Interface;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using AutoMapper;
using Junior.Helper;
using Junior.Mapper;
using Service.ViewModel.User;

namespace Service.Implement
{
	public class UserService : IUserService
	{
		private readonly IUserRepository _userRepository;
		private readonly IDeviceRepository _deviceRepository;
		private readonly IMapper _mapper;

		public UserService(IUserRepository userRepository, IDeviceRepository deviceRepository, IMapper mapper)
		{
			_userRepository = userRepository;
			_deviceRepository = deviceRepository;
			_mapper = mapper;
		}
		public List<UserEntity> Gets()
		{
			return _userRepository.Get();
		}
		public string Login(string userName,string password)
		{
			var existUser= _userRepository.Get(x=>x.Username==userName && x.Password==password).FirstOrDefault();
			if(existUser==null)
				throw new Exception("User does not exist");
			var token = JwtHelper.GetToken();
			return token;
		}

		public UserEntity Insert(UserEntity user)
		{
			return _userRepository.Insert(user);
		}

		public List<Device> GetDevices()
		{
			return _deviceRepository.Get();
		}

		public Device InsertDevice(string name)
		{
			return _deviceRepository.Insert(new Device
			{
				Name=name
			});
		}

		public List<UserInfoViewModel> GetProfile(string name)
		{
			var user = _userRepository.Get(x => x.Name.Contains(name));
			return user.Select(x => _mapper.Map<UserInfoViewModel>(x)).ToList();
		}
	}
}
