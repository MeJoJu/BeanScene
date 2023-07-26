﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BeanScene2.Data;
using BeanScene2.Models;
using BeanScene2.Data.Services;
using Microsoft.AspNetCore.Authorization;

namespace BeanScene2.Controllers
{
    //[Authorize(Roles = "admin")]
    [Authorize]
    public class AreasController : Controller
    {
        private readonly BeanScene2Context _context;
        private readonly IAreasService _service;
       

        public AreasController(BeanScene2Context context, IAreasService service)
        {
            _context = context;
            _service = service;
            
        }

        // GET: Areas
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);

            //return View(await _context.Area.ToListAsync());
            //return View(await _service.GetAllAsync());

            //following error is the way we using async and await. so use above way.
              //return _context.Area.ToListAsync() != null ? 
              //            View(await _context.Area.ToListAsync()) :
              //            Problem("Entity set 'BeanScene2Context.Area'  is null.");
        }

        // GET: Areas/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var areaDetails = await _service.GetByIdAsync(id);
            if(areaDetails == null) return View("NotFound");
            return View(areaDetails);

            //if (id == null || _context.Area == null)
            //{
            //    return NotFound();
            //}

            //var area = await _context.Area
            //    .FirstOrDefaultAsync(m => m.AreaId == id);
            //if (area == null)
            //{
            //    return NotFound();
            //}

            //return View(area);
        }

        // GET: Areas/Create
        [Authorize(Roles = "admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Areas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AreaId,AreaName,Capacity")] Area area)
        {
            if (ModelState.IsValid)
            {
                _context.Add(area);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(area);
        }

        // GET: Areas/Edit/id
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(int id)
        {
            var areaDetails = await _service.GetByIdAsync(id);
            if (areaDetails == null) return View("NotFound");
            return View(areaDetails);
            //if (id == null || _context.Area == null)
            //{
            //    return NotFound();
            //}

            //var area = await _context.Area.FindAsync(id);
            //if (area == null)
            //{
            //    return NotFound();
            //}
            //return View(area);
        }

        // POST: Areas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AreaId,AreaName,Capacity")] Area area)
        {
            if (id != area.AreaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _service.UpdateAsync(id,area);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AreaExists(area.AreaId))
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
            return View(area);
        }

        // GET: Areas/Delete/id
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Area == null)
            {
                return NotFound();
            }

            var area = await _context.Area
                .FirstOrDefaultAsync(m => m.AreaId == id);
            if (area == null)
            {
                return NotFound();
            }

            return View(area);
        }

        // POST: Areas/Delete/5
        [Authorize(Roles = "admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var areaDetails = await _service.GetByIdAsync(id);
            if (areaDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));

            //if (_context.Area == null)
            //{
            //    return Problem("Entity set 'BeanScene2Context.Area'  is null.");
            //}
            //var area = await _context.Area.FindAsync(id);
            //if (area != null)
            //{
            //    _context.Area.Remove(area);
            //}

            //await _context.SaveChangesAsync();
            //return RedirectToAction(nameof(Index));
        }

        private bool AreaExists(int id)
        {
            return (_context.Area?.Any(e => e.AreaId == id)).GetValueOrDefault();
        }
    }
}
