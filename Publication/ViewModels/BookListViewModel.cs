using Publication.Data.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Publication.ViewModels
{
    public class BookListViewModel
    {
        public IEnumerable<Book> AllBooks { get; set; }
        public string CurrentText { get; set; }
    }
}
