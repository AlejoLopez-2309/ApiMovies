using ApiMovies.DAL.Models;

namespace ApiMovies.Repository.IRepository
{
    public interface ICategoryRepository
    {
        Task<ICollection<CategoryDto>> GetCategoriesAsync(); //Me retorna una lista de categorías

        Task<CategoryDto> GetCategoryAsync(int Id); //Me retorna una categoría por su Id

        Task<bool> CategoryExistsAsync(int Id); //Me dice si una categoría existe por su Id

        Task<bool> CategoryExistsByNameAsync(string name); //Me Dice si existe uan categoria por nombre

        Task<bool> CreateCategoryAsync(CategoryDto category); //Me crea una categoría

        Task<bool> UpdateCategoryAsync(CategoryDto category); //Me actualiza una categoría y la fecha de actualización

        Task<bool> DeleteCategoryAsync(int Id); //Me elimina una categoría
    }
}