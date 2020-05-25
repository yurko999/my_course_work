using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Publication.Data.interfaces;
using Publication.Data.models;
using Publication.ViewModels;

namespace Publication.Controllers
{
    public class ItemController : Controller
    {
        private readonly IGetBooks _getBooks;

        public ItemController(IGetBooks getBooks)
        {
            _getBooks = getBooks;
        }

        public IActionResult OpenItem(int bookId)
        {
            return View(new BookViewModel
            {
                Book = _getBooks.GetBookById(bookId),
                CurrentText = "Книга:"
            });
        }
    }
}