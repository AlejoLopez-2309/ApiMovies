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

        public Task<bool> CreateMovieAsync(Movie movie)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteMovieAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<Movie> GetMovieAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<Movie>> GetMoviesAsync()
        {
            var movie = await _context.Movies.AsNoTracking().OrderBy(c => c.Name).ToListAsync();
            return movie;
        }

        public Task<bool> MovieExistsAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> MovieExistsByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateMovieAsync(Movie movie)
        {
            throw new NotImplementedException();
        }
    }
}