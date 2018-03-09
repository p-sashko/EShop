using ApplicationCore.Entities;
using ApplicationCore.Entities.Attributes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EShop.Infrastructure.EF
{
    public class EShopContext : DbContext
    {
        public EShopContext(DbContextOptions<EShopContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<AdditionalInformation> AdditionalInformations { get; set; }
        public DbSet<ProductAttribute> ProductAttributes { get; set; }
        public DbSet<ProductAttributeValue> ProductAttributeValues { get; set; }
    }

}
  