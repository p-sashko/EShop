using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB.Areas.Admin.ViewModels
{
    public class ProductIndexViewModel 
    {
        public IEnumerable<ProductItemViewModel> ProductItems { get; set; }
    }
}
