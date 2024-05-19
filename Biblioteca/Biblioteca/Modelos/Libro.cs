using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Modelos
{
    public class Libro
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El título es requerido")]
        [StringLength(100, ErrorMessage = "Máximo de 100 caracteres")]
        public string? Titulo { get; set; }

        [Required(ErrorMessage = "El autor es requerido")]
        [StringLength(50, ErrorMessage = "Máximo de 50 caracteres")]
        public string? Autor { get; set; }

        [Required(ErrorMessage = "El género es requerido")]
        [StringLength(50, ErrorMessage = "Máximo de 50 caracteres")]
        public string? Genero { get; set; }

        [Required(ErrorMessage = "El número de ejemplares es requerido")]
        [Range(0, int.MaxValue, ErrorMessage = "El número de ejemplares debe ser mayor o igual que cero")]
        public int NumeroEjemplares { get; set; }

        public bool Disponibilidad => NumeroEjemplares > 0;
        public ICollection<Prestamo> Prestamos { get; set; } = new List<Prestamo>();
    }
}
