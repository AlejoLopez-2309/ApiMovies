using System.ComponentModel.DataAnnotations;

namespace ApiMovies.DAL.Dtos
{
    public class MovieDtos
    {
        public int Id { get; set; }

        [MaxLength(100)]
        [Required(ErrorMessage = "El Nombre de la pelicula es obligatorio")]
        public string Name { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        [Required(ErrorMessage = "El campo Duración es obligatorio")]
        public int Duration { get; set; }

        [MaxLength(100)]
        public string? Description { get; set; }

        [MaxLength(10)]
        [Required(ErrorMessage = "El campo Clasificación es obligatorio")]
        public string Clasification { get; set; }
    }
}