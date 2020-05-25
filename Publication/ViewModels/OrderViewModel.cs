using Publication.Data.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Publication.ViewModels
{
    public class OrderViewModel
    {
        public Order Order { get; set; }
        public PublicationCart PublicationCart { get; set; }
        public int TotalValue { get; set; }
    }
}
