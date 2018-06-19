using Application.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Data.Repository
{
    public interface IMenuRepository:IRepository<Menu>
    {
        List<Menu>  GetMenuWithParentName();
        IEnumerable<Menu> MenuSelectList();
    }
}
