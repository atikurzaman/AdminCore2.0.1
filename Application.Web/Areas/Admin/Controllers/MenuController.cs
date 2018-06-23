using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Application.Data;
using Application.Domain;
using Application.Web.Areas.Admin.Models;
using Application.Data.UnitOfWork;
using System.Threading;
using Microsoft.Azure.KeyVault.Models;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Application.Web.Common;
using Microsoft.AspNetCore.Http;

namespace Application.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MenuController : BaseController
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public MenuController(IUnitOfWork uow, IMapper mapper, ILogger<MenuController> logger)
        {
            _uow = uow;
            _mapper = mapper;
            _logger = logger;
        }        
        public IActionResult Index()
        {
            IEnumerable<Menu> menus = _uow.Menus.GetMenuWithParentName();
            var menuModel = _mapper.Map<IEnumerable<MenuViewModel>>(menus);
            return View(menuModel);
        }

        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menu = await _uow.Menus.GetAsync(id.Value);
            if (menu == null)
            {
                return NotFound();
            }

            var menuModel = _mapper.Map<Menu, MenuViewModel>(menu);
            return View(menuModel);
        }

        [HttpGet]
        public async Task<IActionResult> AddEditMenu(long? id)
        {
            MenuViewModel menuViewModel = new MenuViewModel();
            if (id.HasValue)
            {
                var menu = await _uow.Menus.GetAsync(id.Value);
                if (menu == null)
                {
                    return NotFound();
                }

                var menuModel = _mapper.Map<MenuViewModel>(menu);
                menuViewModel = menuModel;
                menuViewModel.MenuSelectList = new SelectList(_uow.Menus.MenuSelectList(), "Id", "Name", menuModel.ParentId);
            }
            else
            {
                menuViewModel.MenuSelectList = new SelectList(_uow.Menus.MenuSelectList(), "Id", "Name", null);
            }

            return PartialView("~/Areas/Admin/Views/Menu/_AddEditMenu.cshtml", menuViewModel);
        }

        [HttpPost,ActionName("AddEditMenu")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddEditMenu(long? id, MenuViewModel menuViewModel)
        {
            try
            {                
                if (menuViewModel == null)
                {
                    _logger.LogInformation(LogMessageConstant.ItemNotFound,menuViewModel);
                    return NotFound();
                }
                if (ModelState.IsValid)
                {
                    bool isNew = !id.HasValue;
                    if (isNew)
                    {
                        var menu = _mapper.Map<Menu>(menuViewModel);
                        await _uow.Menus.AddAsync(menu);
                        _logger.LogInformation(LogMessageConstant.Added, menu.Name);
                    }
                    else
                    {
                        var menu = _mapper.Map<Menu>(menuViewModel);
                        await _uow.Menus.UpdateAsync(id.Value, menu);
                        _logger.LogInformation(LogMessageConstant.Updated, menu.Name);
                    }
                }
            }
            catch (DbUpdateConcurrencyException ce)
            {
                var isExist = await _uow.Menus.GetAsync(id.Value);
                if (isExist == null)
                {
                    _logger.LogWarning(LogMessageConstant.IdNotFound, id);
                    return NotFound();
                }
                else
                {
                    _logger.LogError(ce.Message, id);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);
            }

            return RedirectToAction(nameof(Index));
        }
        public IActionResult Create()
        {
            MenuViewModel menuViewModel = new MenuViewModel
            {
                MenuSelectList = new SelectList(_uow.Menus.MenuSelectList(), "Id", "Name", null)
            };

            return View(menuViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,ControllerName,ActionName,MenuArea,Disable,HasAccess,ParentId")] MenuViewModel menuViewModel)
        {
            if (ModelState.IsValid)
            {
                var menu = _mapper.Map<Menu>(menuViewModel);
                await _uow.Menus.AddAsync(menu);
                return RedirectToAction(nameof(Index));
            }
            menuViewModel.MenuSelectList = new SelectList(_uow.Menus.MenuSelectList(), "Id", "Name", menuViewModel.ParentId);
            return View(menuViewModel);
        }

        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menu = await _uow.Menus.GetAsync(id.Value);
            if (menu == null)
            {
                return NotFound();
            }

            var menuModel = _mapper.Map<MenuViewModel>(menu);
            MenuViewModel menuViewModel = menuModel;
            menuViewModel.MenuSelectList = new SelectList(_uow.Menus.MenuSelectList(), "Id", "Name", menuModel.ParentId);

            return View(menuViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Name,ControllerName,ActionName,MenuArea,Disable,HasAccess,ParentId")] MenuViewModel menuViewModel)
        {
            if (id != menuViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var menu = _mapper.Map<Menu>(menuViewModel);
                    await _uow.Menus.UpdateAsync(id, menu);
                }
                catch (DbUpdateConcurrencyException)
                {
                    var isExist = await _uow.Menus.GetAsync(id);
                    if (isExist == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(menuViewModel);
        }

        public async Task<IActionResult> DeleteMenu(long? id)
        {
            if (id == null)
            {
                _logger.LogWarning(LogMessageConstant.IdIsNull);
                return NotFound();
            }

            var menu = await _uow.Menus.GetAsync(id.Value);
            if (menu == null)
            {
                _logger.LogWarning(LogMessageConstant.ItemNotFound, id);
                return NotFound();
            }

            var menuModel = _mapper.Map<MenuViewModel>(menu);
            string menuName = menuModel.Name;
            return PartialView("~/Areas/Admin/Views/Menu/_DeleteMenu.cshtml", model: menuName);            
        }

        [HttpPost, ActionName("DeleteMenu")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteMenu(long id, IFormCollection form)
        {
            try
            {
                var menu = await _uow.Menus.GetAsync(id);
                await _uow.Menus.DeleteAsync(menu.Id);
                _logger.LogWarning(LogMessageConstant.Deleted, menu.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);
            }
            
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menu = await _uow.Menus.GetAsync(id.Value);
            if (menu == null)
            {
                return NotFound();
            }

            var menuModel = _mapper.Map<MenuViewModel>(menu);
            return View(menuModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var menu = await _uow.Menus.GetAsync(id);
            await _uow.Menus.DeleteAsync(menu.Id);
            return RedirectToAction(nameof(Index));
        }
    }
}
