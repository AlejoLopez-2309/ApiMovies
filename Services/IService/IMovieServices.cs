using ApiMovies.DAL.Dtos;
using ApiMovies.DAL.Models.Dtos;

namespace ApiMovies.Services.IService
{
    public interface IMovieServices
    {
        Task<ICollection<MovieDtos>> GetMoviesAsync();

        Task<MovieDtos> GetMovieAsync(int Id);

        Task<MovieDtos> CreateMovieAsync(MovieCreateUpdateDtos movieDtos);

        Task<MovieDtos> UpdateMovieAsync(MovieCreateUpdateDtos dto, int id);

        Task<bool> MovieExistsByIdAsync(int Id);

        Task<bool> MovieExistsByNameAsync(string name);

        Task<bool> MovieCategoryAsync(int Id);
    }
}