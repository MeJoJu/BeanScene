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
    public class ReservationsController : Controller
    {
        private readonly BeanScene2Context _context;

        public ReservationsController(BeanScene2Context context)
        {
            _context = context;
        }

        // GET: Reservations
        public async Task<IActionResult> Index()
        {
            var beanScene2Context = _context.Reservation.Include(r => r.Customer).Include(r => r.Sitting).Include(r => r.Table);
            return View(await beanScene2Context.ToListAsync());
        }

        // GET: Reservations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Reservation == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservation
                .Include(r => r.Customer)
                .Include(r => r.Sitting)
                .Include(r => r.Table)
                .FirstOrDefaultAsync(m => m.ReservationId == id);
            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }

        // GET: Reservations/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "CustomerId");
            ViewData["SittingId"] = new SelectList(_context.Set<Sitting>(), "SittingId", "SittingId");
            ViewData["TableId"] = new SelectList(_context.Set<Table>(), "TableId", "TableId");
            return View();
        }

        // POST: Reservations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReservationId,SittingDate,StartTime,EndTIme,NumberOfGuest,ReservationStatus,CustomerId,SittingId,TableId")] Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reservation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "CustomerId", reservation.CustomerId);
            ViewData["SittingId"] = new SelectList(_context.Set<Sitting>(), "SittingId", "SittingId", reservation.SittingId);
            ViewData["TableId"] = new SelectList(_context.Set<Table>(), "TableId", "TableId", reservation.TableId);
            return View(reservation);
        }

        // GET: Reservations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Reservation == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservation.FindAsync(id);
            if (reservation == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "CustomerId", reservation.CustomerId);
            ViewData["SittingId"] = new SelectList(_context.Set<Sitting>(), "SittingId", "SittingId", reservation.SittingId);
            ViewData["TableId"] = new SelectList(_context.Set<Table>(), "TableId", "TableId", reservation.TableId);
            return View(reservation);
        }

        // POST: Reservations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReservationId,SittingDate,StartTime,EndTIme,NumberOfGuest,ReservationStatus,CustomerId,SittingId,TableId")] Reservation reservation)
        {
            if (id != reservation.ReservationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reservation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservationExists(reservation.ReservationId))
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
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "CustomerId", reservation.CustomerId);
            ViewData["SittingId"] = new SelectList(_context.Set<Sitting>(), "SittingId", "SittingId", reservation.SittingId);
            ViewData["TableId"] = new SelectList(_context.Set<Table>(), "TableId", "TableId", reservation.TableId);
            return View(reservation);
        }

        // GET: Reservations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Reservation == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservation
                .Include(r => r.Customer)
                .Include(r => r.Sitting)
                .Include(r => r.Table)
                .FirstOrDefaultAsync(m => m.ReservationId == id);
            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }

        // POST: Reservations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Reservation == null)
            {
                return Problem("Entity set 'BeanScene2Context.Reservation'  is null.");
            }
            var reservation = await _context.Reservation.FindAsync(id);
            if (reservation != null)
            {
                _context.Reservation.Remove(reservation);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservationExists(int id)
        {
          return (_context.Reservation?.Any(e => e.ReservationId == id)).GetValueOrDefault();
        }
    }
}
