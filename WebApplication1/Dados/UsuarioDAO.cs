using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Dados
{
    public class UsuarioDAO : ICRUD<Usuario>
    {
        private readonly BlogContext _context;

        public UsuarioDAO(BlogContext context)
        {
            _context = context;
        }

        public IEnumerable<Usuario> Listar()
        {
            return _context.Usuarios;
        }

        public void Incluir(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
        }

        public void Alterar(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
            _context.SaveChanges();
        }

        public void Excluir(Usuario usuario)
        {
            _context.Usuarios.Remove(usuario);
            _context.SaveChanges();
        }

        public Usuario BuscarPorId(int id)
        {
            return _context.Usuarios.Find(id);
        }
    }
}
