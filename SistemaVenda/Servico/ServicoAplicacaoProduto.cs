using SistemaVenda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaVenda.Dominio.Interfaces;
using SistemaVenda.Dominio.Entidades;
using SistemaVenda.Aplicacao.Servico.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SistemaVenda.Aplicacao.Servico
{
    public class ServicoAplicacaoProduto : IServicoAplicacaoProduto
    {
        private IServicoProduto ServicoProduto;
        public ServicoAplicacaoProduto(IServicoProduto servicoProduto)
        {
            ServicoProduto = servicoProduto;
        }

        public void Cadastrar(ProdutoViewModel ProdutoViewModel)
        {
            Produto Produto = new Produto
            {
                Codigo = ProdutoViewModel.Codigo,
                Descricao = ProdutoViewModel.Descricao,
                Quantidade = ProdutoViewModel.Quantidade,
                Valor = ProdutoViewModel.Valor,
                CodigoCategoria = ProdutoViewModel.CodigoCategoria
            };
            ServicoProduto.Cadastrar(Produto);
        }

        public ProdutoViewModel CarregarRegistro(int codigoProduto)
        {            
            Produto Produto = ServicoProduto.CarregarRegistro(codigoProduto);

            ProdutoViewModel ProdutoViewModel = new ProdutoViewModel
            {
                Codigo = Produto.Codigo,
                Descricao = Produto.Descricao,
                CodigoCategoria = (int)Produto.CodigoCategoria,
                Quantidade = Produto.Quantidade,
                Valor = Produto.Valor,
            };

            return ProdutoViewModel;
        }

        public void Excluir(int id)
        {
            ServicoProduto.Excluir(id);
        }

        public IEnumerable<ProdutoViewModel> Listagem()
        {
            IEnumerable<Produto> lista = ServicoProduto.Listagem();
            List<ProdutoViewModel> listaProduto = new List<ProdutoViewModel>();

            foreach (var item in lista)
            {
                ProdutoViewModel Produto = new ProdutoViewModel
                {
                    Codigo = item.Codigo,
                    Descricao = item.Descricao,
                    CodigoCategoria = (int)item.CodigoCategoria,
                    Quantidade = item.Quantidade,
                    Valor = item.Valor,
                    DescricaoCategoria = item.Categoria.Descricao
                };

                listaProduto.Add(Produto);

            }
                return listaProduto;
        }

        public IEnumerable<SelectListItem> ListarProdutosDropDownList()
        {
            IEnumerable<Produto> lista = ServicoProduto.Listagem();

            List<SelectListItem> retorno = new List<SelectListItem>();

            foreach (var item in lista)
            {
                SelectListItem Produto = new SelectListItem
                {
                    Value = item.Codigo.ToString(),
                    Text = item.Descricao
                };
                retorno.Add(Produto);
            }

            return retorno;
        }
    }
}
