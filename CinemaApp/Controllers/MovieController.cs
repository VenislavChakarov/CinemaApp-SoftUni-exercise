using CinemaApp.Services.Core.interfaces;
using CinemaApp.Web.ViewModels.Movie;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CinemaApp.Web.Controllers;

public class MovieController : BaseController
{
    private readonly IMovieService _movieService;
    
    public MovieController(IMovieService movieService)
    {
        _movieService = movieService;
    }
    
    
    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> Index()
    {
        var allMovies = await this._movieService
            .GetAllMoviesAsync();

        return View(allMovies);
    }
    
    [HttpGet]
    
    public IActionResult Create()
    {
        return View(new MovieFormViewModel());
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(MovieFormViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        await this._movieService.AddAsync(model);

        return RedirectToAction(nameof(Index));
    }
    
    [HttpGet]
    public async Task<IActionResult> Details(string id)
    {
        var movie = await this._movieService.GetByIdAsync(id);

        if (movie == null)
        {
            return NotFound();
        }

        return View(movie);
    }
    
    [HttpGet]
    public async Task<IActionResult> Edit(string id)
    {
        var model = await this._movieService.GetForEditByIdAsync(id);

        if (model == null)
        {
            return NotFound();
        }

        return View(model);
    }
    
    [HttpPost]
    public async Task<IActionResult> Edit(MovieFormViewModel model, string id)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        await this._movieService.EditAsync(model, id);

        return RedirectToAction(nameof(Details), new { id });
    }
    
    [HttpGet]
    
    public async Task<IActionResult> Delete(string id)
    {
        var movie = await this._movieService.GetByIdAsync(id);

        if (movie == null)
        {
            return NotFound();
        }

        return View(movie);
    }
    
    [HttpPost]
    public async Task<IActionResult> DeleteConfirmed(string id)
    {
        await this._movieService.SoftDeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }
}