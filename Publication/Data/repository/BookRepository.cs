using Microsoft.EntityFrameworkCore;
using Publication.Data.interfaces;
using Publication.Data.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Publication.Data.repository
{
    public class BookRepository : IGetBooks
    {
        private readonly AppDbContext _appDbContent;

        public BookRepository(AppDbContext appDbContent)
        {
            _appDbContent = appDbContent;
        }

        public IEnumerable<Book> GetAllBooks => _appDbContent.Book.Include(c => c.Category);

        public IEnumerable<Book> GetFavouriteBooks => _appDbContent.Book.Where(i => i.IsFavourite).Include(c => c.Category);

        public Book GetBookById(int bookId) => _appDbContent.Book.Include(c => c.Category).FirstOrDefault(i => i.Id == bookId);
    }
}
