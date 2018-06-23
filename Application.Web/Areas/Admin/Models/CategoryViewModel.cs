using Application.Domain;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Web.Areas.Admin.Models
{
    public class CategoryViewModel:BaseEntityViewModel
    {       

        [Required,MaxLength(256)]
        public string Name { get; set; }

        [DisplayName("Parent Category")]
        public Int64? ParentCategoryId { get; set; }
        public virtual Category ParentCategory { get; set; }
        public SelectList CategorySelectList { get; set; }

        [DisplayName("Parent Category")]
        public string ParentCategoryName { get; set; }
    }
}
