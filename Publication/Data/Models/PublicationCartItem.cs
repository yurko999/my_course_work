using Publication.Data.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Publication.Data.models
{
    public class PublicationCartItem
    {
        public int Id { get; set; }
        public Book Book { get; set; }
        public int Price { get; set; }
        public string PublicationCartId { get; set; }
    }
}
