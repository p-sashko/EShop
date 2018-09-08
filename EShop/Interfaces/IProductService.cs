using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB.Areas.Admin.ViewModels;

namespace WEB.Interfaces
{
    public interface IProductService
    {
        ProductIndexViewModel GetItems();

        void Add(ProductItemViewModel productItem);

        void Delete(Int32? id);

        ProductItemViewModel GetById(Int32? id);

        void Update(ProductItemViewModel productItem);
    }
}
