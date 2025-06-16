using System.Reflection;

namespace CinemaApp.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Models;
    public class CinemaAppDbContext : IdentityDbContext
    {
        
        public virtual DbSet<Movie> Movies { get; set; }
        
        public virtual DbSet<UserMovie> UserMovies { get; set; }
        public CinemaAppDbContext(DbContextOptions<CinemaAppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
