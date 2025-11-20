using ApiMovies.DAL.Models.Dtos;

namespace ApiMovies.Services.IService
{
    public interface ICategoryServices
    {
        Task<ICollection<CategoryDtos>> GetCategoriesAsync();

        Task<CategoryDtos> GetCategoryAsync(int Id);

        Task<bool> CategoryExistsAsync(int Id);

        Task<bool> CategoryExistsByNameAsync(string name);

        Task<bool> CreateCategoryAsync(CategoryCreateDtos categoryCreateDtos);

        Task<bool> UpdateCategoryAsync(int Id, CategoryCreateDtos categoryCreateDtos);

        Task<bool> DeleteCategoryAsync(int Id);
    }
}