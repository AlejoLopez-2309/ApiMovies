using System.ComponentModel.DataAnnotations;

namespace ApiMovies.DAL.Models
{
    public class Movie : AuditBase
    {
        [Display(Name = "Nombre")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Duración")]
        [Required]
        public int Duration { get; set; }

        [Display(Name = "Descripción")]
        public string? Description { get; set; }

        [Display(Name = "Clasificación")]
        [Required]
        public string Clasification { get; set; }
    }
}