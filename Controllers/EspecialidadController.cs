using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ClinicaVeterinaria.Data;
using ClinicaVeterinaria.Models;

namespace ClinicaVeterinaria.Controllers
{
    public class EspecialidadController : Controller
    {
        private readonly ClinicaContainer _context;

        public EspecialidadController(ClinicaContainer context)
        {
            _context = context;
        }

        // GET: Especialidad
        public async Task<IActionResult> Index()
        {
            return View(await _context.EspecialidadSet.ToListAsync());
        }

        // GET: Especialidad/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var especialidad = await _context.EspecialidadSet
                .FirstOrDefaultAsync(m => m.id == id);
            if (especialidad == null)
            {
                return NotFound();
            }

            return View(especialidad);
        }

        // GET: Especialidad/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Especialidad/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,CodigoEspecialidad,Descripcion")] Especialidad especialidad)
        {
            if (ModelState.IsValid)
            {
                _context.Add(especialidad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(especialidad);
        }

        // GET: Especialidad/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var especialidad = await _context.EspecialidadSet.FindAsync(id);
            if (especialidad == null)
            {
                return NotFound();
            }
            return View(especialidad);
        }

        // POST: Especialidad/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,CodigoEspecialidad,Descripcion")] Especialidad especialidad)
        {
            if (id != especialidad.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(especialidad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EspecialidadExists(especialidad.id))
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
            return View(especialidad);
        }

        // GET: Especialidad/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var especialidad = await _context.EspecialidadSet
                .FirstOrDefaultAsync(m => m.id == id);
            if (especialidad == null)
            {
                return NotFound();
            }

            return View(especialidad);
        }

        // POST: Especialidad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var especialidad = await _context.EspecialidadSet.FindAsync(id);
            if (especialidad != null)
            {
                _context.EspecialidadSet.Remove(especialidad);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        // GET: Razas/Search
        public async Task<IActionResult> Search(string searchTerm)
        {
            ViewData["CurrentFilter"] = searchTerm;

            IQueryable<Especialidad> query = _context.EspecialidadSet;

            if (!string.IsNullOrEmpty(searchTerm))
            {
                query = query.Where(r => r.CodigoEspecialidad.Contains(searchTerm));
            }

            var especialidad = await query.ToListAsync();

            return View("Index", especialidad);
        }
        private bool EspecialidadExists(int id)
        {
            return _context.EspecialidadSet.Any(e => e.id == id);
        }
    }
}
