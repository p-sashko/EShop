using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB.Areas.Admin.ViewModels;

namespace WEB.Interfaces
{
    public interface IProductService
    {
        ProductIndexViewModel GetProductItems();
    }
}
