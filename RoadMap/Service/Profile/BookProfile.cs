using Junior.Mapper;
using Repository.Entity;
using Service.ViewModel.User;

namespace Service.Profile
{
	public class BookProfile:AutoMapper.Profile,IMapperProfile
	{
		public BookProfile()
		{
			CreateMap<Book, BookViewModel>();
		}
	}
}
