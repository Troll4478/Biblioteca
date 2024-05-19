using Biblioteca.Modelos;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Repositorio
{
	public class RepositorioUsuarios : IRepositorioUsuarios
	{
		private readonly BibliotecaDBContext _context;
		public RepositorioUsuarios(BibliotecaDBContext context)
		{
			_context = context;
		}
		public async Task<Usuario> Add(Usuario usuario)
		{
            await _context.Usuarios.AddAsync(usuario);
			await _context.SaveChangesAsync();
			return usuario;
		}

		public async Task Delete(int id)
		{
			var usuario = await _context.Usuarios.FindAsync(id);
			if (usuario != null)
			{
				_context.Usuarios.Remove(usuario);
				await _context.SaveChangesAsync();
			}
		}

		public async Task<Usuario?> Get(int id)
		{
			return await _context.Usuarios.FindAsync(id);
		}

		public async Task<List<Usuario>> GetAll()
		{
			return await _context.Usuarios.ToListAsync();
		}
        public async Task<List<TipoDeUsuario>> GetTipoDeUsuarios()
        {
            return await _context.TipoDeUsuarios.ToListAsync();
        }

        public async Task Update(int id, Usuario usuario)
		{
			var usuarioactual = await _context.Usuarios.FindAsync(id);
			if (usuarioactual != null)
			{
				usuarioactual.Nombre = usuario.Nombre;
				usuarioactual.Apellido = usuario.Apellido;
				usuarioactual.Correo = usuario.Correo;
			
				await _context.SaveChangesAsync();
			}
		}
	}
}
