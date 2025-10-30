using System.ComponentModel.DataAnnotations;

namespace ApiMovies.DAL.Models
{
    public class AuditBase
    {
        [Key]
        public virtual int Id { get; set; } //Pk de todas las tablas

        public virtual DateTime CreatedDate { get; set; } //Este me sirve para saber cuando se creo el registro en BD

        public virtual DateTime? ModifiedDate { get; set; } //Este me sirve para saber cuando se modifico el registro en BD
    }
}