using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caelum.Blog.PrimeiraAppWeb
{
    internal class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting();
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app)
        {
            //Pipeline de Requisição
            //Use >> Middleware intermediário
            //Run >> Middleware terminal
            //RequestDelegate
            //retorna uma Task e tem como parâmetro um HttpContext
            //app.Run(ctx => {
            //    var sb = new StringBuilder();
            //    var posts = new List<Post>
            //    {
            //        new Post
            //        {
            //            Titulo = "Star Wars VI",
            //            Resumo = "O Retorno de Jedi",
            //            DataPublicacao = new DateTime(2018,10,17)
            //        },
            //        new Post
            //        {
            //            Titulo = "Harry Potter IV",
            //            Resumo = "O Cálice de Fogo",
            //            DataPublicacao = new DateTime(2018, 10, 10)
            //        },
            //        new Post
            //        {
            //            Titulo = "Game of Thrones",
            //            Resumo = "Winter is Coming",
            //            DataPublicacao = new DateTime(2018, 10, 03)
            //        }
            //    };

            //    posts
            //        .OrderBy(p => p.Titulo)
            //        .ToList()
            //        .ForEach(p => sb.AppendLine(p.ToString()));

            //    return ctx.Response.WriteAsync(sb.ToString());
            //});

            //mas só uma rota?
            RouteBuilder routeBuilder = new RouteBuilder(app);
            routeBuilder.MapRoute("/", PaginaInicial);
            routeBuilder.MapRoute("/posts", ListarPosts);
            //outras rotas aqui...

            IRouter rotas = routeBuilder.Build();

            app.UseRouter(rotas);

            app.UseMvcWithDefaultRoute();

        }

        public Task ListarPosts(HttpContext ctx)
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

            return ctx.Response.WriteAsync(sb.ToString());
        }

        public Task PaginaInicial(HttpContext ctx)
        {
            return ctx.Response.WriteAsync(
                @"
                <html>
                    <body>
                    <h1>Resenha Cultural</h1>
                    <p>Bem vindo ao blog!</p>
                    </body>
                </html>
                "
            );
        }
    }

    
}