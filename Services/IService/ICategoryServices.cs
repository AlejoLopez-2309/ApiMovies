using ApiMovies.DAL.Models;
using ApiMovies.DAL.Models.Dtos;

namespace ApiMovies.Services.IService
{
    public interface ICategoryServices
    {
        Task<ICollection<CategoryDtos>> GetCategoriesAsync();

        Task<CategoryDtos> GetCategoryAsync(int Id);

        Task<CategoryDtos> CreateCategoryAsync(CategoryCreateUpdateDtos categoryDtos);

        Task<CategoryDtos> UpdateCategoryAsync(CategoryCreateUpdateDtos dtos, int id);

        Task<bool> CategoryExistsByIdAsync(int Id);

        Task<bool> CategoryExistsByNameAsync(string name);

        Task<bool> DeleteCategoryAsync(int Id);
    }
}