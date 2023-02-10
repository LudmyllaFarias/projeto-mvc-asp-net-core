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
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            Contato contato = _contatoRepository.buscarPorId(id);
            return View(contato);
        }

        [HttpPost]
        public IActionResult Criar(Contato contato)
        {
            _contatoRepository.Adicionar(contato);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Editar(Contato contato)
        {
            _contatoRepository.Atualizar(contato);
            return RedirectToAction("Index");
        }

        public IActionResult Apagar(int id) {
            _contatoRepository.Apagar(id);
            return RedirectToAction("Index");
        }
    }
}
