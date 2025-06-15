using CinemaApp.Web.ViewModels.Movie;

namespace CinemaApp.Services.Core.interfaces;

public interface IMovieService
{
    Task<IEnumerable<AllMoviesIndexViewModel>> GetAllMoviesAsync();
    
    Task AddAsync(MovieFormViewModel model);
    
    Task<MovieDetailsViewModel> GetByIdAsync(string id);
    
    Task<MovieFormViewModel> GetForEditByIdAsync(string id);
    
    Task EditAsync(MovieFormViewModel model, string id);
    
    Task SoftDeleteAsync(string id);
    
    Task HardDeleteAsync(string id);
}