using System.ComponentModel.DataAnnotations;

namespace ApiMovies.DAL.Models
{
    public class CategoryDto : AuditBase
    {
        [Required]
        public string Name { get; set; }
    }
}