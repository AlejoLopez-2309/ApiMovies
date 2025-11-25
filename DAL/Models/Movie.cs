using System.ComponentModel.DataAnnotations;

namespace ApiMovies.DAL.Models
{
    public class Movie : AuditBase
    {
        [MaxLength(100)]
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El campo Nombre es requerido")]
        public string Name { get; set; }

        [Display(Name = "Duración")]
        [Required(ErrorMessage = "El campo de la duración de la pelicula es requerido")]
        public int Duration { get; set; }

        [MaxLength(200)]
        [Display(Name = "Descripción")]
        public string? Description { get; set; }

        [MaxLength(50)]
        [Display(Name = "Clasificación")]
        public string? Clasification { get; set; }
    }
}