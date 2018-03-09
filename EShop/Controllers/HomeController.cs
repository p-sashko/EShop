using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EShop.Models;
using ApplicationCore.Interfaces;
using EShop.Infrastructure;
using ApplicationCore.Entities;

namespace EShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository<Product> _productRepository;

        public HomeController(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }


        public IActionResult Index()
        {
            //Product np = new Product();

            //np.Name = "Name 2";
            //np.Price = 100; 
            //np.Description = "New product 1";

            //_productRepository.Add(np);

            return RedirectToAction("Index", "Home", new { area = "Admin" });
            //return View();
        }

   

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page. 111";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
