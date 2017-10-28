using System;
using System.Collections.Generic;
using System.Text;

namespace EShop.DAL
{
    class Product : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int Price { get; set; }

    }
}
