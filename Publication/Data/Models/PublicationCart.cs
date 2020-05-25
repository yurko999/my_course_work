using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Publication.Data.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Publication.Data.models
{
    public class PublicationCart
    {
        private readonly AppDbContext _appDbContent;

        public PublicationCart(AppDbContext appDbContent)
        {
            _appDbContent = appDbContent;
        }

        public string PublicationCartId { get; set; }

        public List<PublicationCartItem> listPublicationItems { get; set; }

        public static PublicationCart GetCart(IServiceProvider service)
        {
            ISession session = service.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = service.GetService<AppDbContext>();
            string publicationCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", publicationCartId);

            return new PublicationCart(context)
            {
                PublicationCartId = publicationCartId
            };
        }

        public void AddToCart(Book book)
        {
            _appDbContent.PublicationCartItems.Add(new PublicationCartItem
            {
                PublicationCartId = PublicationCartId,
                Book = book,
                Price = book.Price
            });
            _appDbContent.SaveChanges();
        }

        public void RemoveFromCart(Book book)
        {
            _appDbContent.PublicationCartItems.Remove(_appDbContent
                .PublicationCartItems
                .FirstOrDefault(i => i.Book.Id == book.Id));
            _appDbContent.SaveChanges();
        }

        public List<PublicationCartItem> GetPublicationItems()
        {
            return _appDbContent.PublicationCartItems
                .Where(c => c.PublicationCartId == PublicationCartId)
                .Include(s => s.Book)
                .ToList();
        }
    }
}
