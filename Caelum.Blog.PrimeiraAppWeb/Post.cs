using System;
using System.Collections.Generic;
using System.Text;

namespace Caelum.Blog.PrimeiraAppWeb
{
    public class Post
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Resumo { get; set; }
        public string Autor { get; set; }
        public DateTime DataPublicacao { get; set; }

        public override string ToString()
        {
            return $"{Titulo}: {Resumo} - {DataPublicacao:dd/MM/yyyy}";
        }
    }
}
