using ApiMovies.DAL;
using ApiMovies.DAL.Models;
using ApiMovies.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace ApiMovies.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CategoryExistsAsync(int Id)
        {
            return await _context.Categories
            .AsNoTracking()
            .AnyAsync(c => c.Id == Id);
        }

        public async Task<bool> CategoryExistsByNameAsync(string name)
        {
            return await _context.Categories
              .AsNoTracking()
              .AnyAsync(c => c.Name == name);
        }

        public async Task<bool> CreateCategoryAsync(Category category)
        {
            category.CreatedDate = DateTime.UtcNow;

            await _context.Categories.AddAsync(category);
            return await SaveAsync();
        }

        public async Task<bool> DeleteCategoryAsync(int Id)
        {
            var Category = await GetCategoryAsync(Id);
            if (Category == null)
            {
                return false;
            }

            _context.Categories.Remove(Category);
            return await SaveAsync();
        }

        public async Task<ICollection<Category>> GetCategoriesAsync()
        {
            return await _context.Categories.AsNoTracking().OrderBy(c => c.Name).ToListAsync();
        }

        public async Task<Category> GetCategoryAsync(int Id) //Async y el await
        {
            return await _context.Categories.AsNoTracking().FirstOrDefaultAsync(c => c.Id == Id);
        }

        public async Task<bool> UpdateCategoryAsync(Category category)
        {
            category.ModifiedDate = DateTime.UtcNow;

            _context.Categories.Update(category);
            return await SaveAsync();
        }

        private async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() >= 0 ? true : false;
        }
    }
}