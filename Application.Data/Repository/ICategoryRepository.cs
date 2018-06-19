using Application.Domain;
using System.Collections.Generic;

namespace Application.Data.Repository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        IEnumerable<Category> GetCategoriesByOffSet(int pageIndex, int pageSize);
    }
}
