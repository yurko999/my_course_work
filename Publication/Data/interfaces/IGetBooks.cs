using Publication.Data.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Publication.Data.interfaces
{
    public interface IGetBooks
    {
        IEnumerable<Book> GetAllBooks { get; }
        IEnumerable<Book> GetFavouriteBooks { get; }
        Book GetBookById(int bookId);
    }
}
