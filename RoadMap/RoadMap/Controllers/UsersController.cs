using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Repository.Entity;
using Repository.Interface;
using Service.Interface;
using Service.ViewModel.User;

namespace RoadMap.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		private readonly IUserService _userService;
		public UsersController(IUserService userService)
		{
			_userService = userService;
		}
		// GET api/values
		[HttpGet]
		public IActionResult Get()
		{
			var data=_userService.Gets();
			return Ok(data);
		}
		
		[HttpGet("profile")]
		public IActionResult GetProfile(string name)
		{
			var data=_userService.GetProfile(name);
			return Ok(data);
		}

		[HttpPost]
		public IActionResult Insert(UserEntity userEntity)
		{
			var data = _userService.Insert(userEntity);
			return Ok(data);
		}
		[HttpPost("login")]
		public IActionResult Login(UserLoginViewModel model)
		{
			var token = _userService.Login(model.UserName, model.Password);
			return Ok(new{ token});
		}
		[HttpGet("device")]
		public IActionResult GetDevice()
		{
			var data= _userService.GetDevices();
			return Ok(data);
		}

		[HttpPost("device")]
		public IActionResult InsertGetDevice(string name)
		{
			var data = _userService.InsertDevice(name);
			return Ok(data);
		}
	}
}
