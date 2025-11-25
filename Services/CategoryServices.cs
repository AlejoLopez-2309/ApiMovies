using ApiMovies.DAL.Models;
using ApiMovies.DAL.Models.Dtos;
using ApiMovies.Repository.IRepository;
using ApiMovies.Services.IService;
using AutoMapper;
using System.Collections;

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

        public Task<bool> CategoryExistsByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CategoryExistsByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<CategoryDtos> CreateCategoryAsync(CategoryCreateUpdateDtos categoryCreateDto)
        {
            //para validar si la categoria ya existe

            var categoryExists = await _categoryRepository.CategoryExistsByNameAsync(categoryCreateDto.Name);
            if (categoryExists)
            {
                throw new InvalidOperationException($"Ya existe una categoría con el nombre de '{categoryCreateDto.Name}'");
            }

            //Mapeo de DTO a entidad

            var category = _mapper.Map<Category>(categoryCreateDto);

            //Creamos la categoria en el repositorio

            var categoryCreated = await _categoryRepository.CreateCategoryAsync(category);

            if (!categoryCreated)
            {
                throw new Exception("No se pudo crear la categoría");
            }

            return _mapper.Map<CategoryDtos>(category);
        }

        public async Task<bool> DeleteCategoryAsync(int Id)
        {
            //verificar si la categoria existe

            var categoryExists = await _categoryRepository.GetCategoryAsync(Id);

            if (categoryExists == null)
            {
                throw new InvalidOperationException($"No se encontro la categoría con ID: '{Id}'");
            }

            var categoryDeleted = await _categoryRepository.DeleteCategoryAsync(Id);

            if (!categoryDeleted)
            {
                throw new Exception("No se pudo eliminar la categoría");
            }
            return categoryDeleted;
        }

        public async Task<ICollection<CategoryDtos>> GetCategoriesAsync()
        {
            //Obtengo las categorias desde el repositorio
            var categories = await _categoryRepository.GetCategoriesAsync();

            //Mapeo de entidades a DTOs
            return _mapper.Map<ICollection<CategoryDtos>>(categories);
        }

        public async Task<CategoryDtos> GetCategoryAsync(int Id)
        {
            var category = await GetCategoryByIdAsync(Id);

            //mapear toda la colección

            return _mapper.Map<CategoryDtos>(category);
        }

        public async Task<CategoryDtos> UpdateCategoryAsync(CategoryCreateUpdateDtos dtos, int id)
        {
            var categoryExists = await _categoryRepository.GetCategoryAsync(id);
            if (categoryExists == null)
            {
                throw new InvalidOperationException($"No se encontro la categoría con ID: '{id}'");
            }

            var nameExits = await _categoryRepository.CategoryExistsByNameAsync(dtos.Name);
            if (nameExits)
            {
                throw new InvalidOperationException($"Ya existe la categoría con el nombre de: '{dtos.Name}'");
            }

            //Mapeo de DTO a entidad

            _mapper.Map(dtos, categoryExists);

            var categoryUpdated = await _categoryRepository.UpdateCategoryAsync(categoryExists);

            if (!categoryUpdated)
            {
                throw new Exception("No se pudo actualizar la categoría");
            }
            return _mapper.Map<CategoryDtos>(categoryExists);
        }

        private async Task<Category> GetCategoryByIdAsync(int id)
        {
            var category = await _categoryRepository.GetCategoryAsync(id);

            if (category == null)
            {
                throw new InvalidOperationException($"No se encontró la categoría con ID: '{id}'");
            }

            return category;
        }
    }
}