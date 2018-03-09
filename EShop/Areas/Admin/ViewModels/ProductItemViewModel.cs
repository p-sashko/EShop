using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB.Areas.Admin.ViewModels
{
    public class ProductItemViewModel : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int Price { get; set; }
    }
}
