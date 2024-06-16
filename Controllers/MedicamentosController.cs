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
    public class MedicamentosController : Controller
    {
        private readonly ClinicaContainer _context;

        public MedicamentosController(ClinicaContainer context)
        {
            _context = context;
        }

        // GET: Medicamentos
        public async Task<IActionResult> Index()
        {
            var clinicaContainer = _context.MedicamentosSet.Include(m => m.TipoMedicamento);
            return View(await clinicaContainer.ToListAsync());
        }

        // GET: Medicamentos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicamentos = await _context.MedicamentosSet
                .Include(m => m.TipoMedicamento)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (medicamentos == null)
            {
                return NotFound();
            }

            return View(medicamentos);
        }

        // GET: Medicamentos/Create
        public IActionResult Create()
        {
            ViewData["TipoMedicamentoId"] = new SelectList(_context.TipoMedicamentoSet, "Id", "CodigoTipo");
            return View();
        }

        // POST: Medicamentos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CodigoVacuna,Descripcion,TipoMedicamentoId")] Medicamentos medicamentos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(medicamentos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TipoMedicamentoId"] = new SelectList(_context.TipoMedicamentoSet, "Id", "CodigoTipo", medicamentos.TipoMedicamentoId);
            return View(medicamentos);
        }

        // GET: Medicamentos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicamentos = await _context.MedicamentosSet.FindAsync(id);
            if (medicamentos == null)
            {
                return NotFound();
            }
            ViewData["TipoMedicamentoId"] = new SelectList(_context.TipoMedicamentoSet, "Id", "CodigoTipo", medicamentos.TipoMedicamentoId);
            return View(medicamentos);
        }

        // POST: Medicamentos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CodigoVacuna,Descripcion,TipoMedicamentoId")] Medicamentos medicamentos)
        {
            if (id != medicamentos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medicamentos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedicamentosExists(medicamentos.Id))
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
            ViewData["TipoMedicamentoId"] = new SelectList(_context.TipoMedicamentoSet, "Id", "CodigoTipo", medicamentos.TipoMedicamentoId);
            return View(medicamentos);
        }

        // GET: Medicamentos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicamentos = await _context.MedicamentosSet
                .Include(m => m.TipoMedicamento)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (medicamentos == null)
            {
                return NotFound();
            }

            return View(medicamentos);
        }

        // POST: Medicamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var medicamentos = await _context.MedicamentosSet.FindAsync(id);
            if (medicamentos != null)
            {
                _context.MedicamentosSet.Remove(medicamentos);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedicamentosExists(int id)
        {
            return _context.MedicamentosSet.Any(e => e.Id == id);
        }
    }
}
