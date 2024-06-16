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
    public class RazasController : Controller
    {
        private readonly ClinicaContainer _context;

        public RazasController(ClinicaContainer context)
        {
            _context = context;
        }

        // GET: Razas
        public async Task<IActionResult> Index()
        {
            return View(await _context.RazaSet.ToListAsync());
        }

        // GET: Razas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var raza = await _context.RazaSet
                .FirstOrDefaultAsync(m => m.Id == id);
            if (raza == null)
            {
                return NotFound();
            }

            return View(raza);
        }

        // GET: Razas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Razas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CodigoRaza,Descripcion")] Raza raza)
        {
            if (ModelState.IsValid)
            {
                _context.Add(raza);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(raza);
        }

        // GET: Razas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var raza = await _context.RazaSet.FindAsync(id);
            if (raza == null)
            {
                return NotFound();
            }
            return View(raza);
        }

        // POST: Razas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CodigoRaza,Descripcion")] Raza raza)
        {
            if (id != raza.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(raza);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RazaExists(raza.Id))
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
            return View(raza);
        }

        // GET: Razas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var raza = await _context.RazaSet
                .FirstOrDefaultAsync(m => m.Id == id);
            if (raza == null)
            {
                return NotFound();
            }

            return View(raza);
        }

        // POST: Razas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var raza = await _context.RazaSet.FindAsync(id);
            if (raza != null)
            {
                _context.RazaSet.Remove(raza);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RazaExists(int id)
        {
            return _context.RazaSet.Any(e => e.Id == id);
        }
    }
}
