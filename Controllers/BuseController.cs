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
    public class BuseController : Controller
    {
        private readonly SystemDbContext _context;

        public BuseController(SystemDbContext context)
        {
            _context = context;
        }

        // GET: Buse
        public async Task<IActionResult> Index()
        {
              return _context.bus != null ? 
                          View(await _context.bus.ToListAsync()) :
                          Problem("Entity set 'SystemDbContext.bus'  is null.");
        }

        // GET: Buse/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.bus == null)
            {
                return NotFound();
            }

            var bus = await _context.bus
                .FirstOrDefaultAsync(m => m.BusID == id);
            if (bus == null)
            {
                return NotFound();
            }

            return View(bus);
        }

        public ActionResult Create()
        {
            return View();
        }

        // POST: TeamsContoller/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Bus bus)
        {
            try
            {

                int adminid = (int)HttpContext.Session.GetInt32("adminID");

                Admin admin = _context.admin.Where(
                  a => a.ID == adminid
                  ).FirstOrDefault();

                bus.Admin = admin;

                _context.bus.Add(bus);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Buse/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.bus == null)
            {
                return NotFound();
            }

            var bus = await _context.bus.FindAsync(id);
            if (bus == null)
            {
                return NotFound();
            }
            return View(bus);
        }

        // POST: Buse/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BusID,captainname,NumberofSeats")] Bus bus)
        {
            if (id != bus.BusID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BusExists(bus.BusID))
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
            return View(bus);
        }

        // GET: Buse/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.bus == null)
            {
                return NotFound();
            }

            var bus = await _context.bus
                .FirstOrDefaultAsync(m => m.BusID == id);
            if (bus == null)
            {
                return NotFound();
            }

            return View(bus);
        }

        // POST: Buse/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.bus == null)
            {
                return Problem("Entity set 'SystemDbContext.bus'  is null.");
            }
            var bus = await _context.bus.FindAsync(id);
            if (bus != null)
            {
                _context.bus.Remove(bus);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BusExists(int id)
        {
          return (_context.bus?.Any(e => e.BusID == id)).GetValueOrDefault();
        }
    }
}
