using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SistemaVenda.DAL;
using SistemaVenda.Entidades;
using SistemaVenda.Models;
using Microsoft.EntityFrameworkCore;

namespace SistemaVenda.Controllers
{
    public class CategoriaController : Controller
    {
        protected ApplicationDBContext mContext;

        public CategoriaController(ApplicationDBContext context)
        {
            mContext = context;
        }
        public IActionResult Index()
        {
            IEnumerable<Categoria> lista = mContext.Categoria.ToList();
            mContext.Dispose();

            return View(lista);
        }

        [HttpGet]
        public IActionResult Cadastro(int? id)
        {
            CategoriaViewModel viewModel = new CategoriaViewModel();

            if (id != null)
            {
                Categoria entidade = mContext.Categoria.Where(x => x.Codigo == id.Value).FirstOrDefault();
                viewModel.Codigo = entidade.Codigo;
                viewModel.Descricao = entidade.Descricao;
            }

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Cadastro(CategoriaViewModel entidade)
        {
            if (ModelState.IsValid)
            {
                Categoria objCategoria = new Categoria
                {
                    Codigo = entidade.Codigo,
                    Descricao = entidade.Descricao
                };

                if (entidade.Codigo == null)
                {
                    mContext.Categoria.Add(objCategoria);
                }
                else
                {
                    mContext.Entry(objCategoria).State = EntityState.Modified;
                }

                mContext.SaveChanges();
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
            CategoriaViewModel viewModel = new CategoriaViewModel();

            Categoria ent = new Categoria()
            {
                Codigo = id
            };

            mContext.Categoria.Attach(ent);
            mContext.Categoria.Remove(ent);
            mContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
