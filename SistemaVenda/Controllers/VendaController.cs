using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SistemaVenda.Models;
using Microsoft.EntityFrameworkCore;
using SistemaVenda.Aplicacao.Servico.Interfaces;

namespace SistemaVenda.Controllers
{
    public class VendaController : Controller
    {
        protected IServicoAplicacaoVenda ServicoAplicacaoVenda;
        protected IServicoAplicacaoProduto ServicoAplicacaoProduto;
        protected IServicoAplicacaoCliente ServicoAplicacaoCliente;

        public VendaController(IServicoAplicacaoVenda servicoAplicacaoVenda
            , IServicoAplicacaoProduto servicoAplicacaoProduto
            , IServicoAplicacaoCliente servicoAplicacaoCliente)
        {
            ServicoAplicacaoVenda = servicoAplicacaoVenda;
            ServicoAplicacaoProduto = servicoAplicacaoProduto;
            ServicoAplicacaoCliente = servicoAplicacaoCliente;
        }

        public IActionResult Index()
        {
            IEnumerable<VendaViewModel> lista = ServicoAplicacaoVenda.Listagem();
            return View(lista);
        }

        [HttpGet]
        public IActionResult Cadastro(int? id)
        {
            VendaViewModel viewModel = new VendaViewModel();

            if(id != null)
            {
            viewModel = ServicoAplicacaoVenda.CarregarRegistro((int)id);
            }
            viewModel.ListaClientes = ServicoAplicacaoCliente.ListarClientesDropDownList();
            viewModel.ListaProdutos = ServicoAplicacaoProduto.ListarProdutosDropDownList();

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Cadastro(VendaViewModel entidade)
        {
            if (ModelState.IsValid)
            {
                ServicoAplicacaoVenda.Cadastrar(entidade);
            }
            else
            {
                entidade.ListaClientes = ServicoAplicacaoCliente.ListarClientesDropDownList();
                entidade.ListaProdutos= ServicoAplicacaoProduto.ListarProdutosDropDownList();

                return View(entidade);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Excluir(int id)
        {
            ServicoAplicacaoVenda.Excluir(id);

            return RedirectToAction("Index");
        }

        [HttpGet("LerValorProduto/{CodigoProduto}")]
        public decimal LerValorProduto(int CodigoProduto) 
        {
            return (decimal)ServicoAplicacaoProduto.CarregarRegistro(CodigoProduto).Valor;
        }
    }
}
