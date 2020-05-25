using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Publication.Data.interfaces;
using Publication.ViewModels;

namespace Publication.Controllers
{
    public class HomeController : Controller
    {
        private IGetBooks _getBooks;

        public HomeController(IGetBooks getBooks)
        {
            _getBooks = getBooks;
        }

        public ViewResult Index()
        {
            return View(new HomeViewModel
            {
                AllBooks = _getBooks.GetAllBooks,
                CurrentText = "Улюблені книги"
            });
        }
    }
}