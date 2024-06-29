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
    public class EspecialidadesVeterinariosController : Controller
    {
        private readonly ClinicaContainer _context;

        public EspecialidadesVeterinariosController(ClinicaContainer context)
        {
            _context = context;
        }

        // GET: EspecialidadesVeterinarios
        public async Task<IActionResult> Index(string searchTerm)
        {
            // Query inicial sin filtros
            var especialidadesQuery = _context.EspecialidadesVeterinariosSet
                .Include(e => e.Especialidad)
                .Include(e => e.Veterinario)
                .AsQueryable();

            // Aplicar filtro si se especifica un término de búsqueda
            if (!string.IsNullOrEmpty(searchTerm))
            {
                especialidadesQuery = especialidadesQuery.Where(e =>
                    e.Veterinario.CodigoVeterinario.Contains(searchTerm) ||
                    e.Veterinario.Nombres.Contains(searchTerm) ||
                    e.Veterinario.Apellidos1.Contains(searchTerm) ||
                    e.Veterinario.Apellidos2.Contains(searchTerm)
                );
            }

            var especialidadesVeterinarios = await especialidadesQuery.ToListAsync();

            // Preparar los datos para la vista
            ViewData["SearchTerm"] = searchTerm;

            return View(especialidadesVeterinarios);
        }

        // GET: EspecialidadesVeterinarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var especialidadesVeterinarios = await _context.EspecialidadesVeterinariosSet
                .Include(e => e.Especialidad)
                .Include(e => e.Veterinario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (especialidadesVeterinarios == null)
            {
                return NotFound();
            }

            return View(especialidadesVeterinarios);
        }

        // GET: EspecialidadesVeterinarios/Create
        public IActionResult Create()
        {
            ViewData["EspecialidadId"] = new SelectList(_context.EspecialidadSet, "id", "CodigoEspecialidad");
            ViewData["VeterinarioId"] = new SelectList(_context.VeterinarioSet, "Id", "Nombres");
            return View();
        }

        // POST: EspecialidadesVeterinarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,VeterinarioId,EspecialidadId,TituloObtenido")] EspecialidadesVeterinarios especialidadesVeterinarios)
        {
            if (ModelState.IsValid)
            {
                _context.Add(especialidadesVeterinarios);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EspecialidadId"] = new SelectList(_context.EspecialidadSet, "id", "CodigoEspecialidad", especialidadesVeterinarios.EspecialidadId);
            ViewData["VeterinarioId"] = new SelectList(_context.VeterinarioSet, "Id", "Nombres", especialidadesVeterinarios.VeterinarioId);
            return View(especialidadesVeterinarios);
        }

        // GET: EspecialidadesVeterinarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var especialidadesVeterinarios = await _context.EspecialidadesVeterinariosSet.FindAsync(id);
            if (especialidadesVeterinarios == null)
            {
                return NotFound();
            }
            ViewData["EspecialidadId"] = new SelectList(_context.EspecialidadSet, "id", "CodigoEspecialidad", especialidadesVeterinarios.EspecialidadId);
            ViewData["VeterinarioId"] = new SelectList(_context.VeterinarioSet, "Id", "Nombres", especialidadesVeterinarios.VeterinarioId);
            return View(especialidadesVeterinarios);
        }

        // POST: EspecialidadesVeterinarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,VeterinarioId,EspecialidadId,TituloObtenido")] EspecialidadesVeterinarios especialidadesVeterinarios)
        {
            if (id != especialidadesVeterinarios.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(especialidadesVeterinarios);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EspecialidadesVeterinariosExists(especialidadesVeterinarios.Id))
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
            ViewData["EspecialidadId"] = new SelectList(_context.EspecialidadSet, "id", "CodigoEspecialidad", especialidadesVeterinarios.EspecialidadId);
            ViewData["VeterinarioId"] = new SelectList(_context.VeterinarioSet, "Id", "Nombres", especialidadesVeterinarios.VeterinarioId);
            return View(especialidadesVeterinarios);
        }

        // GET: EspecialidadesVeterinarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var especialidadesVeterinarios = await _context.EspecialidadesVeterinariosSet
                .Include(e => e.Especialidad)
                .Include(e => e.Veterinario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (especialidadesVeterinarios == null)
            {
                return NotFound();
            }

            return View(especialidadesVeterinarios);
        }

        // POST: EspecialidadesVeterinarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var especialidadesVeterinarios = await _context.EspecialidadesVeterinariosSet.FindAsync(id);
            if (especialidadesVeterinarios != null)
            {
                _context.EspecialidadesVeterinariosSet.Remove(especialidadesVeterinarios);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
        // GET: Razas/Search
        public async Task<IActionResult> Search(string searchTerm)
        {
            ViewData["CurrentFilter"] = searchTerm;

            IQueryable<EspecialidadesVeterinarios> query = _context.EspecialidadesVeterinariosSet
                .Include(m => m.Especialidad)
                .Include(m => m.Veterinario);

            if (!string.IsNullOrEmpty(searchTerm))
            {
                query = query.Where(r => r.Especialidad.CodigoEspecialidad.Contains(searchTerm) || r.Veterinario.CodigoVeterinario.Contains(searchTerm));
            }

            var veterinariosEspecialidades = await query.ToListAsync();

            return View("Index", veterinariosEspecialidades);
        }

        private bool EspecialidadesVeterinariosExists(int id)
        {
            return _context.EspecialidadesVeterinariosSet.Any(e => e.Id == id);
        }
    }
}
