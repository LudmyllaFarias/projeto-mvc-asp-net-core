using Microsoft.AspNetCore.Mvc;
using ProjetoMvcWeb.Models;
using ProjetoMvcWeb.Repositories;

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
            return View();
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar()
        {
            return View();
        }

        public IActionResult ApagarConfirmacao()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(Contato contato)
        {
            _contatoRepository.Adicionar(contato);
            return RedirectToAction("Index");
        }
    }
}
