using ApplicationCore.Entities.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Interfaces
{
    public interface IProductAttributeValueRepository : IRepository<ProductAttributeValue>
    {
        ProductAttributeValue GetByIdWithItems(int? id);
    }
}
