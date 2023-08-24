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
    public class KullanıcıController : Controller
    {
        private readonly YemekTarifiContext _context;

        public KullanıcıController(YemekTarifiContext context)
        {
            _context = context;
        }

        // GET: Kullanıcı
        public async Task<IActionResult> Index()
        {
              return _context.Kullanıcıs != null ? 
                          View(await _context.Kullanıcıs.ToListAsync()) :
                          Problem("Entity set 'YemekTarifiContext.Kullanıcıs'  is null.");
        }

        // GET: Kullanıcı/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Kullanıcıs == null)
            {
                return NotFound();
            }

            var kullanıcı = await _context.Kullanıcıs
                .FirstOrDefaultAsync(m => m.KullanıcıId == id);
            if (kullanıcı == null)
            {
                return NotFound();
            }

            return View(kullanıcı);
        }

        // GET: Kullanıcı/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Kullanıcı/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("KullanıcıId,KullanıcıAdı,Eposta,Sifre,AdminMi")] Kullanıcı kullanıcı)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kullanıcı);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kullanıcı);
        }

        // GET: Kullanıcı/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Kullanıcıs == null)
            {
                return NotFound();
            }

            var kullanıcı = await _context.Kullanıcıs.FindAsync(id);
            if (kullanıcı == null)
            {
                return NotFound();
            }
            return View(kullanıcı);
        }

        // POST: Kullanıcı/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("KullanıcıId,KullanıcıAdı,Eposta,Sifre,AdminMi")] Kullanıcı kullanıcı)
        {
            if (id != kullanıcı.KullanıcıId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kullanıcı);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KullanıcıExists(kullanıcı.KullanıcıId))
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
            return View(kullanıcı);
        }

        // GET: Kullanıcı/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Kullanıcıs == null)
            {
                return NotFound();
            }

            var kullanıcı = await _context.Kullanıcıs
                .FirstOrDefaultAsync(m => m.KullanıcıId == id);
            if (kullanıcı == null)
            {
                return NotFound();
            }

            return View(kullanıcı);
        }

        // POST: Kullanıcı/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Kullanıcıs == null)
            {
                return Problem("Entity set 'YemekTarifiContext.Kullanıcıs'  is null.");
            }
            var kullanıcı = await _context.Kullanıcıs.FindAsync(id);
            if (kullanıcı != null)
            {
                _context.Kullanıcıs.Remove(kullanıcı);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KullanıcıExists(int id)
        {
          return (_context.Kullanıcıs?.Any(e => e.KullanıcıId == id)).GetValueOrDefault();
        }
    }
}
