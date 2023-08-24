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
    public class GununYemegisController : Controller
    {
        private readonly YemekTarifiContext _context;

        public GununYemegisController(YemekTarifiContext context)
        {
            _context = context;
        }

        // GET: GununYemegis
        public async Task<IActionResult> Index()
        {
            var yemekTarifiContext = _context.GununYemegis.Include(g => g.Yemek);
            return View(await yemekTarifiContext.ToListAsync());
        }

        // GET: GununYemegis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.GununYemegis == null)
            {
                return NotFound();
            }

            var gununYemegi = await _context.GununYemegis
                .Include(g => g.Yemek)
                .FirstOrDefaultAsync(m => m.GununYemegiId == id);
            if (gununYemegi == null)
            {
                return NotFound();
            }

            return View(gununYemegi);
        }

        // GET: GununYemegis/Create
        public IActionResult Create()
        {
            ViewData["YemekId"] = new SelectList(_context.Yemeklers, "YemekId", "YemekId");
            return View();
        }

        // POST: GununYemegis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GununYemegiId,Ad,Malzemeler,Tarif,Tarih,YemekId")] GununYemegi gununYemegi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gununYemegi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["YemekId"] = new SelectList(_context.Yemeklers, "YemekId", "YemekId", gununYemegi.YemekId);
            return View(gununYemegi);
        }

        // GET: GununYemegis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.GununYemegis == null)
            {
                return NotFound();
            }

            var gununYemegi = await _context.GununYemegis.FindAsync(id);
            if (gununYemegi == null)
            {
                return NotFound();
            }
            ViewData["YemekId"] = new SelectList(_context.Yemeklers, "YemekId", "YemekId", gununYemegi.YemekId);
            return View(gununYemegi);
        }

        // POST: GununYemegis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GununYemegiId,Ad,Malzemeler,Tarif,Tarih,YemekId")] GununYemegi gununYemegi)
        {
            if (id != gununYemegi.GununYemegiId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gununYemegi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GununYemegiExists(gununYemegi.GununYemegiId))
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
            ViewData["YemekId"] = new SelectList(_context.Yemeklers, "YemekId", "YemekId", gununYemegi.YemekId);
            return View(gununYemegi);
        }

        // GET: GununYemegis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.GununYemegis == null)
            {
                return NotFound();
            }

            var gununYemegi = await _context.GununYemegis
                .Include(g => g.Yemek)
                .FirstOrDefaultAsync(m => m.GununYemegiId == id);
            if (gununYemegi == null)
            {
                return NotFound();
            }

            return View(gununYemegi);
        }

        // POST: GununYemegis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.GununYemegis == null)
            {
                return Problem("Entity set 'YemekTarifiContext.GununYemegis'  is null.");
            }
            var gununYemegi = await _context.GununYemegis.FindAsync(id);
            if (gununYemegi != null)
            {
                _context.GununYemegis.Remove(gununYemegi);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GununYemegiExists(int id)
        {
          return (_context.GununYemegis?.Any(e => e.GununYemegiId == id)).GetValueOrDefault();
        }
    }
}
