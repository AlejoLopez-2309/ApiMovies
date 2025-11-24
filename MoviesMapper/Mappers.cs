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
            CreateMap<Category, CategoryDtos>().ReverseMap();
            CreateMap<Category, CategoryCreateUpdateDtos>().ReverseMap();
        }
    }
}