using Publication.Data.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Publication.ViewModels
{
    public class BookViewModel
    {
        public Book Book { get; set; }
        public string CurrentText { get; set; }  
    }
}
