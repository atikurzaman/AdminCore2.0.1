using Application.Domain;
using Application.Web.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Web.MappingDTO
{
    public class ApplicationProfile: AutoMapper.Profile
    {
        public ApplicationProfile()
        {
            CreateMap<Menu, MenuViewModel>().ReverseMap();
            CreateMap<Category, CategoryViewModel>().ReverseMap();
            CreateMap<Brand, BrandViewModel>().ReverseMap();
            CreateMap<ProductAttribute, ProductAttributeViewModel>().ReverseMap();
            CreateMap<ProductAttributeItem, ProductAttributeItemViewModel>().ReverseMap();
        }
    }
}
