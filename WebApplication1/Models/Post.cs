using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Post
    {
        public int Id { get; set; }

        [StringLength(50, MinimumLength = 5)]
        [Required(ErrorMessage = "Título é obrigatório")]
        public string Titulo { get; set; }

        [StringLength(250)]
        [Required(ErrorMessage = "Resumo é obrigatório")]
        public string Resumo { get; set; }

        public string Categoria { get; set; }

        public DateTime DataPublicacao { get; set; }
        public bool Publicado { get; set; }

        public Usuario Autor { get; set; }
    }
}
