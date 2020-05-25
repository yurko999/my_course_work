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
    public class OrderController : Controller
    {
        private readonly IAllOrders _allOrders;
        private readonly PublicationCart _publicationCart;

        public OrderController(IAllOrders allOrders, PublicationCart publicationCart)
        {
            _allOrders = allOrders;
            _publicationCart = publicationCart;
        }

        public IActionResult Checkout()
        {
            _publicationCart.listPublicationItems = _publicationCart.GetPublicationItems();

            int totalValue = 0;
            foreach (var el in _publicationCart.listPublicationItems)
            {
                totalValue += el.Price;
            }

            return View(new OrderViewModel
            {
                PublicationCart = _publicationCart,
                TotalValue = totalValue
            });
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            _publicationCart.listPublicationItems = _publicationCart.GetPublicationItems();

            int totalValue = 0;
            foreach (var el in _publicationCart.listPublicationItems)
            {
                totalValue += el.Price;
            }

            if (_publicationCart.listPublicationItems.Count == 0)
            {
                ModelState.AddModelError("", "Корзина пуста!");
            }

            if (ModelState.IsValid)
            {
                _allOrders.CreateOrder(order);
                return RedirectToAction("Complete");
            }

            return View(new OrderViewModel
            {
                Order = order,
                PublicationCart = _publicationCart,
                TotalValue = totalValue
            });
        }

        public IActionResult Complete()
        {
            return View();
        }
    }
}
