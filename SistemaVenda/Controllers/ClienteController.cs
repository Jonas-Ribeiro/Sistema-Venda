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
    public class ClienteController : Controller
    {
        protected IServicoAplicacaoCliente ServicoAplicacaoCliente;

        public ClienteController(IServicoAplicacaoCliente servicoAplicacaoCliente)
        {
            ServicoAplicacaoCliente = servicoAplicacaoCliente;
        }
        public IActionResult Index()
        {
            IEnumerable<ClienteViewModel> lista = ServicoAplicacaoCliente.Listagem();
            return View(lista);
        }

        [HttpGet]
        public IActionResult Cadastro(int? id)
        {
            ClienteViewModel viewModel = new ClienteViewModel();

            if(id != null)
            {
            viewModel = ServicoAplicacaoCliente.CarregarRegistro((int)id);
            }

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Cadastro(ClienteViewModel entidade)
        {
            if (ModelState.IsValid)
            {
                ServicoAplicacaoCliente.Cadastrar(entidade);
            }
            else
            {
                return View(entidade);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Excluir(int id)
        {
            ServicoAplicacaoCliente.Excluir(id);

            return RedirectToAction("Index");
        }
    }
}
