using Repository.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using Service.ViewModel.User;

namespace Service.Interface
{
	 public interface IBookService
	{
		List<Book> Get();

		Book Get(string id);

		Book Create(Book book);


		List<BookViewModel> GetInfo(string name);
	}
}
