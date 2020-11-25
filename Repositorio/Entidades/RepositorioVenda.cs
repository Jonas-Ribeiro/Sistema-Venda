using Microsoft.EntityFrameworkCore;
using SistemaVenda.Dominio.Entidades;
using SistemaVenda.Dominio.Interfaces;
using SistemaVenda.Dominio.Repositorio;
using SistemaVenda.Repositorio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaVenda.Repositorio.Entidades
{
    public class RepositorioVenda : Repositorio<Venda>, IRepositorioVenda
    {
        public RepositorioVenda(ApplicationDBContext dbContext) : base(dbContext)
        {
        }
        public override void Delete(int id)
        {
            var listaProdutos = DbSetContext.Include(x => x.Produtos)
            .Where(y => y.Codigo == id).AsNoTracking().ToList();

            VendaProdutos vendaProdutos;

            foreach (var item in listaProdutos[0].Produtos)
            {
                vendaProdutos = new VendaProdutos();
                vendaProdutos.CodigoVenda = id;
                vendaProdutos.CodigoProduto = item.CodigoProduto;

                DbSet<VendaProdutos> DbSetAux;
                DbSetAux = Db.Set<VendaProdutos>();
                DbSetAux.Attach(vendaProdutos);
                DbSetAux.Remove(vendaProdutos);
                Db.SaveChanges();
            }

            base.Delete(id);
        }
    }
}

