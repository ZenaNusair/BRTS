using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BRTS_System.Date;
using BRTS_System.Models;

namespace BRTS_System.Controllers
{
    public class TripController : Controller
    {
        private readonly SystemDbContext _context;

        public TripController(SystemDbContext context)
        {
            _context = context;
        }

        // GET: Trip
        public async Task<IActionResult> Index()
        {
              return _context.trip != null ? 
                          View(await _context.trip.ToListAsync()) :
                          Problem("Entity set 'SystemDbContext.trip'  is null.");
        }

        // GET: Trip/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.trip == null)
            {
                return NotFound();
            }

            var trip = await _context.trip
                .FirstOrDefaultAsync(m => m.TripID == id);
            if (trip == null)
            {
                return NotFound();
            }

            return View(trip);
        }

        // GET: Trip/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TripController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Trip trip)
        {
            try
            {
                int adminId = (int)HttpContext.Session.GetInt32("adminID");

                Admin admin = _context.admin.Where(
                    a => a.ID == adminId
                    ).FirstOrDefault();

                trip.Admin = admin;

                _context.trip.Add(trip);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TripController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }
        // GET: Trip/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.trip == null)
            {
                return NotFound();
            }

            var trip = await _context.trip.FindAsync(id);
            if (trip == null)
            {
                return NotFound();
            }
            return View(trip);
        }

        // POST: Trip/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TripID,Destination,EndData,StartData,BusNumber")] Trip trip)
        {
            if (id != trip.TripID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trip);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TripExists(trip.TripID))
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
            return View(trip);
        }

        // GET: Trip/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.trip == null)
            {
                return NotFound();
            }

            var trip = await _context.trip
                .FirstOrDefaultAsync(m => m.TripID == id);
            if (trip == null)
            {
                return NotFound();
            }

            return View(trip);
        }

        // POST: Trip/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.trip == null)
            {
                return Problem("Entity set 'SystemDbContext.trip'  is null.");
            }
            var trip = await _context.trip.FindAsync(id);
            if (trip != null)
            {
                _context.trip.Remove(trip);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TripExists(int id)
        {
          return (_context.trip?.Any(e => e.TripID == id)).GetValueOrDefault();
        }
    }
}
