using ApiMovies.DAL.Dtos;
using ApiMovies.DAL.Models;
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

        public async Task<MovieDtos> CreateMovieAsync(MovieCreateUpdateDtos movieCreateDtos)
        {
            var movieExists = await _movieRepository.MovieExistsByNameAsync(movieCreateDtos.Name);
            if (movieExists)
            {
                throw new InvalidOperationException($"Ya existe una pelicula con el nombre de: '{movieCreateDtos.Name}'");
            }

            var movie = _mapper.Map<Movie>(movieCreateDtos);

            var movieCreated = await _movieRepository.CreateMovieAsync(movie);

            if (!movieCreated)
            {
                throw new Exception("No se pudo crear la pelicula");
            }

            return _mapper.Map<MovieDtos>(movie);
        }

        public async Task<MovieDtos> GetMovieAsync(int Id)
        {
            var movie = await GetMoviesByIdAsync(Id);

            return _mapper.Map<MovieDtos>(movie);
        }

        public async Task<ICollection<MovieDtos>> GetMoviesAsync()
        {
            var movies = await _movieRepository.GetMoviesAsync();

            return _mapper.Map<ICollection<MovieDtos>>(movies);
        }

        public async Task<bool> DeleteMovieAsync(int Id)
        {
            throw new NotImplementedException();
        }

        private async Task<Movie> GetMoviesByIdAsync(int id)
        {
            var movie = await _movieRepository.GetMovieAsync(id);

            if (movie == null)
            {
                throw new InvalidOperationException($"No se encontró la categoría con ID: '{id}'");
            }

            return movie;
        }

        public Task<bool> MovieExistsByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<MovieDtos> UpdateMovieAsync(MovieCreateUpdateDtos dto, int id)
        {
            throw new NotImplementedException();
        }

        Task<bool> IMovieServices.MovieExistsByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }
    }
}