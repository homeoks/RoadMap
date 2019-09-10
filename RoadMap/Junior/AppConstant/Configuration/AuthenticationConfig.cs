namespace Junior.AppConstant.Configuration
{
	public class AuthenticationConfig
	{
		public string Iss { get; set; }
		public string Aud { get; set; }
		public string SecretKey { get; set; }
		public long ExpireTime { get; set; }
	}
}
