﻿using System;
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
    [Authorize(Roles = "admin")]
    public class PermissionsController : Controller
    {
        private readonly BeanScene2Context _context;

        public PermissionsController(BeanScene2Context context)
        {
            _context = context;
        }

        // GET: Permissions
        public async Task<IActionResult> Index()
        {
              return _context.Permission != null ? 
                          View(await _context.Permission.ToListAsync()) :
                          Problem("Entity set 'BeanScene2Context.Permission'  is null.");
        }

        // GET: Permissions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Permission == null)
            {
                return NotFound();
            }

            var permission = await _context.Permission
                .FirstOrDefaultAsync(m => m.PermissionId == id);
            if (permission == null)
            {
                return NotFound();
            }

            return View(permission);
        }

        // GET: Permissions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Permissions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PermissionId,CanRead,CanCreate,CanUpdate,CanDelete")] Permission permission)
        {
            if (ModelState.IsValid)
            {
                _context.Add(permission);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(permission);
        }

        // GET: Permissions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Permission == null)
            {
                return NotFound();
            }

            var permission = await _context.Permission.FindAsync(id);
            if (permission == null)
            {
                return NotFound();
            }
            return View(permission);
        }

        // POST: Permissions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PermissionId,CanRead,CanCreate,CanUpdate,CanDelete")] Permission permission)
        {
            if (id != permission.PermissionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(permission);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PermissionExists(permission.PermissionId))
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
            return View(permission);
        }

        // GET: Permissions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Permission == null)
            {
                return NotFound();
            }

            var permission = await _context.Permission
                .FirstOrDefaultAsync(m => m.PermissionId == id);
            if (permission == null)
            {
                return NotFound();
            }

            return View(permission);
        }

        // POST: Permissions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Permission == null)
            {
                return Problem("Entity set 'BeanScene2Context.Permission'  is null.");
            }
            var permission = await _context.Permission.FindAsync(id);
            if (permission != null)
            {
                _context.Permission.Remove(permission);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PermissionExists(int id)
        {
          return (_context.Permission?.Any(e => e.PermissionId == id)).GetValueOrDefault();
        }
    }
}
