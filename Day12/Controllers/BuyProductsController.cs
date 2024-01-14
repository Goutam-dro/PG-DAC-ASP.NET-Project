using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Day12.Data;
using Day12.Models;
using Microsoft.AspNetCore.Authorization;

namespace Day12.Controllers
{
    [Authorize(Roles = "Buyer,Investor")]
    public class BuyProductsController : Controller
    {
        private readonly MydbContext _context;

        public BuyProductsController(MydbContext context)
        {
            _context = context;
        }

        // GET: BuyProducts
        public async Task<IActionResult> Index()
        {
              return _context.BuyProducts != null ? 
                          View(await _context.BuyProducts.ToListAsync()) :
                          Problem("Entity set 'MydbContext.BuyProducts'  is null.");
        }

        // GET: BuyProducts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BuyProducts == null)
            {
                return NotFound();
            }

            var buyProduct = await _context.BuyProducts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (buyProduct == null)
            {
                return NotFound();
            }

            return View(buyProduct);
        }

        // GET: BuyProducts/Create
        [Authorize(Roles = "Buyer")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: BuyProducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Product_Name,Product_Price,Duration,Description")] BuyProduct buyProduct)
        {
            if (ModelState.IsValid)
            {
                _context.Add(buyProduct);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(buyProduct);
        }

        // GET: BuyProducts/Edit/5
        [Authorize(Roles = "Buyer")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BuyProducts == null)
            {
                return NotFound();
            }

            var buyProduct = await _context.BuyProducts.FindAsync(id);
            if (buyProduct == null)
            {
                return NotFound();
            }
            return View(buyProduct);
        }

        // POST: BuyProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Product_Name,Product_Price,Duration,Description")] BuyProduct buyProduct)
        {
            if (id != buyProduct.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(buyProduct);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BuyProductExists(buyProduct.Id))
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
            return View(buyProduct);
        }

        // GET: BuyProducts/Delete/5
        [Authorize(Roles = "Buyer")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BuyProducts == null)
            {
                return NotFound();
            }

            var buyProduct = await _context.BuyProducts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (buyProduct == null)
            {
                return NotFound();
            }

            return View(buyProduct);
        }

        // POST: BuyProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BuyProducts == null)
            {
                return Problem("Entity set 'MydbContext.BuyProducts'  is null.");
            }
            var buyProduct = await _context.BuyProducts.FindAsync(id);
            if (buyProduct != null)
            {
                _context.BuyProducts.Remove(buyProduct);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BuyProductExists(int id)
        {
          return (_context.BuyProducts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
