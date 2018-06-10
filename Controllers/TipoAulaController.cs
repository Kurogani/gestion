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
    public class TipoAulaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TipoAulaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TipoAula
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoAulas.ToListAsync());
        }

        // GET: TipoAula/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoAula = await _context.TipoAulas
                .SingleOrDefaultAsync(m => m.ID == id);
            if (tipoAula == null)
            {
                return NotFound();
            }

            return View(tipoAula);
        }

        // GET: TipoAula/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoAula/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,DESCRIPCION,ESTADO")] TipoAula tipoAula)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoAula);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoAula);
        }

        // GET: TipoAula/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoAula = await _context.TipoAulas.SingleOrDefaultAsync(m => m.ID == id);
            if (tipoAula == null)
            {
                return NotFound();
            }
            return View(tipoAula);
        }

        // POST: TipoAula/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,DESCRIPCION,ESTADO")] TipoAula tipoAula)
        {
            if (id != tipoAula.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoAula);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoAulaExists(tipoAula.ID))
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
            return View(tipoAula);
        }

        // GET: TipoAula/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoAula = await _context.TipoAulas
                .SingleOrDefaultAsync(m => m.ID == id);
            if (tipoAula == null)
            {
                return NotFound();
            }

            return View(tipoAula);
        }

        // POST: TipoAula/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoAula = await _context.TipoAulas.SingleOrDefaultAsync(m => m.ID == id);
            _context.TipoAulas.Remove(tipoAula);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoAulaExists(int id)
        {
            return _context.TipoAulas.Any(e => e.ID == id);
        }
    }
}
