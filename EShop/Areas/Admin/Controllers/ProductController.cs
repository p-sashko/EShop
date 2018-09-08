using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WEB.Interfaces;
using WEB.Areas.Admin.ViewModels;
using Microsoft.EntityFrameworkCore;

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
            var productModel = _productService.GetItems();

            return View(productModel);
        }
         //333cff hhh
        // GET: Admin/ProductAttributeValues/Create rrr
        public IActionResult Create()
        {
            return View("CreateEdit");
        }


        // POST: Admin/ProductAttributeValues/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Name,Description,Price")] ProductItemViewModel productItem)
        {
            if (ModelState.IsValid)
            {
                _productService.Add(productItem);
                return RedirectToAction(nameof(List));
            }

            return View("CreateEdit", productItem);
        }


        // GET: Admin/ProductAttributeValues/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var productAttributeValue = _context.ProductAttributeValue.SingleOrDefault(m => m.Id == id);
            var productAttributeValue = _productService.GetById(id);
            if (productAttributeValue == null)
            {
                return NotFound();
            }

            ViewBag.isEdit = true;
            return View("CreateEdit", productAttributeValue);
        }

        // POST: Admin/ProductAttributeValues/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Name,Description,Price")] ProductItemViewModel productItem)
        {
            if (id != productItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _productService.Update(productItem);
                }
                catch (DbUpdateConcurrencyException)
                {
                    //if (!ProductAttributeValueExists(productAttributeValue.Id))
                    //{
                    //    return NotFound();
                    //}
                    //else
                    //{
                    //    throw;
                    //}
                }
                return RedirectToAction(nameof(List));
            }

            return View("CreateEdit", productItem);
        }

        // GET: Admin/ProductAttributeValues/Delete/5
        public IActionResult Delete(Int32? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var productItem = _productService.GetById(id);

            if (productItem == null)
            {
                return NotFound();
            }

            return View(productItem);

        }

        // POST: Admin/ProductAttributeValues/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _productService.Delete(id);
            return RedirectToAction(nameof(List));
        }

    }
}