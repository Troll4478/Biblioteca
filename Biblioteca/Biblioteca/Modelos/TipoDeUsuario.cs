namespace Biblioteca.Modelos
{
    public class TipoDeUsuario
    {
        public int Id { get; set; }
        public string? Tipo { get; set; }
        //Propiedad de navegacion EF
        virtual public ICollection<Usuario>? Usuarios { get; set; }
    }
}
