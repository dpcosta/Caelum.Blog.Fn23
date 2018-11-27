using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Caelum.Blog.PrimeiraAppWeb
{

    class Program
    {
        static void Main(string[] args)
        {
            
            IWebHost host = new WebHostBuilder()
                //registrar a configuração mínima do servidor
                .UseStartup<Startup>()
                //registrar um objeto que implementa IServer
                .UseKestrel()
                .Build();

            host.Run();

        }
    }
}
