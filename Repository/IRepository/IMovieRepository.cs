using ApiMovies.DAL.Models;

namespace ApiMovies.Repository.IRepository
{
    public interface IMovieRepository
    {
        Task<ICollection<Movie>> GetMoviesAsync();

        Task<Movie> GetMovieAsync(int Id);

        Task<bool> UpdateMovieAsync(Movie movie);

        Task<bool> CreateMovieAsync(Movie movie);

        Task<bool> MovieExistsAsync(int Id);

        Task<bool> MovieExistsByNameAsync(string name);

        Task<bool> DeleteMovieAsync(int Id);
    }
}