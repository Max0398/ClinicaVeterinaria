using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClinicaVeterinaria.Data;
using ClinicaVeterinaria.Models;

namespace ClinicaVeterinaria.Controllers
{
    public class ColoresController : Controller
    {
        private readonly ClinicaContainer _context;

        public ColoresController(ClinicaContainer context)
        {
            _context = context;
        }

        // GET: Colores
        public async Task<IActionResult> Index(string searchTerm)
        {
            ViewData["CurrentFilter"] = searchTerm;

            var colores = _context.ColoresSet.AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                colores = colores.Where(c =>
                    c.CodigoColor.Contains(searchTerm) ||
                    c.Descripcion.Contains(searchTerm));
            }

            return View(await colores.ToListAsync());
        }

        // GET: Colores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var colores = await _context.ColoresSet
                .FirstOrDefaultAsync(m => m.Id == id);
            if (colores == null)
            {
                return NotFound();
            }

            return View(colores);
        }

        // GET: Colores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Colores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CodigoColor,Descripcion")] Colores colores)
        {
            if (ModelState.IsValid)
            {
                _context.Add(colores);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(colores);
        }

        // GET: Colores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var colores = await _context.ColoresSet.FindAsync(id);
            if (colores == null)
            {
                return NotFound();
            }
            return View(colores);
        }

        // POST: Colores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CodigoColor,Descripcion")] Colores colores)
        {
            if (id != colores.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(colores);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ColoresExists(colores.Id))
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
            return View(colores);
        }

        // GET: Colores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var colores = await _context.ColoresSet
                .FirstOrDefaultAsync(m => m.Id == id);
            if (colores == null)
            {
                return NotFound();
            }

            return View(colores);
        }

        // POST: Colores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var colores = await _context.ColoresSet.FindAsync(id);
            if (colores != null)
            {
                _context.ColoresSet.Remove(colores);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool ColoresExists(int id)
        {
            return _context.ColoresSet.Any(e => e.Id == id);
        }
    }
}
