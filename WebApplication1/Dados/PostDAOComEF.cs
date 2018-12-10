using System.Collections.Generic;
using WebApplication1.Models;

namespace WebApplication1.Dados
{
    public class PostDAOComEF : ICRUD<Post>
    {
        private readonly BlogContext _context;

        public PostDAOComEF(BlogContext context)
        {
            _context = context;
        }

        public IEnumerable<Post> Listar()
        {
            return _context.Posts;
        }

        public void Alterar(Post objeto)
        {
            _context.Update(objeto);
            _context.SaveChanges();
        }

        public Post BuscarPorId(int id)
        {
            return _context.Posts.Find(id);
        }

        public void Excluir(Post objeto)
        {
            _context.Posts.Remove(objeto);
            _context.SaveChanges();
        }

        public void Incluir(Post objeto)
        {
            if (objeto.Autor != null)
            {
                _context.Usuarios.Attach(objeto.Autor);
            }
            _context.Posts.Add(objeto);
            _context.SaveChanges();
        }
    }
}
