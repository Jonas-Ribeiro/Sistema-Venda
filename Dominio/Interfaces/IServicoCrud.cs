using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaVenda.Dominio.Interfaces
{
    public interface IServicoCrud<TEntidade>
        where TEntidade : class
    {
        IEnumerable<TEntidade> Listagem();
        void Cadastrar(TEntidade entidade);
        TEntidade CarregarRegistro(int id);
        void Excluir(int id);
    }
}
