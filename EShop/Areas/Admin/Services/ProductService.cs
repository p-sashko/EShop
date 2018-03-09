using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB.Areas.Admin.ViewModels;
using WEB.Interfaces;

namespace WEB.Areas.Admin.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _productRepository;

        public ProductService(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public ProductIndexViewModel GetProductItems()
        {
            var data = _productRepository.List();
            var vw = new ProductIndexViewModel()
            {
                ProductItems = data.Select(i => new ProductItemViewModel()
                {
                    Description = i.Description,
                    Name = i.Name,
                    Price = i.Price
                })
            };

            return vw;
        }

    }
}
