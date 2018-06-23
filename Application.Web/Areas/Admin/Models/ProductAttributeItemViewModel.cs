using Application.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Web.Areas.Admin.Models
{
    public class ProductAttributeItemViewModel:BaseEntityViewModel
    {        

        [Required,MaxLength(128)]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public Boolean Status { get; set; }

        [Required]
        public Int64 ProductAttributeId { get; set; }

        public ProductAttribute ProductAttribute { get; set; }
    }
}
