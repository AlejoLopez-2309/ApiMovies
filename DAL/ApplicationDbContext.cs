using Microsoft.EntityFrameworkCore;

namespace ApiMovies.DAL
{
    public class ApplicationDbContext : DbContext
    {
        //Constructor
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Models.CategoryDto> Categories { get; set; }
    }
}