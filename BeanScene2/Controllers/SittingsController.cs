using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BeanScene2.Data;
using BeanScene2.Models;
using Microsoft.AspNetCore.Authorization;

namespace BeanScene2.Controllers
{
    [Authorize]
    public class SittingsController : Controller
    {
        private readonly BeanScene2Context _context;

        public SittingsController(BeanScene2Context context)
        {
            _context = context;
        }

        // GET: Sittings
        public async Task<IActionResult> Index()
        {
              return _context.Sitting != null ? 
                          View(await _context.Sitting.ToListAsync()) :
                          Problem("Entity set 'BeanScene2Context.Sitting'  is null.");
        }

        // GET: Sittings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Sitting == null)
            {
                return NotFound();
            }

            var sitting = await _context.Sitting
                .FirstOrDefaultAsync(m => m.SittingId == id);
            if (sitting == null)
            {
                return NotFound();
            }

            return View(sitting);
        }

        // GET: Sittings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sittings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SittingId,SittingType")] Sitting sitting)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sitting);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sitting);
        }

        // GET: Sittings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Sitting == null)
            {
                return NotFound();
            }

            var sitting = await _context.Sitting.FindAsync(id);
            if (sitting == null)
            {
                return NotFound();
            }
            return View(sitting);
        }

        // POST: Sittings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SittingId,SittingType")] Sitting sitting)
        {
            if (id != sitting.SittingId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sitting);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SittingExists(sitting.SittingId))
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
            return View(sitting);
        }

        // GET: Sittings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Sitting == null)
            {
                return NotFound();
            }

            var sitting = await _context.Sitting
                .FirstOrDefaultAsync(m => m.SittingId == id);
            if (sitting == null)
            {
                return NotFound();
            }

            return View(sitting);
        }

        // POST: Sittings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Sitting == null)
            {
                return Problem("Entity set 'BeanScene2Context.Sitting'  is null.");
            }
            var sitting = await _context.Sitting.FindAsync(id);
            if (sitting != null)
            {
                _context.Sitting.Remove(sitting);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SittingExists(int id)
        {
          return (_context.Sitting?.Any(e => e.SittingId == id)).GetValueOrDefault();
        }
    }
}
