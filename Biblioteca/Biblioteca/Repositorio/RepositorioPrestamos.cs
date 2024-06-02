using Biblioteca.Modelos;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Repositorio
{
    public class RepositorioPrestamos : IRepositorioPrestamos
    {
        private readonly BibliotecaDBContext _context;
        public RepositorioPrestamos(BibliotecaDBContext context)
        {
            _context = context;
        }
        public async Task<Prestamo> Add(Prestamo prestamo)
        {
            prestamo.Usuario = await _context.Usuarios.FindAsync(prestamo.UsuarioId)
                                ?? throw new ArgumentException("Usuario no encontrado");
            prestamo.Libro = await _context.Libros.FindAsync(prestamo.LibroId)
                               ?? throw new ArgumentException("Libro no encontrado");

            if (prestamo.Libro.NumeroEjemplares <= 0)
            {
                throw new InvalidOperationException("No hay ejemplares disponibles para prestar.");
            }

            prestamo.Libro.NumeroEjemplares--;

            await _context.Prestamos.AddAsync(prestamo);
            await _context.SaveChangesAsync();
            return prestamo;
        }

        public async Task Delete(int id)
        {
            var prestamo = await _context.Prestamos.Include(p => p.Libro).FirstOrDefaultAsync(p => p.Id == id);
            if (prestamo != null)
            {
                // Incrementar la cantidad de ejemplares disponibles del libro
                prestamo.Libro.NumeroEjemplares++;

                _context.Prestamos.Remove(prestamo);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Prestamo?> Get(int id)
        {
            return await _context.Prestamos.FindAsync(id);
        }

        public async Task<List<Prestamo>> GetAll()
        {
            return await _context.Prestamos.Include(l=>l.Libro).Include(u=>u.Usuario).ToListAsync();
        }

        public async Task Update(int id, Prestamo prestamo)
        {
            var prestamoactual = await _context.Prestamos.FindAsync(id);
            if (prestamoactual != null)
            {
                prestamoactual.UsuarioId = prestamo.UsuarioId;
                prestamoactual.LibroId = prestamo.LibroId;
                prestamoactual.FechaPrestamo = prestamo.FechaPrestamo;
                prestamoactual.FechaDevolucionPrevista = prestamo.FechaDevolucionPrevista;

                await _context.SaveChangesAsync();
            }
        }
    }
}
