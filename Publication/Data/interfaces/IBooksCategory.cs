using Publication.Data.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Publication.Data.interfaces
{
    public interface IBooksCategory
    {
        IEnumerable<Category> GetCategories { get; }
    }
}
