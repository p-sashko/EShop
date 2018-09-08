using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ApplicationCore.Entities.Attributes;
using WEB.Models;
using WEB.Interfaces;

namespace WEB.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdditionalInformationsController : Controller
    {

        private readonly IAdditionalInformationsService _additionalInforService;

        public AdditionalInformationsController(IAdditionalInformationsService additionalInforService)
        {
            _additionalInforService = additionalInforService;
        }

        // GET: Admin/AdditionalInformations
        public IActionResult Index()
        {
            //var wEBContext = _context.AdditionalInformation.Include(a => a.Product).Include(a => a.ProductAttribute).Include(a => a.ProductAttributeValue);
            return View(_additionalInforService.List());
        }

        //// GET: Admin/AdditionalInformations/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var additionalInformation = await _context.AdditionalInformation
        //        .Include(a => a.Product)
        //        .Include(a => a.ProductAttribute)
        //        .Include(a => a.ProductAttributeValue)
        //        .SingleOrDefaultAsync(m => m.Id == id);
        //    if (additionalInformation == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(additionalInformation);
        //}

        //// GET: Admin/AdditionalInformations/Create
        //public IActionResult Create()
        //{
        //    ViewData["ProductId"] = new SelectList(_context.Product, "Id", "Id");
        //    ViewData["ProductAttributeId"] = new SelectList(_context.ProductAttribute, "Id", "Id");
        //    ViewData["ProductAttributeValueId"] = new SelectList(_context.ProductAttributeValue, "Id", "Id");
        //    return View();
        //}

        //// POST: Admin/AdditionalInformations/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("ProductId,ProductAttributeId,ProductAttributeValueId,IntValue,StringValue,Id")] AdditionalInformation additionalInformation)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(additionalInformation);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["ProductId"] = new SelectList(_context.Product, "Id", "Id", additionalInformation.ProductId);
        //    ViewData["ProductAttributeId"] = new SelectList(_context.ProductAttribute, "Id", "Id", additionalInformation.ProductAttributeId);
        //    ViewData["ProductAttributeValueId"] = new SelectList(_context.ProductAttributeValue, "Id", "Id", additionalInformation.ProductAttributeValueId);
        //    return View(additionalInformation);
        //}

        //// GET: Admin/AdditionalInformations/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var additionalInformation = await _context.AdditionalInformation.SingleOrDefaultAsync(m => m.Id == id);
        //    if (additionalInformation == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["ProductId"] = new SelectList(_context.Product, "Id", "Id", additionalInformation.ProductId);
        //    ViewData["ProductAttributeId"] = new SelectList(_context.ProductAttribute, "Id", "Id", additionalInformation.ProductAttributeId);
        //    ViewData["ProductAttributeValueId"] = new SelectList(_context.ProductAttributeValue, "Id", "Id", additionalInformation.ProductAttributeValueId);
        //    return View(additionalInformation);
        //}

        //// POST: Admin/AdditionalInformations/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("ProductId,ProductAttributeId,ProductAttributeValueId,IntValue,StringValue,Id")] AdditionalInformation additionalInformation)
        //{
        //    if (id != additionalInformation.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(additionalInformation);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!AdditionalInformationExists(additionalInformation.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["ProductId"] = new SelectList(_context.Product, "Id", "Id", additionalInformation.ProductId);
        //    ViewData["ProductAttributeId"] = new SelectList(_context.ProductAttribute, "Id", "Id", additionalInformation.ProductAttributeId);
        //    ViewData["ProductAttributeValueId"] = new SelectList(_context.ProductAttributeValue, "Id", "Id", additionalInformation.ProductAttributeValueId);
        //    return View(additionalInformation);
        //}

        //// GET: Admin/AdditionalInformations/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var additionalInformation = await _context.AdditionalInformation
        //        .Include(a => a.Product)
        //        .Include(a => a.ProductAttribute)
        //        .Include(a => a.ProductAttributeValue)
        //        .SingleOrDefaultAsync(m => m.Id == id);
        //    if (additionalInformation == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(additionalInformation);
        //}

        //// POST: Admin/AdditionalInformations/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var additionalInformation = await _context.AdditionalInformation.SingleOrDefaultAsync(m => m.Id == id);
        //    _context.AdditionalInformation.Remove(additionalInformation);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool AdditionalInformationExists(int id)
        //{
        //    return _context.AdditionalInformation.Any(e => e.Id == id);
        //}
    }
}
