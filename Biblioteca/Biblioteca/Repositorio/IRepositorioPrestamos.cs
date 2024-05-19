using Biblioteca.Modelos;

namespace Biblioteca.Repositorio
{
    public interface IRepositorioPrestamos
    {
        Task<List<Prestamo>> GetAll();
        Task<Prestamo?> Get(int id);
        Task<Prestamo> Add(Prestamo prestamo);
        Task Update(int id, Prestamo prestamo);
        Task Delete(int id);
    }
}
