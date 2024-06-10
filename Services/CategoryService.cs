using DataAccessLayer;
using BusinessObjects;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class CategoryService : ICategoryService
    {
        public List<Category> GetCategories()
        {
            using (var context = new MyStoreContext())
            {
                return context.Categories.ToList();
            }
        }
    }
}
