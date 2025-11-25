using ApiMovies.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiMovies.DAL
{
    public class ApplicationDbContext : DbContext
    {
        //Constructor
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Movie> Movies { get; set; }
    }
}