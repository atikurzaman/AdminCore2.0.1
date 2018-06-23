using Application.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Web.Areas.Admin.Models
{
    public class ProductAttributeViewModel : BaseEntityViewModel
    {
        [Required, MaxLength(128)]
        public string Name { get; set; }

        [Required, MaxLength(128)]
        public string OrderBy { get; set; }

        [Required]
        public Boolean Status { get; set; }

        public ICollection<ProductAttributeItem> ProductAttributeItems { get; set; }
    }
}
