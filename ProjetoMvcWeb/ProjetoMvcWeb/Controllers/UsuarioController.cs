using Microsoft.AspNetCore.Mvc;
using ProjetoMvcWeb.Models;
using ProjetoMvcWeb.Repositories;
using System.Collections.Generic;

namespace ProjetoMvcWeb.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository) { 
            _usuarioRepository = usuarioRepository;
        }

        public IActionResult Index()
        {
            List<Usuario> usuarios = _usuarioRepository.buscarTodos();
            return View(usuarios);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            Usuario usuario = _usuarioRepository.buscarPorId(id);
            return View(usuario);
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            Usuario usuario = _usuarioRepository.buscarPorId(id);
            return View(usuario);
        }

        [HttpPost]
        public IActionResult Criar(Usuario usuario)
        {
           try
            {
                if (ModelState.IsValid)
                {
                    _usuarioRepository.Adicionar(usuario);
                    TempData["MensagemSucesso"] = "Usuário cadastro com sucesso!";
                    return RedirectToAction("Index");
                }

                return View(usuario);

            }
            catch(System.Exception erro)
            {
                TempData["MensagemErro"] = $"Houve um erro ao cadastrar o usuário! detalhe do erro:{erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Editar(Usuario usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _usuarioRepository.Atualizar(usuario);
                    TempData["MensagemSucesso"] = "Usuário atualizado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View(usuario);

            }
            catch(System.Exception erro)
            {
                TempData["MensagemErro"] = $"Houve um erro ao atualizar o usuário! detalhe do erro:{erro.Message}";
                return RedirectToAction("Index");
            }
        }

        public IActionResult Apagar(int id) {
            try
            {
                bool apagar = _usuarioRepository.Apagar(id);
                
                if(apagar)
                {
                    TempData["MensagemSucesso"] = "Usuário removido com sucesso!";
                } 
                else
                {
                    TempData["MensagemErro"] = "Houve um erro ao remover o usuário!";
                }

                return RedirectToAction("Index");
            }
            catch(System.Exception erro) 
            {
                TempData["MensagemErro"] = $"Houve um erro ao remover o usuário! detalhe do erro:{erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
