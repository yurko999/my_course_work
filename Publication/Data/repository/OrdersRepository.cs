using Publication.Data.interfaces;
using Publication.Data.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Publication.Data.repository
{
    public class OrdersRepository : IAllOrders
    {
        private readonly AppDbContext _appDbContent;
        private readonly PublicationCart _publicationCart;

        public OrdersRepository(AppDbContext appDbContent, PublicationCart publicationCart)
        {
            _appDbContent = appDbContent;
            _publicationCart = publicationCart;
        }

        public void CreateOrder(Order order)
        {
            order.OrderTime = DateTime.Now;
            _appDbContent.Order.Add(order);
            _appDbContent.SaveChanges();

            var items = _publicationCart.listPublicationItems;

            foreach(var el in items)
            {
                _appDbContent.OrderDetails.Add(new OrderDetails()
                {
                    BookId = el.Book.Id,
                    OrderId = order.Id,
                    Price = el.Book.Price
                });
            }

            _appDbContent.SaveChanges();
        }
    }
}
