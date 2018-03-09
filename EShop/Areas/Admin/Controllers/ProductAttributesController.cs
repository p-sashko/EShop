using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ApplicationCore.Entities.Attributes;
using WEB.Models;
using ApplicationCore.Interfaces;

namespace WEB.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductAttributesController : Controller
    {
        private readonly IRepository<ProductAttribute> _context;

        public ProductAttributesController(IRepository<ProductAttribute> context)
        {
            _context = context;
        }

        // GET: Admin/ProductAttributes
        public IActionResult Index()
        {
            return View(_context.List());
        }

        // GET: Admin/ProductAttributes/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productAttribute =  _context.GetById(id);
            if (productAttribute == null)
            {
                return NotFound();
            }

            return View(productAttribute);
        }

        // GET: Admin/ProductAttributes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/ProductAttributes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult Create([Bind("Name,ValueType,Id")] ProductAttribute productAttribute)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productAttribute);
                return RedirectToAction(nameof(Index));
            }
            return View(productAttribute);
        }

        // GET: Admin/ProductAttributes/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productAttribute =  _context.GetById(id);
            if (productAttribute == null)
            {
                return NotFound();
            }
            return View("Create", productAttribute);
        }

        // POST: Admin/ProductAttributes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Name,ValueType,Id")] ProductAttribute productAttribute)
        {
            if (id != productAttribute.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productAttribute);
                }
                catch (DbUpdateConcurrencyException)
                {
                    //if (!ProductAttributeExists(productAttribute.Id))
                    if(_context.GetById(id) == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View("Create", productAttribute);
        }

        // GET: Admin/ProductAttributes/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productAttribute =  _context.GetById(id);
            if (productAttribute == null)
            {
                return NotFound();
            }

            return View(productAttribute);
        }

        // POST: Admin/ProductAttributes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var productAttribute =  _context.GetById(id);
            _context.Delete(productAttribute);
            return RedirectToAction(nameof(Index));
        }

        //private bool ProductAttributeExists(int id)
        //{
        //    return _context.ProductAttribute.Any(e => e.Id == id);
        //}
    }
}
