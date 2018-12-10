using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Caelum.Blog.PrimeiraApp
{
    //http://localhost:5000/Post/Listar
    public class PostController : Controller
    {
        public string AloMundo()
        {
            return "Alo mundo";
        }

        [Route("posts-publicados")]
        public string Index()
        {
            var posts = new List<Post>
            {
                new Post
                {
                    Titulo = "Harry Potter III",
                    Resumo = "O prisioneiro de Askaban",
                    Categoria = "Filmes"
                },
                new Post
                {
                    Titulo = "Harry Potter I",
                    Resumo = "E a pedra filosofal",
                    Categoria = "Filmes"
                },
                new Post
                {
                    Titulo = "Harry Potter II",
                    Resumo = "A câmara secreta",
                    Categoria = "Filmes"
                },
                new Post
                {
                    Titulo = "Game of Thrones",
                    Resumo = "Winter is Coming",
                    Categoria = "Serie"
                }
            };

            var listaPosts = new StringBuilder();

            posts
                .OrderBy(p => p.Titulo)
                .ToList()
                .ForEach(p => listaPosts.AppendLine(p.ToString()));

            return listaPosts.ToString();
        }
    }
}
