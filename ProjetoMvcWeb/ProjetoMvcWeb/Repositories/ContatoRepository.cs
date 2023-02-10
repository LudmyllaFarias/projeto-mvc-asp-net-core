using ProjetoMvcWeb.Data;
using ProjetoMvcWeb.Models;
using System;
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

        public Contato buscarPorId(int id)
        {
            return _bancoContext.contatos.FirstOrDefault(c => c.Id == id);
        }

        public Contato Atualizar(Contato contato)
        {
            Contato contatoDb = buscarPorId(contato.Id);
            
            if (contatoDb == null) throw new Exception("Houve um erro na atualização do contato.");
        
            contatoDb.Nome = contato.Nome;
            contatoDb.Email = contato.Email;
            contatoDb.Celular = contato.Celular;
            
            _bancoContext.contatos.Update(contatoDb);

            _bancoContext.SaveChanges();
            return contatoDb;
        }

        public bool Apagar(int id)
        {
            Contato contatoDb = buscarPorId(id);

            if (contatoDb == null) throw new Exception("Houve um erro ao apagar o contato.");

            _bancoContext.contatos.Remove(contatoDb);
            _bancoContext.SaveChanges();
            return true;
        }
    }
}
