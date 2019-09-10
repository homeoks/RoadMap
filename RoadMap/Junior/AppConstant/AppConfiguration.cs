using Junior.AppConstant.Configuration;

namespace Junior.AppConstant
{
	public static class AppConfiguration
	{
		public static ConnectionStrings ConnectionStrings { get; set; }
		public static BookstoreDatabaseSettings BookstoreDatabaseSettings { get; set; }
		public static  AuthenticationConfig AuthenticationConfig { get; set; }
	}
}
