using Microsoft.AspNetCore.Mvc;
using MoviesAdmin.Models;
using MoviesAdmin.Data;
using System.Diagnostics;

namespace MoviesAdmin.Controllers
{
    public class catlogsController : Controller
    {
        private readonly MoviesAdminContext _context;

        public catlogsController(MoviesAdminContext context)
        {
            _context = context;
        }

        // GET: catlogs
        public async Task< IActionResult> Index()
        {
            return View(await _context.catlogs.ToListAsync());
        }

        // GET: catlogs/Details/5
        public async Task< IActionResult> Details(int? id)
        {
            if (id == null || _context.catlogs == null)
            {
                return NotFound();
            }

            var catlogs = await _context.catlogs.FindAsync(id);
            if (catlogs == null)
            {
                return NotFound();
            }

            return View(catlogs);
        }

        // GET: catlogs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: catlogs/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task< IActionResult> Create([Bind("ID")] catlogs catlogs)
        {
            if (ModelState.IsValid)
            {
                _context.Add(catlogs);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(catlogs);
        }

        // GET: catlogs/Edit/5
        public async Task< IActionResult> Edit(int? id)
        {
            if (id == null || _context.catlogs == null)
            {
                return NotFound();
            }

            var catlogs = await _context.catlogs.FindAsync(id);
            if (catlogs == null)
            {
                return NotFound();
            }

            return View(catlogs);
        }

        // POST: catlogs/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task< IActionResult> Edit([Bind("ID")] catlogs catlogs)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(catlogs);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!catlogsExists(catlogs.ID))
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

            return View(catlogs);
        }

        // GET: catlogs/Delete/5
        public async Task< IActionResult> Delete(int? id)
        {
            if (id == null || _context.catlogs == null)
            {
                return NotFound();
            }

            var catlogs = await _context.catlogs.FindAsync(id);
            if (catlogs == null)
            {
                return NotFound();
            }

            return View(catlogs);
        }

        // POST: catlogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task< IActionResult> DeleteConfirmed(int id)
        {
            if (_context.catlogs == null)
            {
                return Problem("Entity set 'MoviesAdminContext.catlogs'  is null.");
            }

            var catlogs = await _context.catlogs.FindAsync(id);
            if (catlogs != null)
            {
                _context.catlogs.Remove(catlogs);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool catlogsExists(int id)
        {
            return _context.catlogs.Any(e => e.ID == id);
        }
    }
}