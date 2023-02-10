using ProjetoMvcWeb.Models;
using System.Collections.Generic;

namespace ProjetoMvcWeb.Repositories
{
    public interface IContatoRepository
    {
        Contato Adicionar(Contato contato);

        List<Contato> buscarTodos();

    }
}
