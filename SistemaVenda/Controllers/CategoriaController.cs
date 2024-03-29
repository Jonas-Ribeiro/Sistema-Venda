﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SistemaVenda.Models;
using Microsoft.EntityFrameworkCore;
using SistemaVenda.Aplicacao.Servico.Interfaces;

namespace SistemaVenda.Controllers
{
    public class CategoriaController : Controller
    {
        protected IServicoAplicacaoCategoria ServicoAplicacaoCategoria;

        public CategoriaController(IServicoAplicacaoCategoria servicoAplicacaoCategoria)
        {
            ServicoAplicacaoCategoria = servicoAplicacaoCategoria;
        }
        public IActionResult Index()
        {
            IEnumerable<CategoriaViewModel> lista = ServicoAplicacaoCategoria.Listagem();
            return View(lista);
        }

        [HttpGet]
        public IActionResult Cadastro(int? id)
        {
            CategoriaViewModel viewModel = new CategoriaViewModel();

            if(id != null)
            {
            viewModel = ServicoAplicacaoCategoria.CarregarRegistro((int)id);
            }

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Cadastro(CategoriaViewModel entidade)
        {
            if (ModelState.IsValid)
            {
                ServicoAplicacaoCategoria.Cadastrar(entidade);
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
            ServicoAplicacaoCategoria.Excluir(id);

            return RedirectToAction("Index");
        }
    }
}
