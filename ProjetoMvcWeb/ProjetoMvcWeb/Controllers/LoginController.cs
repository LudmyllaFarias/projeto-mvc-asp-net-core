using Microsoft.AspNetCore.Mvc;
using ProjetoMvcWeb.Models;
using System;

namespace ProjetoMvcWeb.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Entrar(LoginModel loginModel)
        {
            try
            {
                if(ModelState.IsValid) 
                {

                    TempData["MensagemSucesso"] = "Login realizado com sucesso!";
                    return RedirectToAction("Index", "Home");

                }

                return View("Index");
            }

            catch(Exception erro)
            {
                TempData["MensagemErro"] = $"Houve um erro ao realizar o login! detalhe do erro:{erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
