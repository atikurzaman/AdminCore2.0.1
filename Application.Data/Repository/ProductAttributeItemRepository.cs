using Application.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Data.Repository
{
    public class ProductAttributeItemRepository : Repository<ProductAttributeItem>, IProductAttributeItemRepository
    {
        public ProductAttributeItemRepository(DbContext context) : base(context)
        {
        }
    }
}
