using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using YemekTarifi.Models.DB;

namespace YemekTarifi.Controllers
{
    public class YoneticisController : Controller
    {
        private readonly YemekTarifiContext _context;

        public YoneticisController(YemekTarifiContext context)
        {
            _context = context;
        }

        // GET: Yoneticis
        public async Task<IActionResult> Index()
        {
              return _context.Yoneticis != null ? 
                          View(await _context.Yoneticis.ToListAsync()) :
                          Problem("Entity set 'YemekTarifiContext.Yoneticis'  is null.");
        }

        // GET: Yoneticis/Details/5
        public async Task<IActionResult> Details(byte? id)
        {
            if (id == null || _context.Yoneticis == null)
            {
                return NotFound();
            }

            var yonetici = await _context.Yoneticis
                .FirstOrDefaultAsync(m => m.YoneticiId == id);
            if (yonetici == null)
            {
                return NotFound();
            }

            return View(yonetici);
        }

        // GET: Yoneticis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Yoneticis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("YoneticiId,Ad,Sıfre")] Yonetici yonetici)
        {
            if (ModelState.IsValid)
            {
                _context.Add(yonetici);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(yonetici);
        }

        // GET: Yoneticis/Edit/5
        public async Task<IActionResult> Edit(byte? id)
        {
            if (id == null || _context.Yoneticis == null)
            {
                return NotFound();
            }

            var yonetici = await _context.Yoneticis.FindAsync(id);
            if (yonetici == null)
            {
                return NotFound();
            }
            return View(yonetici);
        }

        // POST: Yoneticis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(byte id, [Bind("YoneticiId,Ad,Sıfre")] Yonetici yonetici)
        {
            if (id != yonetici.YoneticiId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(yonetici);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!YoneticiExists(yonetici.YoneticiId))
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
            return View(yonetici);
        }

        // GET: Yoneticis/Delete/5
        public async Task<IActionResult> Delete(byte? id)
        {
            if (id == null || _context.Yoneticis == null)
            {
                return NotFound();
            }

            var yonetici = await _context.Yoneticis
                .FirstOrDefaultAsync(m => m.YoneticiId == id);
            if (yonetici == null)
            {
                return NotFound();
            }

            return View(yonetici);
        }

        // POST: Yoneticis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(byte id)
        {
            if (_context.Yoneticis == null)
            {
                return Problem("Entity set 'YemekTarifiContext.Yoneticis'  is null.");
            }
            var yonetici = await _context.Yoneticis.FindAsync(id);
            if (yonetici != null)
            {
                _context.Yoneticis.Remove(yonetici);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool YoneticiExists(byte id)
        {
          return (_context.Yoneticis?.Any(e => e.YoneticiId == id)).GetValueOrDefault();
        }
    }
}
