using Microsoft.AspNetCore.Mvc;
using Publication.Data.interfaces;
using Publication.Data.models;
using Publication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Publication.Controllers
{
    public class BookController : Controller
    {
        private readonly IGetBooks _getBooks;
        private readonly IBooksCategory _booksCategory;
        private readonly Dictionary<string, string> _categoryNames = new Dictionary<string, string>();

        public BookController(IGetBooks getBooks, IBooksCategory booksCategory)
        {
            _getBooks = getBooks;
            _booksCategory = booksCategory;
        }

        [Route("Book/List")]
        [Route("Book/List/{category}")]
        public ViewResult List(string category)
        {
            IEnumerable<Book> books = GetListOfBooks(category);
            string currentCategory;

            if (books.Cast<object>().Any())
                currentCategory = books.First().Category.CategoryName;
            else
                currentCategory = "На жаль, книжок з цією категорією немає";

            return View(new BookListViewModel
            {
                AllBooks = books,
                CurrentText = currentCategory
            });
        }

        private IEnumerable<Book> GetListOfBooks(string category)
        {
            foreach (var el in _booksCategory.GetCategories)
                _categoryNames.Add(el.CategoryLink, el.CategoryName);

            IEnumerable<Book> listBooks;

            if (_categoryNames.ContainsKey(category))
            {
                listBooks = _getBooks
                .GetAllBooks
                .Where(i => i.Category.CategoryName == _categoryNames[category])
                .OrderBy(i => i.Id);
            }
            else
            {
                listBooks = _getBooks
                    .GetAllBooks
                    .OrderBy(i => i.Id);
            }

            return listBooks;
        }
    }
}
