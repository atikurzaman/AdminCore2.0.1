using Application.Domain;
using System.Collections.Generic;

namespace Application.Data.Repository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        IEnumerable<Category> GetCategoryByOffSet(int pageIndex, int pageSize);
        IEnumerable<Category> GetCategoryParentName();
        IEnumerable<Category> CategorySelectList();
    }
}
