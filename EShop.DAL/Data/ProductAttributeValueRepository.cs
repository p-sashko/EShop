using ApplicationCore.Entities.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using ApplicationCore.Interfaces;
using EShop.Infrastructure.EF;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Infrastructure.Data
{
    public class ProductAttributeValueRepository : EfRepository<ProductAttributeValue>, IProductAttributeValueRepository
    {
        public ProductAttributeValueRepository(EShopContext dbContext) : base(dbContext)
        {
        }

        public ProductAttributeValue GetByIdWithItems(int? id)
        {
            {
                return _dbContext.ProductAttributeValues.Include(o => o.ProductAttribute)
                    //.Include("OrderItems.ItemOrdered")
                    .SingleOrDefault(e => e.Id == id);

            }
        }
    }
}
