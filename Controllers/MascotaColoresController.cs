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
    public class MascotaColoresController : Controller
    {
        private readonly ClinicaContainer _context;

        public MascotaColoresController(ClinicaContainer context)
        {
            _context = context;
        }

        // GET: MascotaColores
        public async Task<IActionResult> Index()
        {
            var clinicaContainer = _context.MascotaColoresSet.Include(m => m.Colores).Include(m => m.Mascota);
            return View(await clinicaContainer.ToListAsync());
        }

        // GET: MascotaColores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mascotaColores = await _context.MascotaColoresSet
                .Include(m => m.Colores)
                .Include(m => m.Mascota)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mascotaColores == null)
            {
                return NotFound();
            }

            return View(mascotaColores);
        }

        // GET: MascotaColores/Create
        public IActionResult Create()
        {
            ViewData["ColoresId"] = new SelectList(_context.ColoresSet, "Id", "CodigoColor");
            ViewData["MascotaId"] = new SelectList(_context.MascotaSet, "Id", "CodigoMascota");
            return View();
        }

        // POST: MascotaColores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MascotaId,ColoresId")] MascotaColores mascotaColores)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mascotaColores);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ColoresId"] = new SelectList(_context.ColoresSet, "Id", "CodigoColor", mascotaColores.ColoresId);
            ViewData["MascotaId"] = new SelectList(_context.MascotaSet, "Id", "CodigoMascota", mascotaColores.MascotaId);
            return View(mascotaColores);
        }

        // GET: MascotaColores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mascotaColores = await _context.MascotaColoresSet.FindAsync(id);
            if (mascotaColores == null)
            {
                return NotFound();
            }
            ViewData["ColoresId"] = new SelectList(_context.ColoresSet, "Id", "CodigoColor", mascotaColores.ColoresId);
            ViewData["MascotaId"] = new SelectList(_context.MascotaSet, "Id", "CodigoMascota", mascotaColores.MascotaId);
            return View(mascotaColores);
        }

        // POST: MascotaColores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MascotaId,ColoresId")] MascotaColores mascotaColores)
        {
            if (id != mascotaColores.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mascotaColores);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MascotaColoresExists(mascotaColores.Id))
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
            ViewData["ColoresId"] = new SelectList(_context.ColoresSet, "Id", "CodigoColor", mascotaColores.ColoresId);
            ViewData["MascotaId"] = new SelectList(_context.MascotaSet, "Id", "CodigoMascota", mascotaColores.MascotaId);
            return View(mascotaColores);
        }

        // GET: MascotaColores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mascotaColores = await _context.MascotaColoresSet
                .Include(m => m.Colores)
                .Include(m => m.Mascota)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mascotaColores == null)
            {
                return NotFound();
            }

            return View(mascotaColores);
        }

        // POST: MascotaColores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mascotaColores = await _context.MascotaColoresSet.FindAsync(id);
            if (mascotaColores != null)
            {
                _context.MascotaColoresSet.Remove(mascotaColores);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MascotaColoresExists(int id)
        {
            return _context.MascotaColoresSet.Any(e => e.Id == id);
        }
    }
}
