using ApiMovies.DAL.Models;
using ApiMovies.DAL.Models.Dtos;

namespace ApiMovies.Repository.IRepository
{
    public interface ICategoryRepository
    {
        Task<ICollection<Category>> GetCategoriesAsync(); //Me retorna una lista de categorías

        Task<Category> GetCategoryAsync(int Id); //Me retorna una categoría por su Id

        Task<bool> UpdateCategoryAsync(Category category); //Me actualiza una categoría y la fecha de actualización

        Task<bool> CreateCategoryAsync(Category category); //Me crea una categoría

        Task<bool> CategoryExistsAsync(int Id); //Me dice si una categoría existe por su Id

        Task<bool> CategoryExistsByNameAsync(string name); //Me Dice si existe uan categoria por nombre

        Task<bool> DeleteCategoryAsync(int Id); //Me elimina una categoría
    }
}