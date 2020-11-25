using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaVenda.Repositorio.Interfaces
{
    public interface IRepositorio<TEntidade>
        where TEntidade: class
    {
        void Create(TEntidade entidade);
        TEntidade Read(int id);
        void Delete(int id);
        IEnumerable<TEntidade> Read();
    }
}