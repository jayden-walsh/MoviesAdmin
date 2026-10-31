
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesAdmin.Models;
using MoviesAdmin.Service;

[Authorize]
public class MoviesController : Controller
{
    private readonly MoviesAdminContext _context;
    private readonly AzureStrorageService _azureStorageService;
    public MoviesController(MoviesAdminContext context, AzureStrorageService azureStrorage)
    {
        _context = context;
        _azureStorageService = _azureStorageService;
    }


    //GET: MOVIES
    public async Task<IActionResult> Index()
    {
        List<Movie> movies = await _context.Movie
          .Include(m => m.catlogs) //populate the nav property
          .ToListAsync();

        return View(await _context.Movie.ToListAsync());
    }

    //for git psuh

    // GET: MOVIES/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var movie = await _context.Movie
        .FirstOrDefaultAsync(m => m.ID == id);
        if (movie == null)
        {
            return NotFound();
        }

        return View(movie);

    }

    // GET: MOVIES/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: MOVIES/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("ID,Title,Rating,Description,Genre,Runtime,Releases")] Movie movie, IFormFile? ImageUpload)
    {

        if (ModelState.IsValid)// to vaid
        {
            string filename = ImageUpload.FileName;
            string url = await _azureStorageService.UploadFileAsync(ImageUpload, filename);

            movie.ImageUrl = url;

            _context.Add(movie);
            
            await _context.SaveChangesAsync();
            
            return RedirectToAction(nameof(Index));
        }
        return View(movie);
    }

    // GET: MOVIES/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var movie = await _context.Movie.FindAsync(id);
        if (movie == null)
        {
            return NotFound();
        }
        return View(movie);
    }

    // POST: MOVIES/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("ID,Title,Rating,Description,Genre,Runtime,Releases")] Movie movie)
    {
        if (id != movie.ID)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(movie);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(movie.ID))
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
        return View(movie);
    }

    // GET: MOVIES/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var movie = await _context.Movie
            .FirstOrDefaultAsync(m => m.ID == id);
        if (movie == null)
        {
            return NotFound();
        }

        return View(movie);
    }

    // POST: MOVIES/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var movie = await _context.Movie.FindAsync(id);
        if (movie != null)
        {
            _context.Movie.Remove(movie);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool MovieExists(int? id)
    {
        return _context.Movie.Any(e => e.ID == id);
    }
}
