using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EShop.DAL.EF
{
    class EShopContext : DbContext
    {
        public DbSet<Product> Phones { get; set; }
    }
}
