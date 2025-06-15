using System.ComponentModel.DataAnnotations;
using CinemaApp.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace CinemaApp.Data.Models;

[Comment("Movie in the system")]

public class Movie
{
    [Comment("Unique identifier for the movie")]
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();
    
    [Comment("Title of the movie")]
    [Required(ErrorMessage = "Title is required")]
    [StringLength(EntityConstants.Movie.TitleMaxLength, ErrorMessage = "Title cannot exceed 100 characters")]

    public string Title { get; set; } = null!;
    
    [Comment("Description of the movie")]
    [Required(ErrorMessage = "Description is required")]
    [StringLength(EntityConstants.Movie.DescriptionMaxLength, ErrorMessage = "Description cannot exceed 1000 characters")]
    
    public string Description { get; set; } = null!;
    
    [Comment("Director of the movie")]
    [Required(ErrorMessage = "Director is required")]
    [StringLength(EntityConstants.Movie.DirectorNameMaxLength, ErrorMessage = "Director cannot exceed 100 characters")]
    
    public string Director { get; set; } = null!;
    
    [Comment("Genre of the movie")]
    [Required(ErrorMessage = "Genre is required")]
    [StringLength(EntityConstants.Movie.GenreMaxLength, ErrorMessage = "Genre cannot exceed 50 characters")]
    
    public string Genre { get; set; } = null!;
    
    [Comment("Release date of the movie")]
    [Required(ErrorMessage = "Release date is required")]
    
    public DateTime ReleaseDate { get; set; }
    
    [Comment("Duration of the movie in minutes")]
    [Required(ErrorMessage = "Duration is required")]
    [Range(EntityConstants.Movie.DurationMin, EntityConstants.Movie.DurationMax, 
        ErrorMessage = "Duration must be between 1 and 300 minutes")]
            
    public int Duration { get; set; } 
    [Comment("URL of the movie's poster image")]
    [StringLength(EntityConstants.Movie.ImageUrlMaxLength)]
    
    public string? ImageUrl { get; set; } 
    
    public bool IsDeleted { get; set; }
}