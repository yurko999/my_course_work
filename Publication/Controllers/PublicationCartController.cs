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
    public class PublicationCartController : Controller
    {
        private readonly IGetBooks _bookRepository;
        private readonly PublicationCart _publicationCart;

        public PublicationCartController(IGetBooks bookRepository, PublicationCart publicationCart)
        {
            _bookRepository = bookRepository;
            _publicationCart = publicationCart;
        }

        public ViewResult Index()
        {
            _publicationCart.listPublicationItems = _publicationCart.GetPublicationItems();

            return View(new PublicationCartViewModel
            {
                PublicationCart = _publicationCart,
                CurrentText = (_publicationCart.listPublicationItems.Count == 0) ? "Ваша корзина пуста" : "Ваша корзина:"
            });
        }

        public RedirectToActionResult AddToCart(int id)
        {
            var item = _bookRepository.GetBookById(id);

            if(item != null)
            {
                _publicationCart.AddToCart(item);
            }

            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromCart(int id)
        {
            var item = _bookRepository.GetBookById(id);

            if (item != null)
            {
                _publicationCart.RemoveFromCart(item);
            }

            return RedirectToAction("Index");
        }
    }
}
