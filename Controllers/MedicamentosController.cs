﻿using System;
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
            var medicamentos = await _context.MedicamentoSet
                .Include(m => m.TipoMedicamento)
                .ToListAsync();
            return View(medicamentos);
        }

        // GET: Medicamentos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicamento = await _context.MedicamentoSet
                .Include(m => m.TipoMedicamento)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (medicamento == null)
            {
                return NotFound();
            }

            return View(medicamento);
        }

        // GET: Medicamentos/Create
        public IActionResult Create()
        {
            ViewData["TipoMedicamentoId"] = new SelectList(_context.TipoMedicamentoSet, "Id", "CodigoTipo");
            return View();
        }

        // POST: Medicamentos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CodigoMedicamento,Descripcion,TipoMedicamentoId")] Medicamento medicamento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(medicamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TipoMedicamentoId"] = new SelectList(_context.TipoMedicamentoSet, "Id", "CodigoTipo", medicamento.TipoMedicamentoId);
            return View(medicamento);
        }

        // GET: Medicamentos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicamento = await _context.MedicamentoSet.FindAsync(id);
            if (medicamento == null)
            {
                return NotFound();
            }

            ViewData["TipoMedicamentoId"] = new SelectList(_context.TipoMedicamentoSet, "Id", "CodigoTipo", medicamento.TipoMedicamentoId);
            return View(medicamento);
        }

        // POST: Medicamentos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CodigoMedicamento,Descripcion,TipoMedicamentoId")] Medicamento medicamento)
        {
            if (id != medicamento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medicamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedicamentoExists(medicamento.Id))
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
            ViewData["TipoMedicamentoId"] = new SelectList(_context.TipoMedicamentoSet, "Id", "CodigoTipo", medicamento.TipoMedicamentoId);
            return View(medicamento);
        }

        // GET: Medicamentos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicamento = await _context.MedicamentoSet
                .Include(m => m.TipoMedicamento)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (medicamento == null)
            {
                return NotFound();
            }

            return View(medicamento);
        }

        // POST: Medicamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var medicamento = await _context.MedicamentoSet.FindAsync(id);
            if (medicamento != null)
            {
                _context.MedicamentoSet.Remove(medicamento);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: /Search
        public async Task<IActionResult> Search(string searchTerm)
        {
            ViewData["CurrentFilter"] = searchTerm;

            IQueryable<Medicamento> query = _context.MedicamentoSet;

            if (!string.IsNullOrEmpty(searchTerm))
            {
                query = query.Where(r => r.CodigoMedicamento.Contains(searchTerm) );
            }

            var medicamento = await query.ToListAsync();

            return View("Index", medicamento);
        }

        private bool MedicamentoExists(int id)
        {
            return _context.MedicamentoSet.Any(e => e.Id == id);
        }
    }
}
