using SistemaVenda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaVenda.Dominio.Interfaces;
using SistemaVenda.Dominio.Entidades;
using SistemaVenda.Aplicacao.Servico.Interfaces;
using Newtonsoft.Json;

namespace SistemaVenda.Aplicacao.Servico
{
    public class ServicoAplicacaoVenda : IServicoAplicacaoVenda
    {
        private IServicoVenda ServicoVenda;

        public ServicoAplicacaoVenda(IServicoVenda servicoVenda)
        {
            ServicoVenda = servicoVenda;
        }

        public void Cadastrar(VendaViewModel VendaViewModel)
        {
            Venda Venda = new Venda
            {
                CodigoCliente = VendaViewModel.CodigoCliente,
                Data = VendaViewModel.Data,
                Total = VendaViewModel.Total,
                Produtos = JsonConvert.DeserializeObject<ICollection<VendaProdutos>>(VendaViewModel.JsonProdutos)
            };
            ServicoVenda.Cadastrar(Venda);
        }

        public VendaViewModel CarregarRegistro(int codigoVenda)
        {            
            Venda Venda = ServicoVenda.CarregarRegistro(codigoVenda);

            VendaViewModel VendaViewModel = new VendaViewModel
            {
                Codigo = Venda.Codigo,
                CodigoCliente = Venda.CodigoCliente,
                Data = Venda.Data,
                Total = Venda.Total
            };

            return VendaViewModel;
        }

        public void Excluir(int id)
        {
            ServicoVenda.Excluir(id);
        }

        public IEnumerable<VendaViewModel> Listagem()
        {
            IEnumerable<Venda> lista = ServicoVenda.Listagem();
            List<VendaViewModel> listaVenda = new List<VendaViewModel>();

            foreach (var item in lista)
            {
                VendaViewModel Venda = new VendaViewModel
                {
                    Codigo = item.Codigo,
                    Data = item.Data,
                    CodigoCliente = item.CodigoCliente,
                    Total = item.Total,
                };

                listaVenda.Add(Venda);
            }
                return listaVenda;
        }

        public IEnumerable<GraficoViewModel> ListaGrafico()
        {
            List<GraficoViewModel> lista = new List<GraficoViewModel>();
            var auxLista = ServicoVenda.ListaGrafico();

            foreach (var item in auxLista)
            {
                GraficoViewModel grafico = new GraficoViewModel
                {
                    CodigoProduto = item.CodigoProduto,
                    Descricao = item.Descricao,
                    TotalVendido = item.TotalVendido
                };

                lista.Add(grafico);
            }
            return lista;
        }
    }
}
