using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Dados;
using WebApplication1.Extensions;
using WebApplication1.Filtros;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Area("Admin")]
    [AutorizacaoFilter]
    public class PostController : Controller
    {
        private ICRUD<Post> _dao;

        public PostController(ICRUD<Post> dao)
        {
            _dao = dao;
        }

        
        public IActionResult Index()
        {
            

            return View(_dao.Listar());
        }

        public IActionResult Novo()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Adiciona(Post post)
        {
            if (ModelState.IsValid)
            {
                var logado = HttpContext.Session.Get<Usuario>("usuario");
                post.Autor = logado;
                _dao.Incluir(post);
                return RedirectToAction("Index");
            }
            return View("Novo", post);
        }

        public IActionResult Excluir(int id)
        {
            var post = _dao.BuscarPorId(id);
            if (post != null)
            {
                _dao.Excluir(post);
                return RedirectToAction("Index");
            }
            return NotFound();
        }

        public IActionResult CategoriaAutocomplete(string termo)
        {
            var lista = _dao.Listar()
                .Where(p => p.Categoria.Contains(termo))
                .Select(p => p.Categoria)
                .Distinct();
            return Json(lista);
        }

        public IActionResult Publicar(int id)
        {
            var post = _dao.BuscarPorId(id);
            if (post != null)
            {
                post.Publicado = true;
                post.DataPublicacao = System.DateTime.Now;
                _dao.Alterar(post);
                return RedirectToAction("Index");
            }
            return NotFound();
        }
    }
}
