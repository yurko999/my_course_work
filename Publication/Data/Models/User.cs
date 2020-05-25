using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Publication.Data.models
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime Birthday { get; set; }
        public string FirstName {get;set;}
        public string LastName { get; set; }
        public bool Sex { get; set; }
        public bool IsAuthenticated { get; set; }
        public List<Book> FavouriteBooks { get; set; }
    }
}
