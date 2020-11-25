using Microsoft.EntityFrameworkCore;
using SistemaVenda.Dominio.DTO;
using SistemaVenda.Dominio.Entidades;
using SistemaVenda.Dominio.Repositorio;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SistemaVenda.Repositorio.Entidades
{
    public class RepositorioVendaProdutos : IRepositorioVendaProdutos
    {
        protected ApplicationDBContext DbSetContext;
        public RepositorioVendaProdutos(ApplicationDBContext mContext)
        {
            DbSetContext = mContext;
        }
        public IEnumerable<GraficoViewModel> ListaGrafico()
        {
            var lista = (from r in DbSetContext.VendaProdutos
                         group r by new { r.CodigoProduto, r.Produto.Descricao }
                   into g
                         select new GraficoViewModel
                         {
                             CodigoProduto = g.Key.CodigoProduto,
                             Descricao = g.Key.Descricao,
                             TotalVendido = g.Sum(x => x.Quantidade)
                         }).ToList();

            return lista;
            //Random random = new Random();
            //string valores = string.Empty;
            //string labels = string.Empty;
            //string cores = string.Empty;

            //for (int i = 0; i < lista.Count; i++)
            //{
            //    if (i != lista.Count - 1)
            //    {
            //        valores += lista[i].TotalVendido.ToString() + ",";
            //        labels += "'" + lista[i].Descricao.ToString() + "',";
            //        cores += "'" + string.Format("#{0:X6}", random.Next(0x1000000)) + "',";
            //    }
            //    else
            //    {
            //        valores += lista[i].TotalVendido.ToString();
            //        labels += "'" + lista[i].Descricao.ToString() + "'";
            //        cores += "'" + string.Format("#{0:X6}", random.Next(0x1000000)) + "'";
            //    }
            //}

            //ViewBag.valores = valores;
            //ViewBag.labels = labels;
            //ViewBag.cores = cores;

        }
    }
}
