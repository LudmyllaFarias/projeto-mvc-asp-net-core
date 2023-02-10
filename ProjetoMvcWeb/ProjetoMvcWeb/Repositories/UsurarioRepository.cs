using ProjetoMvcWeb.Data;
using ProjetoMvcWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoMvcWeb.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly BancoContext _bancoContext;
        
        public UsuarioRepository(BancoContext context) 
        {
            _bancoContext = context;
        }

        public Usuario Adicionar(Usuario usuario)
        {
            usuario.DataCadastro = DateTime.Now;
            _bancoContext.usuarios.Add(usuario);
            _bancoContext.SaveChanges();
            return usuario;
            
        }

        public List<Usuario> buscarTodos()
        {
            return _bancoContext.usuarios.ToList();
        }

        public Usuario buscarPorId(int id)
        {
            return _bancoContext.usuarios.FirstOrDefault(c => c.Id == id);
        }

        public Usuario Atualizar(Usuario usuario)
        {
            Usuario usuarioDb = buscarPorId(usuario.Id);
            
            if (usuarioDb == null) throw new Exception("Houve um erro na atualização do usuário.");

            usuarioDb.Nome = usuario.Nome;
            usuarioDb.Login = usuario.Login;
            usuarioDb.Email = usuario.Email;
            usuarioDb.Perfil = usuario.Perfil;
            usuarioDb.DataAlteracao = DateTime.Now;

            _bancoContext.usuarios.Update(usuarioDb);

            _bancoContext.SaveChanges();
            return usuarioDb;
        }

        public bool Apagar(int id)
        {
            Usuario usuarioDb = buscarPorId(id);

            if (usuarioDb == null) throw new Exception("Houve um erro ao apagar o usuário.");

            _bancoContext.usuarios.Remove(usuarioDb);
            _bancoContext.SaveChanges();
            return true;
        }
    }
}
