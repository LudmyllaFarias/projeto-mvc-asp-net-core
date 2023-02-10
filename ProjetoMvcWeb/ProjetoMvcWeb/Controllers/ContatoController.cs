using Microsoft.AspNetCore.Mvc;
using ProjetoMvcWeb.Models;
using ProjetoMvcWeb.Repositories;
using System.Collections.Generic;

namespace ProjetoMvcWeb.Controllers
{
    public class ContatoController : Controller
    {   
        private readonly IContatoRepository _contatoRepository;
        
        public ContatoController(IContatoRepository contatoRepository) { 
            _contatoRepository = contatoRepository;
        }

        public IActionResult Index()
        {
            List<Contato> contatos = _contatoRepository.buscarTodos();
            return View(contatos);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            Contato contato = _contatoRepository.buscarPorId(id);
            return View(contato);
            // nome diferente View("Editar", contato);
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            Contato contato = _contatoRepository.buscarPorId(id);
            return View(contato);
        }

        [HttpPost]
        public IActionResult Criar(Contato contato)
        {
           try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepository.Adicionar(contato);
                    TempData["MensagemSucesso"] = "Contato cadastro com sucesso!";
                    return RedirectToAction("Index");
                }

                return View(contato);

            }
            catch(System.Exception erro)
            {
                TempData["MensagemErro"] = $"Houve um erro ao cadastrar o contato! detalhe do erro:{erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Editar(Contato contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepository.Atualizar(contato);
                    TempData["MensagemSucesso"] = "Contato atualizado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View(contato);

            }
            catch(System.Exception erro)
            {
                TempData["MensagemErro"] = $"Houve um erro ao atualizar o contato! detalhe do erro:{erro.Message}";
                return RedirectToAction("Index");
            }
        }

        public IActionResult Apagar(int id) {
            try
            {
                bool apagar = _contatoRepository.Apagar(id);
                
                if(apagar)
                {
                    TempData["MensagemSucesso"] = "Contato removido com sucesso!";
                } 
                else
                {
                    TempData["MensagemErro"] = "Houve um erro ao remover o contato!";
                }

                return RedirectToAction("Index");
            }
            catch(System.Exception erro) 
            {
                TempData["MensagemErro"] = $"Houve um erro ao remover o contato! detalhe do erro:{erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
