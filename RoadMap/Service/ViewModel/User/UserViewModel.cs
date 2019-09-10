using Junior.AppConstant;

namespace Service.ViewModel.User
{
	public class UserLoginViewModel
	{
		public string UserName { get; set; }
		public string Password { get; set; }
	}

	public class UserInfoViewModel
	{
		public string Username { get; set; }
		public string Email { get; set; }
		public string Name { get; set; }
		public int Age { get; set; }
		public AppEnum.Gender Gender { get; set; }
	}
}
