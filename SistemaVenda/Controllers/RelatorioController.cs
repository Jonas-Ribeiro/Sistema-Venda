using Microsoft.AspNetCore.Mvc;
using SistemaVenda.Aplicacao.Servico.Interfaces;
using SistemaVenda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaVenda.Controllers
{
    public class RelatorioController : Controller
    {
        protected IServicoAplicacaoVenda ServicoVenda;

        public RelatorioController(IServicoAplicacaoVenda servicoVenda)
        {
            ServicoVenda = servicoVenda;
        }

        public IActionResult Grafico()
        {
            var lista = ServicoVenda.ListaGrafico().ToList();

            //var lista = (from r in mContext.VendaProdutos
            //             group r by new { r.CodigoProduto, r.Produto.Descricao }
            //       into g
            //             select new GraficoViewModel
            //             {
            //                 CodigoProduto = g.Key.CodigoProduto,
            //                 Descricao = g.Key.Descricao,
            //                 TotalVendido = g.Sum(x => x.Quantidade)
            //             }).ToList();

            Random random = new Random();
            string valores = string.Empty;
            string labels = string.Empty;
            string cores = string.Empty;

            for (int i = 0; i < lista.Count; i++)
            {
                if (i != lista.Count - 1)
                {
                    valores += lista[i].TotalVendido.ToString() + ",";
                    labels += "'" + lista[i].Descricao.ToString() + "',";
                    cores += "'" + string.Format("#{0:X6}", random.Next(0x1000000)) + "',";
                }
                else
                {
                    valores += lista[i].TotalVendido.ToString();
                    labels += "'" + lista[i].Descricao.ToString() + "'";
                    cores += "'" + string.Format("#{0:X6}", random.Next(0x1000000)) + "'";
                }
            }

            ViewBag.valores = valores;
            ViewBag.labels = labels;
            ViewBag.cores = cores;

            return View();
        }
    }
}
