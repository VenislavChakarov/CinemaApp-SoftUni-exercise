using System.Globalization;
using Azure.Core.Pipeline;
using CinemaApp.Data;
using CinemaApp.Services.Core.interfaces;
using CinemaApp.Web.ViewModels.Movie;
using Microsoft.EntityFrameworkCore;
using static CinemaApp.Data.Common.EntityConstants.Movie;

namespace CinemaApp.Services.Core;

public class MovieServiece : IMovieService
{
    private readonly ApplicationDbContext _dbContext;
    
public MovieServiece(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<IEnumerable<AllMoviesIndexViewModel>> GetAllMoviesAsync()
    {
        var movies = await _dbContext.Movies
            .Where(m => !m.IsDeleted)
            .AsNoTracking()
            .Select(m => new AllMoviesIndexViewModel
            {
                Id = m.Id.ToString(),
                Title = m.Title,
                Genre = m.Genre,
                ReleaseDate = m.ReleaseDate.ToString("yyyy-MM-dd"),
                Director = m.Director,
                ImageUrl = m.ImageUrl
            }).ToListAsync();
        
        return movies;
    }
    

    public async Task AddAsync(MovieFormViewModel model)
    {
        var movie = new Data.Models.Movie
        {
            Title = model.Title,
            Genre = model.Genre,
            Director = model.Director,
            Description = model.Description,
            Duration = model.Duration,
            ReleaseDate = DateTime.ParseExact(model.ReleaseDate, ReleaseDateFormat, CultureInfo.InvariantCulture),
            ImageUrl = model.ImageUrl,
        };

        await _dbContext.Movies.AddAsync(movie);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<MovieDetailsViewModel> GetByIdAsync(string id)
    {
        var movie = await _dbContext.Movies
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.Id.ToString() == id && !m.IsDeleted);

        if (movie == null)
        {
            return null;
        }
        
        return new MovieDetailsViewModel
        {
            Id = movie.Id.ToString(),
            Title = movie.Title,
            Genre = movie.Genre,
            Director = movie.Director,
            Description = movie.Description,
            Duration = movie.Duration,
            ReleaseDate = movie.ReleaseDate.ToString("yyyy-MM-dd"),
            ImageUrl = movie.ImageUrl
        };
        
    }

    public async Task<MovieFormViewModel> GetForEditByIdAsync(string id)
    {
        return await _dbContext.Movies
            .Where(m => m.Id.ToString() == id)
            .Select(m => new MovieFormViewModel
            {
                id = m.Id.ToString(),
                Title = m.Title,
                Genre = m.Genre,
                Director = m.Director,
                Description = m.Description,
                Duration = m.Duration,
                ReleaseDate = m.ReleaseDate.ToString(ReleaseDateFormat),
                ImageUrl = m.ImageUrl
            })
            .FirstOrDefaultAsync();
    }
    

    public async Task EditAsync(MovieFormViewModel model, string id)
    {
        var movie = await _dbContext.Movies
            .FirstOrDefaultAsync(m => m.Id.ToString() == id);

        if (movie == null)
        {
            return;
        }
        
        movie.Title = model.Title;
        movie.Genre = model.Genre;
        movie.Director = model.Director;
        movie.Description = model.Description;
        movie.Duration = model.Duration;
        movie.ReleaseDate = DateTime.ParseExact(model.ReleaseDate, ReleaseDateFormat, CultureInfo.InvariantCulture);
        movie.ImageUrl = model.ImageUrl;
        
        await _dbContext.SaveChangesAsync();
        
    }

    public async Task SoftDeleteAsync(string id)
    {
        var movie = await _dbContext.Movies
            .FirstOrDefaultAsync(m => m.Id.ToString() == id && !m.IsDeleted);
        
        if (movie != null && !movie.IsDeleted)
        {
            movie.IsDeleted = true;
            await _dbContext.SaveChangesAsync();
        }
    }

    public async Task HardDeleteAsync(string id)
    {
        var movie = await _dbContext.Movies
            .FirstOrDefaultAsync(m => m.Id.ToString() == id);

        if (movie != null)
        {
            _dbContext.Movies.Remove(movie);
            await _dbContext.SaveChangesAsync();
        }
    }
}

