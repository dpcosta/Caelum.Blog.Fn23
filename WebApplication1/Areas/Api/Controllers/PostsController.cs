using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Dados;

namespace WebApplication1.Areas.Api.Controllers
{
    [Area("Api")]
    [ApiController]
    [Route("[area]/[controller]")]
    public class PostsController : ControllerBase
    {
        private readonly ICRUD<Post> _dao;

        public PostsController(ICRUD<Post> crud)
        {
            _dao = crud;
        }

        [HttpGet]
        public IActionResult ListarPosts()
        {
            var lista = _dao.Listar();
            return Ok(lista);
        }

        [HttpGet("{id}")]
        public IActionResult UnicoPost(int id)
        {
            var post = _dao.BuscarPorId(id);
            if (post !=null)
            {
                return Ok(post);
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var post = _dao.BuscarPorId(id);
            if (post != null)
            {
                _dao.Excluir(post);
                return NoContent();
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult IncluirPost(Post post)
        {
            _dao.Incluir(post);
            return Ok(post);
        }

        [HttpPut]
        public IActionResult Alterar(Post post)
        {
            _dao.Alterar(post);
            return Ok(post);
        }
    }
}
