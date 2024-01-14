using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Day12.Data;
using Day12.Models;
using System.Data;
using Microsoft.AspNetCore.Authorization;

namespace Day12.Controllers
{
    [Authorize(Roles = "Buyer,Supplier,Investor")]
    public class AddProductsController : Controller
    {
        private readonly MydbContext _context;

        public AddProductsController(MydbContext context)
        {
            _context = context;
        }

        // GET: AddProducts
        public async Task<IActionResult> Index()
        {
              return _context.AddProducts != null ? 
                          View(await _context.AddProducts.ToListAsync()) :
                          Problem("Entity set 'MydbContext.AddProducts'  is null.");
        }

        // GET: AddProducts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AddProducts == null)
            {
                return NotFound();
            }

            var addProducts = await _context.AddProducts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (addProducts == null)
            {
                return NotFound();
            }

            return View(addProducts);
        }

        // GET: AddProducts/Create
        [Authorize(Roles = "Supplier")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: AddProducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Product_Name,Product_Price,Product_Specifiation,Product_Summary")] AddProducts addProducts)
        {
            if (ModelState.IsValid)
            {
                _context.Add(addProducts);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(addProducts);
        }

        // GET: AddProducts/Edit/5
        [Authorize(Roles = "Supplier")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AddProducts == null)
            {
                return NotFound();
            }

            var addProducts = await _context.AddProducts.FindAsync(id);
            if (addProducts == null)
            {
                return NotFound();
            }
            return View(addProducts);
        }

        // POST: AddProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Product_Name,Product_Price,Product_Specifiation,Product_Summary")] AddProducts addProducts)
        {
            if (id != addProducts.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(addProducts);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AddProductsExists(addProducts.Id))
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
            return View(addProducts);
        }

        // GET: AddProducts/Delete/5
        [Authorize(Roles = "Supplier")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AddProducts == null)
            {
                return NotFound();
            }

            var addProducts = await _context.AddProducts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (addProducts == null)
            {
                return NotFound();
            }

            return View(addProducts);
        }

        // POST: AddProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AddProducts == null)
            {
                return Problem("Entity set 'MydbContext.AddProducts'  is null.");
            }
            var addProducts = await _context.AddProducts.FindAsync(id);
            if (addProducts != null)
            {
                _context.AddProducts.Remove(addProducts);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AddProductsExists(int id)
        {
          return (_context.AddProducts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
