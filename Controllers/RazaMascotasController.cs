using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ClinicaVeterinaria.Data;
using ClinicaVeterinaria.Models;

namespace ClinicaVeterinaria.Controllers
{
    public class RazaMascotasController : Controller
    {
        private readonly ClinicaContainer _context;

        public RazaMascotasController(ClinicaContainer context)
        {
            _context = context;
        }

        // GET: RazaMascotas
        public async Task<IActionResult> Index()
        {
            var razaMascotas = await _context.RazaMascotasSet
                .Include(r => r.Mascota)
                .Include(r => r.Raza)
                .ToListAsync();
            return View(razaMascotas);
        }

        // GET: RazaMascotas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var razaMascotas = await _context.RazaMascotasSet
                .Include(r => r.Mascota)
                .Include(r => r.Raza)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (razaMascotas == null)
            {
                return NotFound();
            }

            return View(razaMascotas);
        }

        // GET: RazaMascotas/Create
        public IActionResult Create()
        {
            ViewData["MascotaId"] = new SelectList(_context.MascotaSet, "Id", "CodigoMascota");
            ViewData["RazaId"] = new SelectList(_context.RazaSet, "Id", "CodigoRaza");
            return View();
        }

        // POST: RazaMascotas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MascotaId,RazaId")] RazaMascotas razaMascotas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(razaMascotas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MascotaId"] = new SelectList(_context.MascotaSet, "Id", "CodigoMascota", razaMascotas.MascotaId);
            ViewData["RazaId"] = new SelectList(_context.RazaSet, "Id", "CodigoRaza", razaMascotas.RazaId);
            return View(razaMascotas);
        }

        // GET: RazaMascotas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var razaMascotas = await _context.RazaMascotasSet.FindAsync(id);
            if (razaMascotas == null)
            {
                return NotFound();
            }
            ViewData["MascotaId"] = new SelectList(_context.MascotaSet, "Id", "CodigoMascota", razaMascotas.MascotaId);
            ViewData["RazaId"] = new SelectList(_context.RazaSet, "Id", "CodigoRaza", razaMascotas.RazaId);
            return View(razaMascotas);
        }

        // POST: RazaMascotas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MascotaId,RazaId")] RazaMascotas razaMascotas)
        {
            if (id != razaMascotas.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(razaMascotas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RazaMascotasExists(razaMascotas.Id))
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
            ViewData["MascotaId"] = new SelectList(_context.MascotaSet, "Id", "CodigoMascota", razaMascotas.MascotaId);
            ViewData["RazaId"] = new SelectList(_context.RazaSet, "Id", "CodigoRaza", razaMascotas.RazaId);
            return View(razaMascotas);
        }

        // GET: RazaMascotas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var razaMascotas = await _context.RazaMascotasSet
                .Include(r => r.Mascota)
                .Include(r => r.Raza)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (razaMascotas == null)
            {
                return NotFound();
            }

            return View(razaMascotas);
        }

        // POST: RazaMascotas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var razaMascotas = await _context.RazaMascotasSet.FindAsync(id);
            if (razaMascotas != null)
            {
                _context.RazaMascotasSet.Remove(razaMascotas);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool RazaMascotasExists(int id)
        {
            return _context.RazaMascotasSet.Any(e => e.Id == id);
        }
    }
}
