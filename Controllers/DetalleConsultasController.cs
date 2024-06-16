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
    public class DetalleConsultasController : Controller
    {
        private readonly ClinicaContainer _context;

        public DetalleConsultasController(ClinicaContainer context)
        {
            _context = context;
        }

        // GET: DetalleConsultas
        public async Task<IActionResult> Index()
        {
            var clinicaContainer = _context.DetalleConsultaSet.Include(d => d.Consulta);
            return View(await clinicaContainer.ToListAsync());
        }

        // GET: DetalleConsultas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalleConsulta = await _context.DetalleConsultaSet
                .Include(d => d.Consulta)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (detalleConsulta == null)
            {
                return NotFound();
            }

            return View(detalleConsulta);
        }

        // GET: DetalleConsultas/Create
        public IActionResult Create()
        {
            ViewData["ConsultaId"] = new SelectList(_context.ConsultaSet, "Id", "CodigoConsulta");
            return View();
        }

        // POST: DetalleConsultas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ConsultaId,Aplicacion,MedicamentoId,Cantidad")] DetalleConsulta detalleConsulta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detalleConsulta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ConsultaId"] = new SelectList(_context.ConsultaSet, "Id", "CodigoConsulta", detalleConsulta.ConsultaId);
            return View(detalleConsulta);
        }

        // GET: DetalleConsultas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalleConsulta = await _context.DetalleConsultaSet.FindAsync(id);
            if (detalleConsulta == null)
            {
                return NotFound();
            }
            ViewData["ConsultaId"] = new SelectList(_context.ConsultaSet, "Id", "CodigoConsulta", detalleConsulta.ConsultaId);
            return View(detalleConsulta);
        }

        // POST: DetalleConsultas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ConsultaId,Aplicacion,MedicamentoId,Cantidad")] DetalleConsulta detalleConsulta)
        {
            if (id != detalleConsulta.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detalleConsulta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetalleConsultaExists(detalleConsulta.Id))
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
            ViewData["ConsultaId"] = new SelectList(_context.ConsultaSet, "Id", "CodigoConsulta", detalleConsulta.ConsultaId);
            return View(detalleConsulta);
        }

        // GET: DetalleConsultas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalleConsulta = await _context.DetalleConsultaSet
                .Include(d => d.Consulta)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (detalleConsulta == null)
            {
                return NotFound();
            }

            return View(detalleConsulta);
        }

        // POST: DetalleConsultas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var detalleConsulta = await _context.DetalleConsultaSet.FindAsync(id);
            if (detalleConsulta != null)
            {
                _context.DetalleConsultaSet.Remove(detalleConsulta);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetalleConsultaExists(int id)
        {
            return _context.DetalleConsultaSet.Any(e => e.Id == id);
        }
    }
}
