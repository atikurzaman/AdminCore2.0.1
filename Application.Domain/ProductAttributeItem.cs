using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Application.Domain
{
    public class ProductAttributeItem : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public Boolean Status { get; set; }

        [ForeignKey(nameof(ProductAttribute))]
        public Int64 ProductAttributeId { get; set; }

        public ProductAttribute ProductAttribute { get; set; }
    }
}
