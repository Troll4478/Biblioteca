using Biblioteca.Modelos;

namespace Biblioteca.Repositorio
{
	public interface IRepositorioUsuarios
	{
		Task<List<Usuario>> GetAll();
		Task<Usuario?> Get(int id);
		Task<List<TipoDeUsuario>> GetTipoDeUsuarios();
		Task<Usuario> Add(Usuario usuario);
		Task Update (int id,Usuario usuario);
		Task Delete (int id);
	}
}
