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
        public async Task<IActionResult> Index(string searchTerm)
        {
            ViewData["CurrentFilter"] = searchTerm;

            var detalleConsultas = _context.DetalleConsultaSet
                .Include(d => d.Consulta)
                .Include(d => d.Medicamento)
                .AsQueryable(); // Permite construir dinámicamente la consulta

            if (!string.IsNullOrEmpty(searchTerm))
            {
                detalleConsultas = detalleConsultas.Where(d =>
                    d.Consulta.CodigoConsulta.Contains(searchTerm)); // Filtra por código de consulta
            }

            return View(await detalleConsultas.ToListAsync());
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
                .Include(d => d.Medicamento)
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
            ViewBag.ConsultaId = new SelectList(_context.ConsultaSet, "Id", "CodigoConsulta");
            ViewBag.MedicamentoId = new SelectList(_context.MedicamentoSet, "Id", "CodigoMedicamento");
            return View();
        }

        // POST: DetalleConsultas/Create
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
            ViewBag.ConsultaId = new SelectList(_context.ConsultaSet, "Id", "CodigoConsulta", detalleConsulta.ConsultaId);
            ViewBag.MedicamentoId = new SelectList(_context.MedicamentoSet, "Id", "CodigoMedicamento", detalleConsulta.MedicamentoId);
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

            ViewBag.ConsultaId = new SelectList(_context.ConsultaSet, "Id", "CodigoConsulta", detalleConsulta.ConsultaId);
            ViewBag.MedicamentoId = new SelectList(_context.MedicamentoSet, "Id", "CodigoMedicamento", detalleConsulta.MedicamentoId);
            return View(detalleConsulta);
        }

        // POST: DetalleConsultas/Edit/5
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

            ViewBag.ConsultaId = new SelectList(_context.ConsultaSet, "Id", "CodigoConsulta", detalleConsulta.ConsultaId);
            ViewBag.MedicamentoId = new SelectList(_context.MedicamentoSet, "Id", "CodigoMedicamento", detalleConsulta.MedicamentoId);
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
                .Include(d => d.Medicamento)
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
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool DetalleConsultaExists(int id)
        {
            return _context.DetalleConsultaSet.Any(e => e.Id == id);
        }
    }
}
