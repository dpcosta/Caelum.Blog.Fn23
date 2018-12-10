using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebApplication1.Dados;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICRUD<Post> _dao;

        public HomeController(ICRUD<Post> dao)
        {
            _dao = dao;
        }

        public IActionResult Index()
        {
            var publicados = _dao.Listar()
                .Where(p => p.Publicado)
                .OrderByDescending(p => p.DataPublicacao);
            return View(publicados);
        }
    }
}
