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
    public class EspeciesController : Controller
    {
        private readonly ClinicaContainer _context;

        public EspeciesController(ClinicaContainer context)
        {
            _context = context;
        }

        // GET: Especies
        public async Task<IActionResult> Index()
        {
            return View(await _context.EspecieSet.ToListAsync());
        }

        // GET: Especies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var especie = await _context.EspecieSet
                .FirstOrDefaultAsync(m => m.Id == id);
            if (especie == null)
            {
                return NotFound();
            }

            return View(especie);
        }

        // GET: Especies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Especies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CodigoEspecie,Descripcion")] Especie especie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(especie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(especie);
        }

        // GET: Especies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var especie = await _context.EspecieSet.FindAsync(id);
            if (especie == null)
            {
                return NotFound();
            }
            return View(especie);
        }

        // POST: Especies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CodigoEspecie,Descripcion")] Especie especie)
        {
            if (id != especie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(especie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EspecieExists(especie.Id))
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
            return View(especie);
        }

        // GET: Especies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var especie = await _context.EspecieSet
                .FirstOrDefaultAsync(m => m.Id == id);
            if (especie == null)
            {
                return NotFound();
            }

            return View(especie);
        }

        // POST: Especies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var especie = await _context.EspecieSet.FindAsync(id);
            if (especie != null)
            {
                _context.EspecieSet.Remove(especie);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Especies/Search
        public async Task<IActionResult> Search(string searchTerm)
        {
            ViewData["CurrentFilter"] = searchTerm;

            IQueryable<Especie> query = _context.EspecieSet;

            if (!string.IsNullOrEmpty(searchTerm))
            {
                query = query.Where(r => r.CodigoEspecie.Contains(searchTerm) || r.Descripcion.Contains(searchTerm));
            }

            var especies = await query.ToListAsync();

            return View("Index",especies);
        }


        private bool EspecieExists(int id)
        {
            return _context.EspecieSet.Any(e => e.Id == id);
        }
    }
}
