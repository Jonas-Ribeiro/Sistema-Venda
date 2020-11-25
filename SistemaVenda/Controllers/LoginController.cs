using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaVenda.Aplicacao.Servico.Interfaces;
using SistemaVenda.Helpers;
using SistemaVenda.Models;

namespace SistemaVenda.Controllers
{
    public class LoginController : Controller
    {
        protected IHttpContextAccessor httpContextAccessor;
        readonly IServicoAplicacaoUsuario servicoAplicacaoUsuario;

        public LoginController(IHttpContextAccessor httpContext, IServicoAplicacaoUsuario ServicoAplicacaoUsuario)
        {
            httpContextAccessor = httpContext;
           servicoAplicacaoUsuario = ServicoAplicacaoUsuario;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Index(int? id)
        {
            if(id != null)
            {
                if(id == 0)
                {
                    httpContextAccessor.HttpContext.Session.Clear();
                }
            }
            return View();
        }

        [HttpPost]
        public IActionResult Index(LoginViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                string senha = Criptografia.GetHash(viewModel.Senha);

                bool logou = servicoAplicacaoUsuario.ValidarLogin(viewModel.Email, senha);
                var usuario = servicoAplicacaoUsuario.RetornarDadosUsuario(viewModel.Email, senha);
                
                if (logou)
                {
                    httpContextAccessor.HttpContext.Session.SetString(Sessao.NOME_USUARIO, usuario.Nome);
                    httpContextAccessor.HttpContext.Session.SetString(Sessao.EMAIL_USUARIO, usuario.Email);
                    httpContextAccessor.HttpContext.Session.SetInt32(Sessao.CODIGO_USUARIO,  (int)usuario.Codigo);
                    httpContextAccessor.HttpContext.Session.SetInt32(Sessao.LOGADO, 1);
                    
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewData["ErroLogin"] = "O Email e/ou senha informado está incorreto!";                    
                    return View(viewModel);
                }
            }
            else
            {
                return View(viewModel);
            }
        }
    }
}
