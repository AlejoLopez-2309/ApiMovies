using ApiMovies.DAL;
using ApiMovies.DAL.Models;
using ApiMovies.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace ApiMovies.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private readonly ApplicationDbContext _context;

        public MovieRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateMovieAsync(Movie movie)
        {
            movie.CreatedDate = DateTime.UtcNow;

            await _context.Movies.AddAsync(movie);
            return await SaveAsync();
        }

        public async Task<bool> DeleteMovieAsync(int Id)
        {
            var movie = await GetMovieAsync(Id);
            if (movie == null)
            {
                return false;
            }

            _context.Movies.Remove(movie);
            return await SaveAsync();
        }

        public async Task<Movie> GetMovieAsync(int Id)
        {
            return await _context.Movies.AsNoTracking().FirstOrDefaultAsync(c => c.Id == Id);
        }

        public async Task<ICollection<Movie>> GetMoviesAsync()
        {
            var movie = await _context.Movies.AsNoTracking().OrderBy(c => c.Name).ToListAsync();
            return movie;
        }

        public async Task<bool> MovieExistsAsync(int Id)
        {
            return await _context.Movies
            .AsNoTracking()
            .AnyAsync(c => c.Id == Id);
        }

        public async Task<bool> MovieExistsByNameAsync(string name)
        {
            return await _context.Movies
              .AsNoTracking()
              .AnyAsync(c => c.Name == name);
        }

        public async Task<bool> UpdateMovieAsync(Movie movie)
        {
            movie.ModifiedDate = DateTime.UtcNow;

            _context.Movies.Update(movie);
            return await SaveAsync();
        }

        private async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() >= 0 ? true : false;
        }
    }
}