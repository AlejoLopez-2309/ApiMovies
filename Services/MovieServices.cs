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
            var movieExists = await _movieRepository.GetMovieAsync(Id);

            if (movieExists == null)
            {
                throw new InvalidOperationException($"No se encontro la pelicula con ID: '{Id}'");
            }

            var movieDeleted = await _movieRepository.DeleteMovieAsync(Id);

            if (!movieDeleted)
            {
                throw new Exception("No se pudo eliminar la pelicula");
            }
            return movieDeleted;
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

        public async Task<MovieDtos> UpdateMovieAsync(MovieCreateUpdateDtos dto, int id)
        {
            var movieExists = await _movieRepository.GetMovieAsync(id);
            if (movieExists == null)
            {
                throw new InvalidOperationException($"No se encontro la pelicula con ID: '{id}'");
            }

            var nameExits = await _movieRepository.MovieExistsByNameAsync(dto.Name);
            if (nameExits)
            {
                throw new InvalidOperationException($"Ya existe la pelicula con el nombre de: '{dto.Name}'");
            }

            _mapper.Map(dto, movieExists);

            var movieUpdated = await _movieRepository.UpdateMovieAsync(movieExists);

            if (!movieUpdated)
            {
                throw new Exception("No se pudo actualizar la pelicula");
            }
            return _mapper.Map<MovieDtos>(movieExists);
        }

        Task<bool> IMovieServices.MovieExistsByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }
    }
}