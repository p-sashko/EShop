using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WEB.Interfaces;

namespace WEB.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
             _productService = productService;
        }

        public IActionResult List()
        {
               var productModel = _productService.GetProductItems();
            return View(productModel);
        }
    }
}