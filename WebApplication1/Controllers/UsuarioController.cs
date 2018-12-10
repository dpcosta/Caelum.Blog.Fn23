using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Dados;
using WebApplication1.Filtros;
using WebApplication1.Models;
using WebApplication1.Extensions;

namespace WebApplication1.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly ICRUD<Usuario> _dao;

        public UsuarioController(ICRUD<Usuario> dao)
        {
            _dao = dao;
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Autentica(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var usuario = _dao.Listar()
                    .FirstOrDefault(u => u.Login == model.LoginName && u.Senha == model.Password);
                if (usuario != null)
                {
                    //guardar usuario na sessão
                    HttpContext
                        .Session
                        .SetString("usuario", JsonConvert.SerializeObject(usuario));
                    return RedirectToAction("Index", "Post", new { area = "Admin" });
                }
                ModelState.AddModelError(
                    "usuario-invalido", 
                    "Usuário ou senha inválidos.");
            }
            return View("Login", model);
        }

        [AutorizacaoFilter]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("usuario");
            return RedirectToAction("Login");
        }

        [AutorizacaoFilter]
        public IActionResult Index()
        {
            return View(_dao.Listar());
        }

        [AutorizacaoFilter]
        public IActionResult Novo()
        {
            return View();
        }

        [AutorizacaoFilter]
        public IActionResult Adiciona(RegistroViewModel model)
        {
            if (ModelState.IsValid)
            {
                var usuario = new Usuario
                {
                    Login = model.Login,
                    Senha = model.Senha
                };
                _dao.Incluir(usuario);
                return RedirectToAction("Index");
            }
            return View("Novo", model);
        }

        [AutorizacaoFilter]
        public IActionResult Excluir(int id)
        {
            var usuario = _dao.BuscarPorId(id);
            if (usuario != null)
            {
                Usuario logado = HttpContext.Session.Get<Usuario>("usuario");
                if (usuario.Id == logado.Id)
                {
                    throw new InvalidOperationException(
                        "Não é possível excluir o usuário logado!"
                    );
                }
                _dao.Excluir(usuario);
                return RedirectToAction("Index");
            }
            return NotFound();
        }
    }
}
