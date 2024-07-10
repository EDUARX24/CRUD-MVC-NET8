using System.ComponentModel.DataAnnotations;

namespace CrudNet8MVC.Models
{
    public class Contacto
    {
        //Crear cada atributo de la tabal contacto
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El Nombre es obligatorio")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El Telefono es obligatorio")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "El Celular es obligatorio")]
        public string Celular { get; set; }

        [Required(ErrorMessage = "El Email es obligatorio")]
        public string Email { get; set; }
        //fecha de creacion
        public DateTime FechaCreacion { get; set; }
    }
}
