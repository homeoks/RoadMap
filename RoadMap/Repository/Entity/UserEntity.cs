using System;
using System.Collections.Generic;
using System.Text;
using Junior.AppConstant;
using Repository.Entity.BaseEntity;


namespace Repository.Entity
{
	public class UserEntity : BasicEntity
	{
		public string Username { get; set; }
		public string Password { get; set; }
		public string Email { get; set; }
		public string Name { get; set; }
		public int Age { get; set; }
		public AppEnum.Gender Gender { get; set; }
	}
}
