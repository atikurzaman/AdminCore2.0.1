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
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductAttributeController : Controller
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public ProductAttributeController(IUnitOfWork uow, IMapper mapper, ILogger<CategoryController> logger)
        {
            _uow = uow;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<ProductAttribute> productAttributes = await _uow.ProductAttributes.GetAllAsync();
            var productAttributeViewModel = _mapper.Map<IEnumerable<ProductAttributeViewModel>>(productAttributes);
            return View(productAttributeViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> AddEditProductAttribute(long? id)
        {
            ProductAttributeViewModel productAttributeViewModel = new ProductAttributeViewModel();
            if (id.HasValue)
            {
                var productAttribute = await _uow.ProductAttributes.GetAsync(id.Value);
                if (productAttribute == null)
                {
                    _logger.LogInformation(LogMessageConstant.ItemNotFound, productAttributeViewModel);
                    return NotFound();
                }

                productAttributeViewModel = _mapper.Map<ProductAttributeViewModel>(productAttribute);
            }

            return PartialView("~/Areas/Admin/Views/ProductAttribute/_AddEditProductAttribute.cshtml", productAttributeViewModel);
        }

        [HttpPost, ActionName("AddEditProductAttribute")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddEditProductAttribute(long? id, ProductAttributeViewModel productAttributeViewModel)
        {
            try
            {
                if (productAttributeViewModel == null)
                {
                    _logger.LogInformation(LogMessageConstant.ItemNotFound, productAttributeViewModel);
                    return NotFound();
                }
                if (ModelState.IsValid)
                {
                    bool isNew = !id.HasValue;
                    if (isNew)
                    {
                        var productAttribute = _mapper.Map<ProductAttribute>(productAttributeViewModel);
                        await _uow.ProductAttributes.AddAsync(productAttribute);
                        _logger.LogInformation(LogMessageConstant.Added, productAttribute.Name);
                    }
                    else
                    {
                        var productAttribute = _mapper.Map<ProductAttribute>(productAttributeViewModel);
                        await _uow.ProductAttributes.UpdateAsync(id.Value, productAttribute);
                        _logger.LogInformation(LogMessageConstant.Updated, productAttribute.Name);
                    }
                }
            }
            catch (DbUpdateConcurrencyException ce)
            {
                var isExist = await _uow.ProductAttributes.GetAsync(id.Value);
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
        public async Task<IActionResult> DeleteProductAttribute(long? id)
        {
            if (id == null)
            {
                _logger.LogWarning(LogMessageConstant.IdIsNull);
                return NotFound();
            }

            var productAttribute = await _uow.ProductAttributes.GetAsync(id.Value);
            if (productAttribute == null)
            {
                _logger.LogWarning(LogMessageConstant.ItemNotFound, id);
                return NotFound();
            }

            var productAttributeViewModel = _mapper.Map<ProductAttributeViewModel>(productAttribute);
            string brandName = productAttributeViewModel.Name;
            return PartialView("~/Areas/Admin/Views/ProductAttribute/_DeleteProductAttribute.cshtml", model: brandName);
        }

        [HttpPost, ActionName("DeleteProductAttribute")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteBrand(long id, IFormCollection form)
        {
            try
            {
                var productAttribute = await _uow.ProductAttributes.GetAsync(id);
                await _uow.ProductAttributes.DeleteAsync(productAttribute.Id);
                _logger.LogWarning(LogMessageConstant.Deleted, productAttribute.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}