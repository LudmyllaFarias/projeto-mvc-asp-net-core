using Microsoft.AspNetCore.Mvc;

namespace ProjetoMvcWeb.Controllers
{
    public class ContatoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
