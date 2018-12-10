using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Dados
{
    public interface ICRUD<T>
    {
        IEnumerable<T> Listar();
        void Incluir(T objeto);
        void Alterar(T objeto);
        void Excluir(T objeto);
        T BuscarPorId(int id);
    }
}
