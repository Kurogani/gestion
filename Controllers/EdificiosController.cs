using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Gestion.Data;
using Gestion.Models;

namespace Gestion.Controllers
{
    public class EdificiosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EdificiosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Edificios
        public async Task<IActionResult> Index()
        {
            return View(await _context.Edificios.ToListAsync());
        }

        // GET: Edificios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var edificios = await _context.Edificios
                .SingleOrDefaultAsync(m => m.ID == id);
            if (edificios == null)
            {
                return NotFound();
            }

            return View(edificios);
        }

        // GET: Edificios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Edificios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,DESCRIPCION,CAMPUS,ESTADO")] Edificios edificios)
        {
            if (ModelState.IsValid)
            {
                _context.Add(edificios);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(edificios);
        }

        // GET: Edificios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var edificios = await _context.Edificios.SingleOrDefaultAsync(m => m.ID == id);
            if (edificios == null)
            {
                return NotFound();
            }
            return View(edificios);
        }

        // POST: Edificios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,DESCRIPCION,CAMPUS,ESTADO")] Edificios edificios)
        {
            if (id != edificios.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(edificios);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EdificiosExists(edificios.ID))
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
            return View(edificios);
        }

        // GET: Edificios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var edificios = await _context.Edificios
                .SingleOrDefaultAsync(m => m.ID == id);
            if (edificios == null)
            {
                return NotFound();
            }

            return View(edificios);
        }

        // POST: Edificios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var edificios = await _context.Edificios.SingleOrDefaultAsync(m => m.ID == id);
            _context.Edificios.Remove(edificios);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EdificiosExists(int id)
        {
            return _context.Edificios.Any(e => e.ID == id);
        }
    }
}
