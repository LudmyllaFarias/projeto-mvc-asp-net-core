using ProjetoMvcWeb.Data;
using ProjetoMvcWeb.Models;

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
    }
}
