using ApiMovies.DAL.Dtos;
using ApiMovies.DAL.Models.Dtos;
using ApiMovies.Repository;
using ApiMovies.Repository.IRepository;
using ApiMovies.Services.IService;
using AutoMapper;

namespace ApiMovies.Services
{
    public class MovieServices : IMovieServices
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;

        public MovieServices(IMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }

        public Task<MovieDtos> CreateMovieAsync(MovieCreateUpdateDtos movieDtos)
        {
            throw new NotImplementedException();
        }

        public Task<MovieDtos> GetMovieAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<MovieDtos>> GetMoviesAsync()
        {
            var movies = await _movieRepository.GetMoviesAsync();

            return _mapper.Map<ICollection<MovieDtos>>(movies);
        }

        public async Task<bool> MovieCategoryAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> MovieExistsByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> MovieExistsByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<MovieDtos> UpdateMovieAsync(MovieCreateUpdateDtos dto, int id)
        {
            throw new NotImplementedException();
        }
    }
}