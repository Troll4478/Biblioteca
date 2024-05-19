using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Modelos
{
    public class Usuario
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100, ErrorMessage ="Maximo 100 caracteres")]
        public string? Nombre { get; set; }
        [Required(ErrorMessage = "El apellido es obligatorio")]
        [StringLength(100, ErrorMessage = "Maximo 100 caracteres")]
        public string? Apellido { get; set; }

        [Required(ErrorMessage = "El correo es obligatorio")]
        [EmailAddress(ErrorMessage ="Debe ser un correo valido")]
        [StringLength(100, ErrorMessage = "Maximo 100 caracteres")]
        public string? Correo { get; set; }
        public ICollection<Prestamo> Prestamos { get; set; } = new List<Prestamo>();
        //Propiedades de navegacion EF
        public int TipoDeUsuarioId { get; set; }
        virtual public TipoDeUsuario? TipoDeUsuario { get; set; }

    }
}
