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
    public class ProductAttributeValuesController : Controller
    {
        
        private readonly IRepository<ProductAttribute> _productAttributeRepository;
        private readonly IProductAttributeValueRepository _productAttributeValueRepository;

        public ProductAttributeValuesController(IRepository<ProductAttribute> productAttributeRepository, IProductAttributeValueRepository productAttributeValueRepository)
        {
            _productAttributeRepository = productAttributeRepository;
            _productAttributeValueRepository = productAttributeValueRepository;
        }

        // GET: Admin/ProductAttributeValues
        public IActionResult Index()
        {
            //var wEBContext = _context.ProductAttributeValue.Include(p => p.ProductAttribute);
            return View(_productAttributeValueRepository.List());
        }

        // GET: Admin/ProductAttributeValues/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var productAttributeValue = _context.ProductAttributeValue
            //    .Include(p => p.ProductAttribute)
            //    .SingleOrDefault(m => m.Id == id);

            var productAttributeValue = _productAttributeValueRepository.GetById(id);

            if (productAttributeValue == null)
            {
                return NotFound();
            }

            return View(productAttributeValue);
        }

        // GET: Admin/ProductAttributeValues/Create
        public IActionResult Create()
        {
            ViewData["ProductAttributeId"] = new SelectList(_productAttributeRepository.List().Where(a=>a.ValueType == AttributeValueType.ObjectValue), "Id", "Name");
            return View();
        }

        // POST: Admin/ProductAttributeValues/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("ProductAttributeId,ValueString,Id")] ProductAttributeValue productAttributeValue)
        {
            if (ModelState.IsValid)
            {
                _productAttributeValueRepository.Add(productAttributeValue);
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductAttributeId"] = new SelectList(_productAttributeRepository.List().Where(a => a.ValueType == AttributeValueType.ObjectValue), "Id", "Name");
            return View(productAttributeValue);
        }

        // GET: Admin/ProductAttributeValues/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var productAttributeValue = _context.ProductAttributeValue.SingleOrDefault(m => m.Id == id);
            var productAttributeValue = _productAttributeValueRepository.GetByIdWithItems(id);
            if (productAttributeValue == null)
            {
                return NotFound();
            }

            ViewData["ProductAttributeId"] = new SelectList(_productAttributeRepository.List().Where(a => a.ValueType == AttributeValueType.ObjectValue), "Id", "Name", productAttributeValue.ProductAttributeId);
            return View("Create", productAttributeValue);
        }

        // POST: Admin/ProductAttributeValues/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("ProductAttributeId,ValueString,Id")] ProductAttributeValue productAttributeValue)
        {
            if (id != productAttributeValue.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _productAttributeValueRepository.Update(productAttributeValue);
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
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductAttributeId"] = new SelectList(_productAttributeRepository.List().Where(a => a.ValueType == AttributeValueType.ObjectValue), "Id", "Name", productAttributeValue.ProductAttributeId);
            return View("Create", productAttributeValue);
        }

        // GET: Admin/ProductAttributeValues/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productAttributeValue = _productAttributeValueRepository.GetByIdWithItems(id);
            if (productAttributeValue == null)
            {
                return NotFound();
            }

            return View(productAttributeValue);
        }

        // POST: Admin/ProductAttributeValues/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var productAttributeValue = _productAttributeRepository.GetById(id);
            _productAttributeRepository.Delete(productAttributeValue);

            return RedirectToAction(nameof(Index));
        }

        //private bool ProductAttributeValueExists(int id)
        //{
        //    return _context.ProductAttributeValue.Any(e => e.Id == id);
        //}
    }
}
