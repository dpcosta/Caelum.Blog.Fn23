using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Dados
{
    public class PostDAO : ICRUD<Post>
    {
        private IDbConnection _cnx;

        public PostDAO(IDbConnection cnx)
        {
            _cnx = cnx;
        }

        public IEnumerable<Post> Listar()
        {
            var lista = new List<Post>();
            try
            {
                _cnx.Open();
                var cmd = _cnx.CreateCommand();
                cmd.CommandText = "select * from posts";
                using (var leitor = cmd.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        var post = new Post
                        {
                            Id = Convert.ToInt32(leitor["id"]),
                            Titulo = Convert.ToString(leitor["Titulo"]),
                            Resumo = Convert.ToString(leitor["resumo"]),
                            Categoria = Convert.ToString(leitor["categoria"])
                        };
                        lista.Add(post);
                    }
                }
            }
            finally
            {
                _cnx.Close();
            }
            return lista;
        }

        public void Incluir(Post post)
        {
            using (_cnx)
            using(var cmd = _cnx.CreateCommand())
            {
                cmd.CommandText =
                        @"
                        insert into posts (titulo, resumo, categoria)
                        values (@titulo, @resumo, @categoria)
                    ";
                AdicionarParametro(cmd, "titulo", post.Titulo);
                AdicionarParametro(cmd, "resumo", post.Resumo);
                AdicionarParametro(cmd, "categoria", post.Categoria);

                cmd.ExecuteNonQuery();
            }
        }

        public void Alterar(Post post)
        {
            try
            {
                _cnx.Open();
                var cmd = _cnx.CreateCommand();
                cmd.CommandText =
                    @"
                        update posts set 
                            titulo = @titulo, 
                            resumo = @resumo, 
                            categoria = @categoria
                        where id = @id
                    ";
                AdicionarParametro(cmd, "id", post.Id);
                AdicionarParametro(cmd, "titulo", post.Titulo);
                AdicionarParametro(cmd, "resumo", post.Resumo);
                AdicionarParametro(cmd, "categoria", post.Categoria);

                cmd.ExecuteNonQuery();

            }
            finally
            {
                _cnx.Close();
            }
        }

        public void Excluir(Post post)
        {
            try
            {
                _cnx.Open();
                var cmd = _cnx.CreateCommand();
                cmd.CommandText =
                    @"
                        delete from posts where id = @id
                    ";
                AdicionarParametro(cmd, "id", post.Id);

                cmd.ExecuteNonQuery();

            }
            finally
            {
                _cnx.Close();
            }
        }

        public Post BuscarPorId(int id)
        {
            var lista = Listar();
            return lista.FirstOrDefault(p => p.Id == id);
        }

        private void AdicionarParametro(
            IDbCommand cmd, 
            string paramName, 
            object paramValue)
        {
            var param = cmd.CreateParameter();
            param.ParameterName = paramName;
            param.Value = paramValue;
            cmd.Parameters.Add(param);
        }
    }
}
