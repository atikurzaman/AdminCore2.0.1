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
    public class BrandController : Controller
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public BrandController(IUnitOfWork uow, IMapper mapper, ILogger<BrandController> logger)
        {
            _uow = uow;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Brand> brands = await _uow.Brands.GetAllAsync();
            var brandViewModel = _mapper.Map<IEnumerable<BrandViewModel>>(brands);
            return View(brandViewModel);
        }
        [HttpGet]
        public async Task<IActionResult> AddEditBrand(long? id)
        {
            BrandViewModel brandViewModel = new BrandViewModel();
            if (id.HasValue)
            {
                var brand = await _uow.Brands.GetAsync(id.Value);
                if (brand == null)
                {
                    _logger.LogInformation(LogMessageConstant.ItemNotFound, brandViewModel);
                    return NotFound();
                }

                brandViewModel = _mapper.Map<BrandViewModel>(brand);                  
            }           

            return PartialView("~/Areas/Admin/Views/Brand/_AddEditBrand.cshtml", brandViewModel);
        }

        [HttpPost, ActionName("AddEditBrand")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddEditBrand(long? id, BrandViewModel brandViewModel)
        {
            try
            {
                if (brandViewModel == null)
                {
                    _logger.LogInformation(LogMessageConstant.ItemNotFound, brandViewModel);
                    return NotFound();
                }
                if (ModelState.IsValid)
                {
                    bool isNew = !id.HasValue;
                    if (isNew)
                    {
                        var brand = _mapper.Map<Brand>(brandViewModel);
                        await _uow.Brands.AddAsync(brand);
                        _logger.LogInformation(LogMessageConstant.Added, brand.Name);
                    }
                    else
                    {
                        var brand = _mapper.Map<Brand>(brandViewModel);
                        await _uow.Brands.UpdateAsync(id.Value, brand);
                        _logger.LogInformation(LogMessageConstant.Updated, brand.Name);
                    }
                }
            }
            catch (DbUpdateConcurrencyException ce)
            {
                var isExist = await _uow.Brands.GetAsync(id.Value);
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
        public async Task<IActionResult> DeleteBrand(long? id)
        {
            if (id == null)
            {
                _logger.LogWarning(LogMessageConstant.IdIsNull);
                return NotFound();
            }

            var brand = await _uow.Brands.GetAsync(id.Value);
            if (brand == null)
            {
                _logger.LogWarning(LogMessageConstant.ItemNotFound, id);
                return NotFound();
            }

            var brandViewModel = _mapper.Map<BrandViewModel>(brand);
            string brandName = brandViewModel.Name;
            return PartialView("~/Areas/Admin/Views/Brand/_DeleteBrand.cshtml", model: brandName);
        }

        [HttpPost, ActionName("DeleteBrand")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteBrand(long id, IFormCollection form)
        {
            try
            {
                var brand = await _uow.Brands.GetAsync(id);
                await _uow.Brands.DeleteAsync(brand.Id);
                _logger.LogWarning(LogMessageConstant.Deleted, brand.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}