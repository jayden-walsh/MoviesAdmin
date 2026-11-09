
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesAdmin.Models;

public class criticreviewsController : Controller
{
    private readonly MoviesAdminContext _context;

    public criticreviewsController(MoviesAdminContext context)
    {
        _context = context;
    }

    // GET: CRITICREVIEWS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.criticreview.ToListAsync());
    }

    // GET: CRITICREVIEWS/Details/5
    public async Task<IActionResult> Details(int? reivewsid)
    {
        if (reivewsid == null)
        {
            return NotFound();
        }

        var criticreview = await _context.criticreview
            .FirstOrDefaultAsync(m => m.ReivewsId == reivewsid);
        if (criticreview == null)
        {
            return NotFound();
        }

        return View(criticreview);
    }

    // GET: CRITICREVIEWS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: CRITICREVIEWS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("ReivewsId,Description,Raiting,madeby,madeData,IsPublished,Movie")] criticreview criticreview)
    {
        if (ModelState.IsValid)
        {
            _context.Add(criticreview);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(criticreview);
    }

    // GET: CRITICREVIEWS/Edit/5
    public async Task<IActionResult> Edit(int? reivewsid)
    {
        if (reivewsid == null)
        {
            return NotFound();
        }

        var criticreview = await _context.criticreview.FindAsync(reivewsid);
        if (criticreview == null)
        {
            return NotFound();
        }
        return View(criticreview);
    }

    // POST: CRITICREVIEWS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? reivewsid, [Bind("ReivewsId,Description,Raiting,madeby,madeData,IsPublished,Movie")] criticreview criticreview)
    {
        if (reivewsid != criticreview.ReivewsId)
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
                if (!CriticreviewExists(criticreview.ReivewsId))
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

    // GET: CRITICREVIEWS/Delete/5
    public async Task<IActionResult> Delete(int? reivewsid)
    {
        if (reivewsid == null)
        {
            return NotFound();
        }

        var criticreview = await _context.criticreview
            .FirstOrDefaultAsync(m => m.ReivewsId == reivewsid);
        if (criticreview == null)
        {
            return NotFound();
        }

        return View(criticreview);
    }

    // POST: CRITICREVIEWS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? reivewsid)
    {
        var criticreview = await _context.criticreview.FindAsync(reivewsid);
        if (criticreview != null)
        {
            _context.criticreview.Remove(criticreview);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool CriticreviewExists(int? reivewsid)
    {
        return _context.criticreview.Any(e => e.ReivewsId == reivewsid);
    }
}
