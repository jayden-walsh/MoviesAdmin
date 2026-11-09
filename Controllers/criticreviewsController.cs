using Microsoft.AspNetCore.Mvc;
using MoviesAdmin.Models;
using MoviesAdmin.Data;
using System.Diagnostics;

namespace MoviesAdmin.Controllers
{
    public class criticreviewsController : Controller
    {
        private readonly MoviesAdminContext _context;

        public criticreviewsController(MoviesAdminContext context)
        {
            _context = context;
        }

        // GET: criticreviews
        public async Task<IActionResult> Index()
        {
            return View(await _context.criticreviews.ToListAsync());
        }

        // GET: criticreviews/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.criticreviews == null)
            {
                return NotFound();
            }

            var criticreview = await _context.criticreviews
                .FirstOrDefaultAsync(m => m.Id == id);
            if (criticreview == null)
            {
                return NotFound();
            }

            return View(criticreview);
        }

        // GET: criticreviews/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: criticreviews/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MovieId,CriticName,ReviewText,Rating")] criticreview criticreview)
        {
            if (ModelState.IsValid)
            {
                _context.Add(criticreview);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(criticreview);
        }

        // GET: criticreviews/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.criticreviews == null)
            {
                return NotFound();
            }

            var criticreview = await _context.criticreviews.FindAsync(id);
            if (criticreview == null)
            {
                return NotFound();
            }

            return View(criticreview);
        }

        // POST: criticreviews/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MovieId,CriticName,ReviewText,Rating")] criticreview criticreview)
        {
            if (id != criticreview.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(criticreview);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!criticreviewExists(criticreview.Id))
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
            return View(criticreview);
        }

        // GET: criticreviews/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.criticreviews == null)
            {
                return NotFound();
            }

            var criticreview = await _context.criticreviews
                .FirstOrDefaultAsync(m => m.Id == id);
            if (criticreview == null)
            {
                return NotFound();
            }

            return View(criticreview);
        }

        // POST: criticreviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.criticreviews == null)
            {
                return Problem("Entity set 'MoviesAdminContext.criticreviews'  is null.");
            }

            var criticreview = await _context.criticreviews.FindAsync(id);
            if (criticreview != null)
            {
                _context.criticreviews.Remove(criticreview);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool criticreviewExists(int id)
        {
            return _context.criticreviews.Any(e => e.Id == id);
        }
    }
}
