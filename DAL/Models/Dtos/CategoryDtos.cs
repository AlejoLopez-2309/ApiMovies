using System.ComponentModel.DataAnnotations;

namespace ApiMovies.DAL.Models.Dtos
{
    public class CategoryDtos
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre de la categoria es obligatorio")]
        [MaxLength(ErrorMessage = "El número máximo de caracteres es de 100.")]
        public string Name { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }
    }
}