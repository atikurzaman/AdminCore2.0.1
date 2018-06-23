using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Domain
{
    public class ProductAttribute: BaseEntity
    {
        public string Name { get; set; }      

        public string OrderBy { get; set; }

        public Boolean Status { get; set; }

        public ICollection<ProductAttributeItem> ProductAttributeItems { get; set; }

    }
}
