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
    public class TipoMedicamentosController : Controller
    {
        private readonly ClinicaContainer _context;

        public TipoMedicamentosController(ClinicaContainer context)
        {
            _context = context;
        }

        // GET: TipoMedicamentos
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoMedicamentoSet.ToListAsync());
        }

        // GET: TipoMedicamentos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoMedicamento = await _context.TipoMedicamentoSet
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoMedicamento == null)
            {
                return NotFound();
            }

            return View(tipoMedicamento);
        }

        // GET: TipoMedicamentos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoMedicamentos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CodigoTipo,Descripcion")] TipoMedicamento tipoMedicamento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoMedicamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoMedicamento);
        }

        // GET: TipoMedicamentos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoMedicamento = await _context.TipoMedicamentoSet.FindAsync(id);
            if (tipoMedicamento == null)
            {
                return NotFound();
            }
            return View(tipoMedicamento);
        }

        // POST: TipoMedicamentos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CodigoTipo,Descripcion")] TipoMedicamento tipoMedicamento)
        {
            if (id != tipoMedicamento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoMedicamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoMedicamentoExists(tipoMedicamento.Id))
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
            return View(tipoMedicamento);
        }

        // GET: TipoMedicamentos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoMedicamento = await _context.TipoMedicamentoSet
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoMedicamento == null)
            {
                return NotFound();
            }

            return View(tipoMedicamento);
        }

        // POST: TipoMedicamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoMedicamento = await _context.TipoMedicamentoSet.FindAsync(id);
            if (tipoMedicamento != null)
            {
                _context.TipoMedicamentoSet.Remove(tipoMedicamento);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        // GET: /Search
        public async Task<IActionResult> Search(string searchTerm)
        {
            ViewData["CurrentFilter"] = searchTerm;

            IQueryable<TipoMedicamento> query = _context.TipoMedicamentoSet;

            if (!string.IsNullOrEmpty(searchTerm))
            {
                query = query.Where(r => r.CodigoTipo.Contains(searchTerm) || r.Descripcion.Contains(searchTerm));
            }

            var tipoMedicamento = await query.ToListAsync();

            return View("Index", tipoMedicamento);
        }

        private bool TipoMedicamentoExists(int id)
        {
            return _context.TipoMedicamentoSet.Any(e => e.Id == id);
        }
    }
}
