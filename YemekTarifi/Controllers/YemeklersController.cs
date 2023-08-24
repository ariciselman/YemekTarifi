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
    public class YemeklersController : Controller
    {
        private readonly YemekTarifiContext _context;

        public YemeklersController(YemekTarifiContext context)
        {
            _context = context;
        }

        // GET: Yemeklers
        public async Task<IActionResult> Index()
        {
            var yemekTarifiContext = _context.Yemeklers.Include(y => y.Kategori).Include(y => y.Kullanıcı);
            return View(await yemekTarifiContext.ToListAsync());
        }

        // GET: Yemeklers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Yemeklers == null)
            {
                return NotFound();
            }

            var yemekler = await _context.Yemeklers
                .Include(y => y.Kategori)
                .Include(y => y.Kullanıcı)
                .FirstOrDefaultAsync(m => m.YemekId == id);
            if (yemekler == null)
            {
                return NotFound();
            }

            return View(yemekler);
        }

        // GET: Yemeklers/Create
        public IActionResult Create()
        {
            ViewData["KategoriId"] = new SelectList(_context.Kategorilers, "KategoriId", "KategoriId");
            ViewData["KullanıcıId"] = new SelectList(_context.Kullanıcıs, "KullanıcıId", "KullanıcıId");
            return View();
        }

        // POST: Yemeklers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("YemekId,YemekAd,Malzeme,Tarif,Resim,Tarih,Puan,Yorum,KategoriId,KullanıcıId")] Yemekler yemekler)
        {
            if (ModelState.IsValid)
            {
                _context.Add(yemekler);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KategoriId"] = new SelectList(_context.Kategorilers, "KategoriId", "KategoriId", yemekler.KategoriId);
            ViewData["KullanıcıId"] = new SelectList(_context.Kullanıcıs, "KullanıcıId", "KullanıcıId", yemekler.KullanıcıId);
            return View(yemekler);
        }

        // GET: Yemeklers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Yemeklers == null)
            {
                return NotFound();
            }

            var yemekler = await _context.Yemeklers.FindAsync(id);
            if (yemekler == null)
            {
                return NotFound();
            }
            ViewData["KategoriId"] = new SelectList(_context.Kategorilers, "KategoriId", "KategoriId", yemekler.KategoriId);
            ViewData["KullanıcıId"] = new SelectList(_context.Kullanıcıs, "KullanıcıId", "KullanıcıId", yemekler.KullanıcıId);
            return View(yemekler);
        }

        // POST: Yemeklers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("YemekId,YemekAd,Malzeme,Tarif,Resim,Tarih,Puan,Yorum,KategoriId,KullanıcıId")] Yemekler yemekler)
        {
            if (id != yemekler.YemekId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(yemekler);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!YemeklerExists(yemekler.YemekId))
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
            ViewData["KategoriId"] = new SelectList(_context.Kategorilers, "KategoriId", "KategoriId", yemekler.KategoriId);
            ViewData["KullanıcıId"] = new SelectList(_context.Kullanıcıs, "KullanıcıId", "KullanıcıId", yemekler.KullanıcıId);
            return View(yemekler);
        }

        // GET: Yemeklers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Yemeklers == null)
            {
                return NotFound();
            }

            var yemekler = await _context.Yemeklers
                .Include(y => y.Kategori)
                .Include(y => y.Kullanıcı)
                .FirstOrDefaultAsync(m => m.YemekId == id);
            if (yemekler == null)
            {
                return NotFound();
            }

            return View(yemekler);
        }

        // POST: Yemeklers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Yemeklers == null)
            {
                return Problem("Entity set 'YemekTarifiContext.Yemeklers'  is null.");
            }
            var yemekler = await _context.Yemeklers.FindAsync(id);
            if (yemekler != null)
            {
                _context.Yemeklers.Remove(yemekler);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool YemeklerExists(int id)
        {
          return (_context.Yemeklers?.Any(e => e.YemekId == id)).GetValueOrDefault();
        }
    }
   
}
