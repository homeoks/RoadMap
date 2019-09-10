using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using Junior.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;

namespace RoadMap.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class ValuesController : ControllerBase
	{
		// GET api/values
		[HttpGet]
		public ActionResult<IEnumerable<string>> Get()
		{
			return new string[] { "value1", "value2" };
		}

		// GET api/values/5
		[HttpGet("{id}")]
		public ActionResult<string> Get(int id)
		{
			return "value";
		}
		[HttpGet("TestLog")]
		public ActionResult<string> TestLog(string text)
		{
			//LogHelper.Test(text);
			if (text == "base")
				throw new Exception();
			if (text == "error")
				throw new Exception("error");
			if (text == "authen")
				throw new AuthenticationException("zz");
			if (text == "zero")
			{
				var a = 4;
				var t = 2 / (4-a);
			}
			if (text == "loop")
			{
				int i = 10;
				while (true)
				{
					i = i + i;
					if (i == 0)
						break;
				}
			}
			if (text == "timeout")
				throw new TimeoutException();

			return "value";
		}
		// POST api/values
		[HttpPost]
		public void Post([FromBody] string value)
		{
		}
		[AllowAnonymous]
		[HttpGet("get-token")]
		public ActionResult<IEnumerable<string>> GetToken()
		{
			var token=JwtHelper.GetToken();
			
			return Ok(new { token });
		}
		// PUT api/values/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/values/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
