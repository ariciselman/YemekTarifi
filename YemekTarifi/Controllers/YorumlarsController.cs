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
    public class YorumlarsController : Controller
    {
        private readonly YemekTarifiContext _context;

        public YorumlarsController(YemekTarifiContext context)
        {
            _context = context;
        }

        // GET: Yorumlars
        public async Task<IActionResult> Index()
        {
            var yemekTarifiContext = _context.Yorumlars.Include(y => y.Kullanıcı).Include(y => y.Yemek);
            return View(await yemekTarifiContext.ToListAsync());
        }

        // GET: Yorumlars/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Yorumlars == null)
            {
                return NotFound();
            }

            var yorumlar = await _context.Yorumlars
                .Include(y => y.Kullanıcı)
                .Include(y => y.Yemek)
                .FirstOrDefaultAsync(m => m.YorumId == id);
            if (yorumlar == null)
            {
                return NotFound();
            }

            return View(yorumlar);
        }

        // GET: Yorumlars/Create
        public IActionResult Create()
        {
            ViewData["KullanıcıId"] = new SelectList(_context.Kullanıcıs, "KullanıcıId", "KullanıcıId");
            ViewData["YemekId"] = new SelectList(_context.Yemeklers, "YemekId", "YemekId");
            return View();
        }

        // POST: Yorumlars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("YorumId,Icerik,Tarih,Onay,YemekId,KullanıcıId")] Yorumlar yorumlar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(yorumlar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KullanıcıId"] = new SelectList(_context.Kullanıcıs, "KullanıcıId", "KullanıcıId", yorumlar.KullanıcıId);
            ViewData["YemekId"] = new SelectList(_context.Yemeklers, "YemekId", "YemekId", yorumlar.YemekId);
            return View(yorumlar);
        }

        // GET: Yorumlars/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Yorumlars == null)
            {
                return NotFound();
            }

            var yorumlar = await _context.Yorumlars.FindAsync(id);
            if (yorumlar == null)
            {
                return NotFound();
            }
            ViewData["KullanıcıId"] = new SelectList(_context.Kullanıcıs, "KullanıcıId", "KullanıcıId", yorumlar.KullanıcıId);
            ViewData["YemekId"] = new SelectList(_context.Yemeklers, "YemekId", "YemekId", yorumlar.YemekId);
            return View(yorumlar);
        }

        // POST: Yorumlars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("YorumId,Icerik,Tarih,Onay,YemekId,KullanıcıId")] Yorumlar yorumlar)
        {
            if (id != yorumlar.YorumId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(yorumlar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!YorumlarExists(yorumlar.YorumId))
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
            ViewData["KullanıcıId"] = new SelectList(_context.Kullanıcıs, "KullanıcıId", "KullanıcıId", yorumlar.KullanıcıId);
            ViewData["YemekId"] = new SelectList(_context.Yemeklers, "YemekId", "YemekId", yorumlar.YemekId);
            return View(yorumlar);
        }

        // GET: Yorumlars/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Yorumlars == null)
            {
                return NotFound();
            }

            var yorumlar = await _context.Yorumlars
                .Include(y => y.Kullanıcı)
                .Include(y => y.Yemek)
                .FirstOrDefaultAsync(m => m.YorumId == id);
            if (yorumlar == null)
            {
                return NotFound();
            }

            return View(yorumlar);
        }

        // POST: Yorumlars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Yorumlars == null)
            {
                return Problem("Entity set 'YemekTarifiContext.Yorumlars'  is null.");
            }
            var yorumlar = await _context.Yorumlars.FindAsync(id);
            if (yorumlar != null)
            {
                _context.Yorumlars.Remove(yorumlar);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool YorumlarExists(string id)
        {
          return (_context.Yorumlars?.Any(e => e.YorumId == id)).GetValueOrDefault();
        }
    }
}
