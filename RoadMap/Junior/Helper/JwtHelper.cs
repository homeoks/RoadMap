using System;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Text;
using Junior.AppConstant;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Serilog;

namespace Junior.Helper
{
	public static class JwtHelper
	{
		private readonly static SymmetricSecurityKey _secretKey = new SymmetricSecurityKey(
			Encoding.ASCII.GetBytes(AppConfiguration.AuthenticationConfig.SecretKey));
		public static void Test(string text)
		{
			Log.Logger = new LoggerConfiguration()
				.MinimumLevel.Information()
				.WriteTo.Console()
				.WriteTo.File("Log/log.txt",
					rollingInterval: RollingInterval.Day,
					rollOnFileSizeLimit: true)
				.CreateLogger();
			Serilog.Debugging.SelfLog.Enable(msg => Debug.WriteLine(msg));
			Serilog.Debugging.SelfLog.Enable(Console.Error);
			
			Log.Information("Hello!");
			Log.Error(text);

			Log.CloseAndFlush();
		}

		public static JwtBearerOptions DefaultOptions()
		{
			return new JwtBearerOptions()
			{
				TokenValidationParameters = new TokenValidationParameters
				{
					ValidateIssuer = true,
					ValidateAudience = true,
					ValidateLifetime = true,
					ValidateIssuerSigningKey = true,

					ValidIssuer = AppConfiguration.AuthenticationConfig.Iss,
					ValidAudience = AppConfiguration.AuthenticationConfig.Aud,
					IssuerSigningKey = _secretKey

				}

			};
		}

		public static string GetToken()
		{
			var handel = new JwtSecurityTokenHandler();
			var setting = handel.CreateToken(
				new SecurityTokenDescriptor
				{
					SigningCredentials = new SigningCredentials(_secretKey, SecurityAlgorithms.HmacSha256),
					Expires = DateTime.Now.AddMinutes(AppConfiguration.AuthenticationConfig.ExpireTime),
					Issuer = AppConfiguration.AuthenticationConfig.Iss,
					Audience = AppConfiguration.AuthenticationConfig.Aud
				});
			return handel.WriteToken(setting);
		}
	}
}
