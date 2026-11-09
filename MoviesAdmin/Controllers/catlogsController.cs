
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesAdmin.Models;

public class catlogsController : Controller
{
    private readonly MoviesAdminContext _context;

    public catlogsController(MoviesAdminContext context)
    {
        _context = context;
    }

    // GET: CATLOGSS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.catlogs.ToListAsync());
    }

    // GET: CATLOGSS/Details/5
    public async Task<IActionResult> Details(int? catlogid)
    {
        if (catlogid == null)
        {
            return NotFound();
        }

        var catlogs = await _context.catlogs
            .FirstOrDefaultAsync(m => m.catlogId == catlogid);
        if (catlogs == null)
        {
            return NotFound();
        }

        return View(catlogs);
    }

    // GET: CATLOGSS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: CATLOGSS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("catlogId,Movies,Title")] catlogs catlogs)
    {
        if (ModelState.IsValid)
        {
            _context.Add(catlogs);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(catlogs);
    }

    // GET: CATLOGSS/Edit/5
    public async Task<IActionResult> Edit(int? catlogid)
    {
        if (catlogid == null)
        {
            return NotFound();
        }

        var catlogs = await _context.catlogs.FindAsync(catlogid);
        if (catlogs == null)
        {
            return NotFound();
        }
        return View(catlogs);
    }

    // POST: CATLOGSS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? catlogid, [Bind("catlogId,Movies,Title")] catlogs catlogs)
    {
        if (catlogid != catlogs.catlogId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(catlogs);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CatlogsExists(catlogs.catlogId))
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

    // GET: CATLOGSS/Delete/5
    public async Task<IActionResult> Delete(int? catlogid)
    {
        if (catlogid == null)
        {
            return NotFound();
        }

        var catlogs = await _context.catlogs
            .FirstOrDefaultAsync(m => m.catlogId == catlogid);
        if (catlogs == null)
        {
            return NotFound();
        }

        return View(catlogs);
    }

    // POST: CATLOGSS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? catlogid)
    {
        var catlogs = await _context.catlogs.FindAsync(catlogid);
        if (catlogs != null)
        {
            _context.catlogs.Remove(catlogs);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool CatlogsExists(int? catlogid)
    {
        return _context.catlogs.Any(e => e.catlogId == catlogid);
    }
}
