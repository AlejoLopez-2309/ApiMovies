using ApiMovies.DAL.Models;
using ApiMovies.DAL.Models.Dtos;
using AutoMapper;

namespace ApiMovies.MoviesMapper
{
    public class Mappers : Profile
    {
        public Mappers()
        {
            //Category
            CreateMap<CategoryDto, CategoryDtos>().ReverseMap();
            CreateMap<CategoryDto, CategoryCreateDtos>().ReverseMap();
        }
    }
}