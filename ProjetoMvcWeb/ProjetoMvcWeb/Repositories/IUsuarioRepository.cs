using ProjetoMvcWeb.Models;
using System.Collections.Generic;

namespace ProjetoMvcWeb.Repositories
{
    public interface IUsuarioRepository
    {
        Usuario Adicionar(Usuario usuario);

        List<Usuario> buscarTodos();

        Usuario buscarPorId(int id);

        Usuario Atualizar(Usuario usuario);

        bool Apagar (int id);
    }
}
