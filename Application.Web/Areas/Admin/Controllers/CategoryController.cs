using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Data.UnitOfWork;
using Application.Domain;
using Application.Web.Areas.Admin.Models;
using Application.Web.Common;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : BaseController
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public CategoryController(IUnitOfWork uow, IMapper mapper, ILogger<CategoryController> logger)
        {
            _uow = uow;
            _mapper = mapper;
            _logger = logger;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> categories = _uow.Categories.GetCategoryParentName();
            var categoryViewModel = _mapper.Map<IEnumerable<CategoryViewModel>>(categories);
            return View(categoryViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> AddEditCategory(long? id)
        {
            CategoryViewModel categoryViewModel = new CategoryViewModel();
            if (id.HasValue)
            {
                var category = await _uow.Categories.GetAsync(id.Value);
                if (category == null)
                {
                    _logger.LogInformation(LogMessageConstant.ItemNotFound, categoryViewModel);
                    return NotFound();
                }

                var categoryModel = _mapper.Map<CategoryViewModel>(category);
                categoryViewModel = categoryModel;
                categoryViewModel.CategorySelectList = new SelectList(_uow.Categories.CategorySelectList(), "Id", "Name", categoryModel.ParentCategoryId);
            }
            else
            {
                categoryViewModel.CategorySelectList = new SelectList(_uow.Categories.CategorySelectList(), "Id", "Name", null);
            }

            return PartialView("~/Areas/Admin/Views/Category/_AddEditCategory.cshtml", categoryViewModel);
        }

        [HttpPost, ActionName("AddEditCategory")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddEditMenu(long? id, CategoryViewModel categoryViewModel)
        {
            try
            {
                if (categoryViewModel == null)
                {
                    _logger.LogInformation(LogMessageConstant.ItemNotFound, categoryViewModel);
                    return NotFound();
                }
                if (ModelState.IsValid)
                {
                    bool isNew = !id.HasValue;
                    if (isNew)
                    {   
                        var category = _mapper.Map<Category>(categoryViewModel);                       
                        await _uow.Categories.AddAsync(category);
                        _logger.LogInformation(LogMessageConstant.Added, category.Name);
                    }
                    else
                    {
                        var category = _mapper.Map<Category>(categoryViewModel);
                        await _uow.Categories.UpdateAsync(id.Value, category);
                        _logger.LogInformation(LogMessageConstant.Updated, category.Name);
                    }
                }
            }
            catch (DbUpdateConcurrencyException ce)
            {
                var isExist = await _uow.Categories.GetAsync(id.Value);
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
        public async Task<IActionResult> DeleteCategory(long? id)
        {
            if (id == null)
            {
                _logger.LogWarning(LogMessageConstant.IdIsNull);
                return NotFound();
            }

            var category = await _uow.Categories.GetAsync(id.Value);
            if (category == null)
            {
                _logger.LogWarning(LogMessageConstant.ItemNotFound, id);
                return NotFound();
            }

            var categoryModel = _mapper.Map<CategoryViewModel>(category);
            string categoryName = categoryModel.Name;
            return PartialView("~/Areas/Admin/Views/Category/_DeleteCategory.cshtml", model: categoryName);
        }

        [HttpPost, ActionName("DeleteCategory")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteCategory(long id, IFormCollection form)
        {
            try
            {
                var category = await _uow.Categories.GetAsync(id);
                await _uow.Categories.DeleteAsync(category.Id);
                _logger.LogWarning(LogMessageConstant.Deleted, category.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}