using Application.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Data.Repository
{
    public class MenuRepository : Repository<Menu>, IMenuRepository
    {
        public MenuRepository(ApplicationDbContext context) : base(context)
        {

        }

        public ApplicationDbContext ApplicationDbContext
        {
            get { return _context as ApplicationDbContext; }
        }

        public IEnumerable<Menu> MenuSelectList()
        {
            var menus = ApplicationDbContext.Menus.Select(m => new Menu
            {
                Name = m.Name,
                Id = m.Id,
                ParentId = m.ParentId
            }).ToList();

            return menus;
        }
        public List<Menu> GetMenuWithParentName()
        {
            List<Menu> menuList = new List<Menu>();

            var menus = ApplicationDbContext.Menus.Select(m => new Menu
            {
                Id = m.Id,
                Name = m.Name,
                ControllerName = m.ControllerName,
                ActionName = m.ActionName,
                MenuArea = m.MenuArea,
                HasAccess = m.HasAccess,
                Disable =m.Disable,
                ParentId = m.ParentId,
                ParentMenuName = string.Empty
            }).ToList();

            foreach (var menu in menus)
            {
                var parentMenuName = GetParentMenuName(menu.ParentId);
                if (parentMenuName != null)
                {
                    menu.ParentMenuName = parentMenuName;
                }
                else
                {
                    menu.ParentMenuName = string.Empty;
                }
                menuList.Add(menu);
            }

            return menuList;
        }

        private string GetParentMenuName(Int64? parentId)
        {
            string parentMenuName = string.Empty;
            var result = ApplicationDbContext.Menus.Where(m => m.ParentId != null && m.ParentId == parentId).FirstOrDefault();

            if (result == null)
            {
                return parentMenuName;
            }
            else
            {
                parentMenuName = ApplicationDbContext.Menus.Where(p => p.Id == result.ParentId).Select(pm => pm.Name).FirstOrDefault();
            }
            return parentMenuName;
        }
    }
}
