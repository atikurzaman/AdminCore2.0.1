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
        public ApplicationDbContext ApplicationDbContext
        {
            get { return _context as ApplicationDbContext; }
        }
        public IEnumerable<Category> GetCategoryByOffSet(int pageIndex, int pageSize = 10)
        {
            var result = ApplicationDbContext.Categories
                .OrderBy(c => c.Name)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return result;
        }
        public IEnumerable<Category> CategorySelectList()
        {
            var categories = ApplicationDbContext.Categories.Select(m => new Category
            {
                Name = m.Name,
                Id = m.Id,
                ParentCategoryId = m.ParentCategoryId
            }).ToList();

            return categories;
        }
        public IEnumerable<Category> GetCategoryParentName()
        {
            List<Category> categoryList = new List<Category>();

            var categories = ApplicationDbContext.Categories.Select(c => new Category
            {
                Id = c.Id,
                Name = c.Name,                              
                CreatedDate = c.CreatedDate,
                ModifiedDate = c.ModifiedDate,
                CreatedBy = c.CreatedBy,
                ModifiedBy = c.ModifiedBy,
                IPAddress = c.IPAddress,
                MacAddress = c.MacAddress,
                ParentCategoryId = c.ParentCategoryId,
                ParentCategoryName = string.Empty
            }).ToList();

            foreach (var category in categories)
            {
                var parentCategoryName = GetParentCategoryName(category.ParentCategoryId);
                if (parentCategoryName != null)
                {
                    category.ParentCategoryName = parentCategoryName;
                }
                else
                {
                    category.ParentCategoryName = string.Empty;
                }
                categoryList.Add(category);
            }

            return categoryList;
        }

        private string GetParentCategoryName(Int64? parentCategoryId)
        {
            string parentCategoryName = string.Empty;
            var result = ApplicationDbContext.Categories.Where(c => c.ParentCategoryId != null && c.ParentCategoryId == parentCategoryId).FirstOrDefault();

            if (result == null)
            {
                return parentCategoryName;
            }
            else
            {
                parentCategoryName = ApplicationDbContext.Categories.Where(p => p.Id == result.ParentCategoryId).Select(pm => pm.Name).FirstOrDefault();
            }
            return parentCategoryName;
        }
    }
}
