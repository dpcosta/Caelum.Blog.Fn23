using System;
using System.Collections.Generic;
using System.Text;

namespace Caelum.Blog.PrimeiraApp
{
    public class Post
    {
        public string Titulo { get; set; }
        public string Resumo { get; set; }
        public string Categoria { get; set; }

        public override string ToString()
        {
            return $"{Titulo}: {Resumo} - {Categoria}";
        }
    }
}
