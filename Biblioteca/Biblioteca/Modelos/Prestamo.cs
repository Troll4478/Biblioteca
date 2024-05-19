using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Modelos
{
    public class Prestamo
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El ID del usuario es requerido")]
        public int IDUsuario { get; set; }

        [Required(ErrorMessage = "El usuario es requerido")]
        public required Usuario Usuario { get; set; }

        [Required(ErrorMessage = "El ID del libro es requerido")]
        public int IdLibro { get; set; }

        [Required(ErrorMessage = "El libro es requerido")]
        public required Libro Libro { get; set; }

        [Required(ErrorMessage = "La fecha de préstamo es requerida")]
        public DateTime FechaPrestamo { get; set; }

        [Required(ErrorMessage = "La fecha de devolución prevista es requerida")]
        public DateTime FechaDevolucionPrevista { get; set; }
        public string EstadoPrestamo => FechaDevolucionPrevista <= DateTime.Now ? "Devuelto" : "Prestado";

    }
}
