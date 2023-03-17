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
    public class SanphamsController : Controller
    {
        private readonly doanthiDBContext _context;

        public SanphamsController(doanthiDBContext context)
        {
            _context = context;
        }

        // GET: Sanphams
        public async Task<IActionResult> Index()
        {
              return View(await _context.Sanphams.ToListAsync());
        }

        // GET: Sanphams/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Sanphams == null)
            {
                return NotFound();
            }

            var sanpham = await _context.Sanphams
                .FirstOrDefaultAsync(m => m.Sanpham_id == id);
            if (sanpham == null)
            {
                return NotFound();
            }

            return View(sanpham);
        }

        // GET: Sanphams/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sanphams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Sanpham_id,NameSP,Price,NgayNhap,HSD,image,description")] Sanpham sanpham)
        {
            if (sanpham.NameSP != null)
            {
                _context.Add(sanpham);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sanpham);
        }

        // GET: Sanphams/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Sanphams == null)
            {
                return NotFound();
            }

            var sanpham = await _context.Sanphams.FindAsync(id);
            if (sanpham == null)
            {
                return NotFound();
            }
            return View(sanpham);
        }

        // POST: Sanphams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Sanpham_id,NameSP,Price,NgayNhap,HSD,image,description")] Sanpham sanpham)
        {
            if (id != sanpham.Sanpham_id)
            {
                return NotFound();
            }

            if (sanpham.NameSP != null)
            {
                try
                {
                    _context.Update(sanpham);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SanphamExists(sanpham.Sanpham_id))
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
            return View(sanpham);
        }

        // GET: Sanphams/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Sanphams == null)
            {
                return NotFound();
            }

            var sanpham = await _context.Sanphams
                .FirstOrDefaultAsync(m => m.Sanpham_id == id);
            if (sanpham == null)
            {
                return NotFound();
            }

            return View(sanpham);
        }

        // POST: Sanphams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Sanphams == null)
            {
                return Problem("Entity set 'doanthiDBContext.Sanphams'  is null.");
            }
            var sanpham = await _context.Sanphams.FindAsync(id);
            if (sanpham != null)
            {
                _context.Sanphams.Remove(sanpham);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SanphamExists(int id)
        {
          return _context.Sanphams.Any(e => e.Sanpham_id == id);
        }
    }
}
