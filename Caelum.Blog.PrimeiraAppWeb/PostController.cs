using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Caelum.Blog.PrimeiraAppWeb
{
    public class PostController: Controller
    {
        public string ListarPosts()
        {
            var sb = new StringBuilder();
            var posts = new List<Post>
                {
                    new Post
                    {
                        Titulo = "Star Wars VI",
                        Resumo = "O Retorno de Jedi",
                        DataPublicacao = new DateTime(2018,10,17)
                    },
                    new Post
                    {
                        Titulo = "Harry Potter IV",
                        Resumo = "O Cálice de Fogo",
                        DataPublicacao = new DateTime(2018, 10, 10)
                    },
                    new Post
                    {
                        Titulo = "Game of Thrones",
                        Resumo = "Winter is Coming",
                        DataPublicacao = new DateTime(2018, 10, 03)
                    }
                };

            posts
                .OrderBy(p => p.Titulo)
                .ToList()
                .ForEach(p => sb.AppendLine(p.ToString()));

            return sb.ToString();
        }
    }
}
