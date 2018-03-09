using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ApplicationCore.Entities;
using ApplicationCore.Entities.Attributes;

namespace WEB.Models
{
    public class WEBContext : DbContext
    {
        public WEBContext (DbContextOptions<WEBContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Product { get; set; }

        public DbSet<ProductAttribute> ProductAttribute { get; set; }

        public DbSet<ProductAttributeValue> ProductAttributeValue { get; set; }
    }
}
