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
	public class BooksController : ControllerBase
	{
		private readonly IBookService _bookService;
		public BooksController(IBookService bookService)
		{
			_bookService = bookService;
		}
		// GET api/values
		[HttpGet]
		public IActionResult Get()
		{
				var t= _bookService.Get();
				return Ok(t);
		}
		[HttpGet("info")]
		public IActionResult GetInfo(string name)
		{
				var t= _bookService.GetInfo(name);
				return Ok(t);
		}

		// GET api/values/5
		[HttpGet("{getById}")]
		public IActionResult Get(string id)
		{
			var t = _bookService.Get(id);
			return Ok(t);
		}

		// POST api/values
		[HttpPost]
		public IActionResult Post([FromBody] string name)
		{
			var book = new Book
			{
				Author = name,
				BookName = name,
				Category = name,
				Price = 1
			};
			_bookService.Create(book);
			return Created(book.Id,  book);
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
