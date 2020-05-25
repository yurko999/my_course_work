using Publication.Data.interfaces;
using Publication.Data.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Publication.Data.repository
{
    public class CategoryRepository : IBooksCategory
    {
        private readonly AppDbContext _appDbContent;

        public CategoryRepository(AppDbContext appDbContent)
        {
            _appDbContent = appDbContent;
        }

        public IEnumerable<Category> GetCategories => _appDbContent.Category;
    }
}
