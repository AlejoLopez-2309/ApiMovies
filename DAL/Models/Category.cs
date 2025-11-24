using System.ComponentModel.DataAnnotations;

namespace ApiMovies.DAL.Models
{
    public class Category : AuditBase
    {
        [Required]
        public string Name { get; set; }
    }
}