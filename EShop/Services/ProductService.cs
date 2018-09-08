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

        public void Add(ProductItemViewModel productItem)
        {
            Product product = new Product();

            product.Description = productItem.Description;
            product.Name = productItem.Name;
            product.Price = productItem.Price;

            _productRepository.Add(product);

        }

        public void Delete(Int32? id)
        {
            Product product = _productRepository.GetById(id);

            _productRepository.Delete(product);
        }

        public ProductItemViewModel GetById(int? id)
        {
            Product product = _productRepository.GetById(id);
            ProductItemViewModel productItem = new ProductItemViewModel();

            productItem.Description = product.Description;
            productItem.Name = product.Name;
            productItem.Price = product.Price;

            return productItem;
        }

        public ProductIndexViewModel GetItems()
        {
            var data = _productRepository.List();
            var vw = new ProductIndexViewModel()
            {
                ProductItems = data.Select(i => new ProductItemViewModel()
                {
                    Id = i.Id,
                    Description = i.Description,
                    Name = i.Name,
                    Price = i.Price
                })
            };

            return vw;
        }

        public void Update(ProductItemViewModel productItem)
        {
            Product product = new Product();

            product.Id = productItem.Id;
            product.Description = productItem.Description;
            product.Name = productItem.Name;
            product.Price = productItem.Price;

            _productRepository.Update(product);
        }
    }
}
