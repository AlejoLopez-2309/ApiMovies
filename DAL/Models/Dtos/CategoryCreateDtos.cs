using System.ComponentModel.DataAnnotations;

namespace ApiMovies.DAL.Models.Dtos
{
    public class CategoryCreateDtos
    {
        [Required(ErrorMessage = "El nombre de la categoría es obligatorio ")]
        [MaxLength(100, ErrorMessage = "El numero de caracteres es de 100")]
        public string Name { get; set; }
    }
}