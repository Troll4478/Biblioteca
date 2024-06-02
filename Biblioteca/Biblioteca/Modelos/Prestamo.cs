using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Modelos
{
    public class Prestamo
    {
        public int Id { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "El usuario es requerido")]
        public int UsuarioId { get; set; }

        virtual public Usuario? Usuario { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "El libro es requerido")]
        public int LibroId { get; set; }

        virtual public Libro? Libro { get; set; }

        [Required(ErrorMessage = "La fecha de préstamo es requerida")]
        public DateTime FechaPrestamo { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "La fecha de devolución prevista es requerida")]
        public DateTime FechaDevolucionPrevista { get; set; } = DateTime.Now.AddDays(7);
        public string EstadoPrestamo => FechaDevolucionPrevista <= DateTime.Now ? "Devuelto" : "Prestado";

    }
}
