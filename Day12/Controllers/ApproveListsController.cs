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
    [Authorize(Roles = "Buyer,Investor,Supplier")]
    public class ApproveListsController : Controller
    {
        private readonly MydbContext _context;

        public ApproveListsController(MydbContext context)
        {
            _context = context;
        }

        // GET: ApproveLists
        public async Task<IActionResult> Index()
        {
              return _context.ApproveLists != null ? 
                          View(await _context.ApproveLists.ToListAsync()) :
                          Problem("Entity set 'MydbContext.ApproveLists'  is null.");
        }

        // GET: ApproveLists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ApproveLists == null)
            {
                return NotFound();
            }

            var approveList = await _context.ApproveLists
                .FirstOrDefaultAsync(m => m.Id == id);
            if (approveList == null)
            {
                return NotFound();
            }

            return View(approveList);
        }

        // GET: ApproveLists/Create
        [Authorize(Roles = "Investor")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: ApproveLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Buyer_Name,Product_Name,Product_Price")] ApproveList approveList)
        {
            if (ModelState.IsValid)
            {
                _context.Add(approveList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(approveList);
        }

        // GET: ApproveLists/Edit/5
        [Authorize(Roles = "Investor")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ApproveLists == null)
            {
                return NotFound();
            }

            var approveList = await _context.ApproveLists.FindAsync(id);
            if (approveList == null)
            {
                return NotFound();
            }
            return View(approveList);
        }

        // POST: ApproveLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Buyer_Name,Product_Name,Product_Price")] ApproveList approveList)
        {
            if (id != approveList.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(approveList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApproveListExists(approveList.Id))
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
            return View(approveList);
        }

        // GET: ApproveLists/Delete/5
        [Authorize(Roles = "Investor")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ApproveLists == null)
            {
                return NotFound();
            }

            var approveList = await _context.ApproveLists
                .FirstOrDefaultAsync(m => m.Id == id);
            if (approveList == null)
            {
                return NotFound();
            }

            return View(approveList);
        }

        // POST: ApproveLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ApproveLists == null)
            {
                return Problem("Entity set 'MydbContext.ApproveLists'  is null.");
            }
            var approveList = await _context.ApproveLists.FindAsync(id);
            if (approveList != null)
            {
                _context.ApproveLists.Remove(approveList);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApproveListExists(int id)
        {
          return (_context.ApproveLists?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
