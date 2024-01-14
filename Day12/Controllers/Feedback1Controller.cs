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
    [Authorize(Roles = "Buyer,Supplier,Investor,Admin")]
    public class Feedback1Controller : Controller
    {
        private readonly MydbContext _context;

        public Feedback1Controller(MydbContext context)
        {
            _context = context;
        }

        // GET: Feedback1
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
              return _context.Feedback1s != null ? 
                          View(await _context.Feedback1s.ToListAsync()) :
                          Problem("Entity set 'MydbContext.Feedback1s'  is null.");
        }

        // GET: Feedback1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Feedback1s == null)
            {
                return NotFound();
            }

            var feedback1 = await _context.Feedback1s
                .FirstOrDefaultAsync(m => m.Id == id);
            if (feedback1 == null)
            {
                return NotFound();
            }

            return View(feedback1);
        }

        // GET: Feedback1/Create
        [Authorize(Roles = "Buyer,Supplier,Investor")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Feedback1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Email,Mobile_Number,Feedback")] Feedback1 feedback1)
        {
            if (ModelState.IsValid)
            {
                _context.Add(feedback1);
                await _context.SaveChangesAsync();
                 return RedirectToAction(nameof(Index));
               // return RedirectToAction(nameof(Details));
            }
            return View(feedback1);
        }

        // GET: Feedback1/Edit/5
        [Authorize(Roles = "Buyer,Supplier,Investor")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Feedback1s == null)
            {
                return NotFound();
            }

            var feedback1 = await _context.Feedback1s.FindAsync(id);
            if (feedback1 == null)
            {
                return NotFound();
            }
            return View(feedback1);
        }

        // POST: Feedback1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email,Mobile_Number,Feedback")] Feedback1 feedback1)
        {
            if (id != feedback1.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(feedback1);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Feedback1Exists(feedback1.Id))
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
            return View(feedback1);
        }

        // GET: Feedback1/Delete/5
        [Authorize(Roles = "Buyer,Supplier,Investor")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Feedback1s == null)
            {
                return NotFound();
            }

            var feedback1 = await _context.Feedback1s
                .FirstOrDefaultAsync(m => m.Id == id);
            if (feedback1 == null)
            {
                return NotFound();
            }

            return View(feedback1);
        }

        // POST: Feedback1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Feedback1s == null)
            {
                return Problem("Entity set 'MydbContext.Feedback1s'  is null.");
            }
            var feedback1 = await _context.Feedback1s.FindAsync(id);
            if (feedback1 != null)
            {
                _context.Feedback1s.Remove(feedback1);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Feedback1Exists(int id)
        {
          return (_context.Feedback1s?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
