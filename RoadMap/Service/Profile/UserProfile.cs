using Junior.Mapper;
using Repository.Entity;
using Service.ViewModel.User;

namespace Service.Profile
{
	public class UserProfile:AutoMapper.Profile,IMapperProfile
	{
		public UserProfile()
		{
			CreateMap<UserEntity, UserInfoViewModel>();
		}
	}
}
