using ApiMovies.DAL.Models.Dtos;
using ApiMovies.Repository.IRepository;
using ApiMovies.Services.IService;
using AutoMapper;

namespace ApiMovies.Services
{
    public class CategoryServices : ICategoryServices
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryServices(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public Task<bool> CategoryExistsAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CategoryExistsByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CreateCategoryAsync(CategoryCreateDtos categoryCreateDtos)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteCategoryAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<CategoryDtos>> GetCategoriesAsync()
        {
            var categories = await _categoryRepository.GetCategoriesAsync();
            return _mapper.Map<ICollection<CategoryDtos>>(categories);
        }

        public Task<CategoryDtos> GetCategoryAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateCategoryAsync(int Id, CategoryCreateDtos categoryCreateDtos)
        {
            throw new NotImplementedException();
        }
    }
}