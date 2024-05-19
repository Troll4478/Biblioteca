using Biblioteca.Modelos;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Repositorio
{
    public class RepositorioLibros : IRepositorioLibros
    {
        private readonly BibliotecaDBContext _context;
        public RepositorioLibros(BibliotecaDBContext context)
        {
            _context = context;
        }
        public async Task<Libro> Add(Libro libro)
        {
            await _context.Libros.AddAsync(libro);
            await _context.SaveChangesAsync();
            return libro;
        }

        public async Task Delete(int id)
        {
            var libro = await _context.Libros.FindAsync(id);
            if (libro != null)
            {
                _context.Libros.Remove(libro);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Libro?> Get(int id)
        {
            return await _context.Libros.FindAsync(id);
        }

        public async Task<List<Libro>> GetAll()
        {
            return await _context.Libros.ToListAsync();
        }

        public async Task Update(int id, Libro libro)
        {
            var libroactual = await _context.Libros.FindAsync(id);
            if (libroactual != null)
            {
                libroactual.Titulo = libro.Titulo;
                libroactual.Autor = libro.Autor;
                libroactual.Genero = libro.Genero;
                libroactual.NumeroEjemplares = libro.NumeroEjemplares;
                bool disponibilidad = libro.Disponibilidad;

                await _context.SaveChangesAsync();
            }
        }
    }
}
