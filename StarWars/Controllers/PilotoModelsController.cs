using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StarWars.Data.Context;
using StarWars.Models;
using System.Linq;
using System.Threading.Tasks;

namespace StarWars.Controllers
{
    public class PilotoModelsController : Controller
    {
        private readonly AppDbContext _context;

        public PilotoModelsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: PilotoModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pilotos.ToListAsync());
        }

        // GET: PilotoModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pilotoModel = await _context.Pilotos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pilotoModel == null)
            {
                return NotFound();
            }

            return View(pilotoModel);
        }

        // GET: PilotoModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PilotoModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,AnoNascimento")] PilotoModel pilotoModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pilotoModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pilotoModel);
        }

        // GET: PilotoModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pilotoModel = await _context.Pilotos.FindAsync(id);
            if (pilotoModel == null)
            {
                return NotFound();
            }
            return View(pilotoModel);
        }

        // POST: PilotoModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,AnoNascimento")] PilotoModel pilotoModel)
        {
            if (id != pilotoModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pilotoModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PilotoModelExists(pilotoModel.Id))
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
            return View(pilotoModel);
        }

        // GET: PilotoModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pilotoModel = await _context.Pilotos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pilotoModel == null)
            {
                return NotFound();
            }

            return View(pilotoModel);
        }

        // POST: PilotoModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pilotoModel = await _context.Pilotos.FindAsync(id);
            _context.Pilotos.Remove(pilotoModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PilotoModelExists(int id)
        {
            return _context.Pilotos.Any(e => e.Id == id);
        }
    }
}
