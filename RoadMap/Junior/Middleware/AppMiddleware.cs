using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Junior.Helper;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Junior.Middleware
{
	public class AppMiddleware
	{
		private readonly RequestDelegate next;

		public AppMiddleware(RequestDelegate next)
		{
			this.next = next;
		}

		public async Task Invoke(HttpContext context /* other dependencies */)
		{
			try
			{
				await next(context);
			}
			catch (Exception ex)
			{
				await HandleExceptionAsync(context, ex);
			}
		}

		private static Task HandleExceptionAsync(HttpContext context, Exception exception)
		{
			var code = (HttpStatusCode) context.Response.StatusCode;
			var result = JsonConvert.SerializeObject(new
			{
				message = exception.Message,
				statusCode = code,
				error= code.ToString()
			});
			LogHelper.LogError((int)code, exception.Message);
			context.Response.ContentType = "application/json";
			context.Response.StatusCode =(int) code;
			
			return context.Response.WriteAsync(result);
		}
	}
}
