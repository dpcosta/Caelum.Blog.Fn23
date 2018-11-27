using Caelum.Fn23.Curso.DAO;
using Caelum.Fn23.Curso.Models;
using Caelum.Fn23.Curso.ViewModels;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Caelum.Fn23.Curso.Controllers
{
    public class AgrupamentosController : Controller
    {

        private IDataAccessObject<Post> _dao;
        public IDataAccessObject<Post> Dao
        {
            get
            {
                if (_dao == null)
                {
                    _dao = HttpContext.GetOwinContext().Get<IDataAccessObject<Post>>();
                }
                return _dao;
            }
        }

        [ChildActionOnly]
        public ActionResult CategoriaTotal()
        {
            //recupera a lista de categorias, com o total de posts publicados em cada uma
            var model = Dao.Lista
                .Where(p => p.Publicado)
                .GroupBy(p => p.Categoria)
                .Select(g => new CategoriaTotalViewModel { Nome = g.Key, Total = g.Count() })
                .ToList();
            //var model = new List<CategoriaTotalViewModel>();
            return PartialView(model);
        }

        [ChildActionOnly]
        public ActionResult AutoresTotal()
        {
            var model = Dao.Lista
                .Where(p => p.Publicado)
                .GroupBy(p => p.Autor.UserName)
                .Select(g => new AutorTotalViewModel { Autor = g.Key, Total = g.Count() })
                .ToList();
            return PartialView(model);
        }
    }
}