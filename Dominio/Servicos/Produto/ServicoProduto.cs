using SistemaVenda.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using SistemaVenda.Dominio.Entidades;
using SistemaVenda.Dominio.Repositorio;

namespace SistemaVenda.Dominio.Servicos
{
    public class ServicoProduto : IServicoProduto
    {
        IRepositorioProduto RepositorioProduto;

        public ServicoProduto(IRepositorioProduto repositorioProduto)
        {
            RepositorioProduto = repositorioProduto;
        }
        public void Cadastrar(Produto Produto)
        {
            RepositorioProduto.Create(Produto);
        }

        public Produto CarregarRegistro(int id)
        {
            return RepositorioProduto.Read(id);
        }

        public void Excluir(int id)
        {
            RepositorioProduto.Delete(id);
        }

        public IEnumerable<Produto> Listagem()
        {
            return RepositorioProduto.Read();            
        }
    }
}
