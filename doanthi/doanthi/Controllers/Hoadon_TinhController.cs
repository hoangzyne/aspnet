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
    public class Hoadon_TinhController : Controller
    {
        private readonly doanthiDBContext _context;

        public Hoadon_TinhController(doanthiDBContext context)
        {
            _context = context;
        }

        // GET: Hoadon_Tinh
        public async Task<IActionResult> Index()
        {
            var doanthiDBContext = _context.hoadon_Tinhs.Include(h => h.Sanpham);
            return View(await doanthiDBContext.ToListAsync());
        }

        // GET: Hoadon_Tinh/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.hoadon_Tinhs == null)
            {
                return NotFound();
            }

            var hoadon_Tinh = await _context.hoadon_Tinhs
                .Include(h => h.Sanpham)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hoadon_Tinh == null)
            {
                return NotFound();
            }

            return View(hoadon_Tinh);
        }

        // GET: Hoadon_Tinh/Create
        public IActionResult Create()
        {
            ViewData["Sanpham_id"] = new SelectList(_context.Sanphams, "Sanpham_id", "Sanpham_id");
            return View();
        }

        // POST: Hoadon_Tinh/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Quality,Hoadon_id,Sanpham_id")] Hoadon_Tinh hoadon_Tinh)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hoadon_Tinh);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Sanpham_id"] = new SelectList(_context.Sanphams, "Sanpham_id", "Sanpham_id", hoadon_Tinh.Sanpham_id);
            return View(hoadon_Tinh);
        }

        // GET: Hoadon_Tinh/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.hoadon_Tinhs == null)
            {
                return NotFound();
            }

            var hoadon_Tinh = await _context.hoadon_Tinhs.FindAsync(id);
            if (hoadon_Tinh == null)
            {
                return NotFound();
            }
            ViewData["Sanpham_id"] = new SelectList(_context.Sanphams, "Sanpham_id", "Sanpham_id", hoadon_Tinh.Sanpham_id);
            return View(hoadon_Tinh);
        }

        // POST: Hoadon_Tinh/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Quality,Hoadon_id,Sanpham_id")] Hoadon_Tinh hoadon_Tinh)
        {
            if (id != hoadon_Tinh.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hoadon_Tinh);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Hoadon_TinhExists(hoadon_Tinh.Id))
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
            ViewData["Sanpham_id"] = new SelectList(_context.Sanphams, "Sanpham_id", "Sanpham_id", hoadon_Tinh.Sanpham_id);
            return View(hoadon_Tinh);
        }

        // GET: Hoadon_Tinh/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.hoadon_Tinhs == null)
            {
                return NotFound();
            }

            var hoadon_Tinh = await _context.hoadon_Tinhs
                .Include(h => h.Sanpham)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hoadon_Tinh == null)
            {
                return NotFound();
            }

            return View(hoadon_Tinh);
        }

        // POST: Hoadon_Tinh/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.hoadon_Tinhs == null)
            {
                return Problem("Entity set 'doanthiDBContext.hoadon_Tinhs'  is null.");
            }
            var hoadon_Tinh = await _context.hoadon_Tinhs.FindAsync(id);
            if (hoadon_Tinh != null)
            {
                _context.hoadon_Tinhs.Remove(hoadon_Tinh);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Hoadon_TinhExists(int id)
        {
          return _context.hoadon_Tinhs.Any(e => e.Id == id);
        }
    }
}
