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
        [HttpGet("Consultas")]
        public async Task<IActionResult> Index()
        {
            var consultas = await _context.ConsultaSet
                .Include(c => c.Cliente)
                .Include(c => c.Mascota)
                .Include(c => c.Veterinario)
                .ToListAsync();

            return View(consultas);
        }

        // GET: Consultas/Search
        [HttpGet("Consultas/Search")]
        public async Task<IActionResult> Search(string searchTerm)
        {
            var query = _context.ConsultaSet
                .Include(c => c.Cliente)
                .Include(c => c.Mascota)
                .Include(c => c.Veterinario)
                .AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                query = query.Where(c =>
                    c.Cliente.Nombres.Contains(searchTerm) ||
                    c.CodigoConsulta.ToString().Contains(searchTerm));
            }

            var consultas = await query.ToListAsync();
            return View("Index", consultas); // Renderiza la vista Index con los resultados filtrados
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
            ViewData["ClienteId"] = new SelectList(_context.ClienteSet, "Id", "Nombres");
            ViewData["MascotaId"] = new SelectList(_context.MascotaSet, "Id", "Nombre");
            ViewData["VeterinarioId"] = new SelectList(_context.VeterinarioSet, "Id", "Nombres");
            return View();
        }

        // POST: Consultas/Create
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
            ViewData["ClienteId"] = new SelectList(_context.ClienteSet, "Id", "Nombres", consulta.ClienteId);
            ViewData["MascotaId"] = new SelectList(_context.MascotaSet, "Id", "Nombre", consulta.MascotaId);
            ViewData["VeterinarioId"] = new SelectList(_context.VeterinarioSet, "Id", "Nombres", consulta.VeterinarioId);
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
            ViewData["ClienteId"] = new SelectList(_context.ClienteSet, "Id", "Nombres", consulta.ClienteId);
            ViewData["MascotaId"] = new SelectList(_context.MascotaSet, "Id", "Nombre", consulta.MascotaId);
            ViewData["VeterinarioId"] = new SelectList(_context.VeterinarioSet, "Id", "Nombres", consulta.VeterinarioId);
            return View(consulta);
        }

        // POST: Consultas/Edit/5
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
            ViewData["ClienteId"] = new SelectList(_context.ClienteSet, "Id", "Nombres", consulta.ClienteId);
            ViewData["MascotaId"] = new SelectList(_context.MascotaSet, "Id", "Nombre", consulta.MascotaId);
            ViewData["VeterinarioId"] = new SelectList(_context.VeterinarioSet, "Id", "Nombres", consulta.VeterinarioId);
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
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool ConsultaExists(int id)
        {
            return _context.ConsultaSet.Any(e => e.Id == id);
        }
    }
}
