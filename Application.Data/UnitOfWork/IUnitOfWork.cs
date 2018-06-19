using Application.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository Categories { get;}
        IMenuRepository Menus { get; }
        int Complete();
        Task<int> CompleteAsync();
    }
}
