using ProjetoMvcWeb.Data;
using ProjetoMvcWeb.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoMvcWeb.Repositories
{
    public class ContatoRepository : IContatoRepository
    {
        private readonly BancoContext _bancoContext;
        public ContatoRepository(BancoContext context) 
        {
            _bancoContext = context;
        }
        public Contato Adicionar(Contato contato)
        {
            _bancoContext.contatos.Add(contato);
            _bancoContext.SaveChanges();
            return contato;
            
        }

        public List<Contato> buscarTodos()
        {
            return _bancoContext.contatos.ToList();
        }
    }
}
