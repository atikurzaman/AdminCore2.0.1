using Application.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Data.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context) : base(context)
        {

        }
        public IEnumerable<Category> GetCategoriesByOffSet(int pageIndex, int pageSize=10)
        {
            var result = ApplicationDbContext.Categories
                .OrderBy(c => c.Name)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return result;
        }

        public ApplicationDbContext ApplicationDbContext
        {
            get { return _context as ApplicationDbContext; }
        }
    }
}
