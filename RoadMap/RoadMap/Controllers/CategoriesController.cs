using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Repository.Entity;
using Service.Interface;

namespace RoadMap.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoriesController : ControllerBase
	{
		private readonly IBookService _bookService;
		public CategoriesController(IBookService bookService)
		{
			_bookService = bookService;
		}
		// GET api/values
		[HttpGet]
		public ActionResult<List<Category>> Get()
		{
			return Ok();
		}

		// GET api/values/5
		[HttpGet("{name}")]
		public ActionResult<Category> Get(string name)
		{
			return Ok();
		}

		
	}
}
