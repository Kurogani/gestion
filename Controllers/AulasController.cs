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
    public class AulasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AulasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Aulas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Aulas.ToListAsync());
        }

        // GET: Aulas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aulas = await _context.Aulas
                .SingleOrDefaultAsync(m => m.ID == id);
            if (aulas == null)
            {
                return NotFound();
            }

            return View(aulas);
        }

        // GET: Aulas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Aulas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,DESCRIPCION,TIPO_AULA,EDIFICIO,CAPACIDAD,ESTADO")] Aulas aulas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aulas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aulas);
        }

        // GET: Aulas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aulas = await _context.Aulas.SingleOrDefaultAsync(m => m.ID == id);
            if (aulas == null)
            {
                return NotFound();
            }
            return View(aulas);
        }

        // POST: Aulas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,DESCRIPCION,TIPO_AULA,EDIFICIO,CAPACIDAD,ESTADO")] Aulas aulas)
        {
            if (id != aulas.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aulas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AulasExists(aulas.ID))
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
            return View(aulas);
        }

        // GET: Aulas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aulas = await _context.Aulas
                .SingleOrDefaultAsync(m => m.ID == id);
            if (aulas == null)
            {
                return NotFound();
            }

            return View(aulas);
        }

        // POST: Aulas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aulas = await _context.Aulas.SingleOrDefaultAsync(m => m.ID == id);
            _context.Aulas.Remove(aulas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AulasExists(int id)
        {
            return _context.Aulas.Any(e => e.ID == id);
        }
    }
}
