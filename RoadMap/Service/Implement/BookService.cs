using Repository.Entity;
using Repository.Interface;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using MongoDB.Driver;
using Repository.MongoDb;
using Service.ViewModel.User;

namespace Service.Implement
{
	public class BookService : IBookService
	{
		private readonly IBookRepository _books;
		private readonly IMapper _mapper;

		public BookService(IBookRepository books, IMapper mapper)
		{
			_books = books;
			_mapper = mapper;
		}


		public List<Book> Get()
		{
			return _books.Get();
		}

		public Book Get(string id)
		{
			return _books.Get(id);
		}

		public Book Create(Book book)
		{
			return _books.Insert(book);
		}

		public List<BookViewModel> GetInfo(string name)
		{
			return _books.Get(x => x.BookName.Contains(name)).Select(x => _mapper.Map<BookViewModel>(x)).ToList();
		}
	}
}
