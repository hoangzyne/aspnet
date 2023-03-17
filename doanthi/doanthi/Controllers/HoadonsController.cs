using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using doanthi.Data;
using doanthi.Models;

namespace doanthi.Controllers
{
    public class HoadonsController : Controller
    {
        private readonly doanthiDBContext _context;

        public HoadonsController(doanthiDBContext context)
        {
            _context = context;
        }

        // GET: Hoadons
        public async Task<IActionResult> Index()
        {
              return View(await _context.Hoadons.ToListAsync());
        }

        // GET: Hoadons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Hoadons == null)
            {
                return NotFound();
            }

            var hoadon = await _context.Hoadons
                .FirstOrDefaultAsync(m => m.Hoadon_id == id);
            if (hoadon == null)
            {
                return NotFound();
            }

            return View(hoadon);
        }

        // GET: Hoadons/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Hoadons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Hoadon_id,TenHD,NgaylapHD,User_id")] Hoadon hoadon)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hoadon);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hoadon);
        }

        // GET: Hoadons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Hoadons == null)
            {
                return NotFound();
            }

            var hoadon = await _context.Hoadons.FindAsync(id);
            if (hoadon == null)
            {
                return NotFound();
            }
            return View(hoadon);
        }

        // POST: Hoadons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Hoadon_id,TenHD,NgaylapHD,User_id")] Hoadon hoadon)
        {
            if (id != hoadon.Hoadon_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hoadon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HoadonExists(hoadon.Hoadon_id))
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
            return View(hoadon);
        }

        // GET: Hoadons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Hoadons == null)
            {
                return NotFound();
            }

            var hoadon = await _context.Hoadons
                .FirstOrDefaultAsync(m => m.Hoadon_id == id);
            if (hoadon == null)
            {
                return NotFound();
            }

            return View(hoadon);
        }

        // POST: Hoadons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Hoadons == null)
            {
                return Problem("Entity set 'doanthiDBContext.Hoadons'  is null.");
            }
            var hoadon = await _context.Hoadons.FindAsync(id);
            if (hoadon != null)
            {
                _context.Hoadons.Remove(hoadon);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HoadonExists(int id)
        {
          return _context.Hoadons.Any(e => e.Hoadon_id == id);
        }
    }
}
