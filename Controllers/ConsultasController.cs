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
    public class ConsultasController : Controller
    {
        private readonly ClinicaContainer _context;

        public ConsultasController(ClinicaContainer context)
        {
            _context = context;
        }

        // GET: Consultas
        public async Task<IActionResult> Index()
        {
            var clinicaContainer = _context.ConsultaSet.Include(c => c.Cliente).Include(c => c.Mascota).Include(c => c.Veterinario);
            return View(await clinicaContainer.ToListAsync());
        }

        // GET: Consultas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consulta = await _context.ConsultaSet
                .Include(c => c.Cliente)
                .Include(c => c.Mascota)
                .Include(c => c.Veterinario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (consulta == null)
            {
                return NotFound();
            }

            return View(consulta);
        }

        // GET: Consultas/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.ClienteSet, "Id", "Apellidos1");
            ViewData["MascotaId"] = new SelectList(_context.MascotaSet, "Id", "CodigoMascota");
            ViewData["VeterinarioId"] = new SelectList(_context.VeterinarioSet, "Id", "Apellidos1");
            return View();
        }

        // POST: Consultas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CodigoConsulta,FechaConsulta,DescripcionConsulta,MascotaId,FechaCita,DescripcionCita,VeterinarioId,ClienteId")] Consulta consulta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(consulta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.ClienteSet, "Id", "Apellidos1", consulta.ClienteId);
            ViewData["MascotaId"] = new SelectList(_context.MascotaSet, "Id", "CodigoMascota", consulta.MascotaId);
            ViewData["VeterinarioId"] = new SelectList(_context.VeterinarioSet, "Id", "Apellidos1", consulta.VeterinarioId);
            return View(consulta);
        }

        // GET: Consultas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consulta = await _context.ConsultaSet.FindAsync(id);
            if (consulta == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.ClienteSet, "Id", "Apellidos1", consulta.ClienteId);
            ViewData["MascotaId"] = new SelectList(_context.MascotaSet, "Id", "CodigoMascota", consulta.MascotaId);
            ViewData["VeterinarioId"] = new SelectList(_context.VeterinarioSet, "Id", "Apellidos1", consulta.VeterinarioId);
            return View(consulta);
        }

        // POST: Consultas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CodigoConsulta,FechaConsulta,DescripcionConsulta,MascotaId,FechaCita,DescripcionCita,VeterinarioId,ClienteId")] Consulta consulta)
        {
            if (id != consulta.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(consulta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConsultaExists(consulta.Id))
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
            ViewData["ClienteId"] = new SelectList(_context.ClienteSet, "Id", "Apellidos1", consulta.ClienteId);
            ViewData["MascotaId"] = new SelectList(_context.MascotaSet, "Id", "CodigoMascota", consulta.MascotaId);
            ViewData["VeterinarioId"] = new SelectList(_context.VeterinarioSet, "Id", "Apellidos1", consulta.VeterinarioId);
            return View(consulta);
        }

        // GET: Consultas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consulta = await _context.ConsultaSet
                .Include(c => c.Cliente)
                .Include(c => c.Mascota)
                .Include(c => c.Veterinario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (consulta == null)
            {
                return NotFound();
            }

            return View(consulta);
        }

        // POST: Consultas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var consulta = await _context.ConsultaSet.FindAsync(id);
            if (consulta != null)
            {
                _context.ConsultaSet.Remove(consulta);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConsultaExists(int id)
        {
            return _context.ConsultaSet.Any(e => e.Id == id);
        }
    }
}
