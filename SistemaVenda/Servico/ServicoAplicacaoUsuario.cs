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
    public class ServicoAplicacaoUsuario : IServicoAplicacaoUsuario
    {
        private IServicoUsuario ServicoUsuario;
        public ServicoAplicacaoUsuario(IServicoUsuario servicoUsuario)
        {
            ServicoUsuario = servicoUsuario;
        }

        public void Cadastrar(UsuarioViewModel Usuario)
        {
            throw new NotImplementedException();
        }

        public UsuarioViewModel CarregarRegistro(int codigoUsuario)
        {
            throw new NotImplementedException();
        }

        public void Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UsuarioViewModel> Listagem()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SelectListItem> ListarUsuariosDropDownList()
        {
            throw new NotImplementedException();
        }

        public Usuario RetornarDadosUsuario(string email, string senha)
        {
            return ServicoUsuario.Listagem().Where(x => x.Email == email
            && x.Senha.ToUpper() == senha.ToUpper()).FirstOrDefault();
        }

        public bool ValidarLogin(string email, string senha)
        {
            return ServicoUsuario.ValidarLogin(email, senha);
        }

        //public void Cadastrar(UsuarioViewModel UsuarioViewModel)
        //{
        //    Usuario Usuario = new Usuario
        //    {
        //        Codigo = UsuarioViewModel.Codigo,
        //        Descricao = UsuarioViewModel.Descricao
        //    };
        //    ServicoUsuario.Cadastrar(Usuario);
        //}

        //public UsuarioViewModel CarregarRegistro(int codigoUsuario)
        //{            
        //    Usuario Usuario = ServicoUsuario.CarregarRegistro(codigoUsuario);

        //    UsuarioViewModel UsuarioViewModel = new UsuarioViewModel
        //    {
        //        Codigo = Usuario.Codigo,
        //        Descricao = Usuario.Descricao
        //    };

        //    return UsuarioViewModel;
        //}

        //public void Excluir(int id)
        //{
        //    ServicoUsuario.Excluir(id);
        //}

        //public IEnumerable<UsuarioViewModel> Listagem()
        //{
        //    IEnumerable<Usuario> lista = ServicoUsuario.Listagem();
        //    List<UsuarioViewModel> listaUsuario = new List<UsuarioViewModel>();

        //    foreach (var item in lista)
        //    {
        //        UsuarioViewModel Usuario = new UsuarioViewModel
        //        {
        //            Codigo = item.Codigo,
        //            Descricao = item.Descricao
        //        };

        //        listaUsuario.Add(Usuario);

        //    }
        //        return listaUsuario;
        //}

        //public IEnumerable<SelectListItem> ListarUsuariosDropDownList()
        //{
        //    IEnumerable<Usuario> lista = ServicoUsuario.Listagem();

        //    List<SelectListItem> retorno = new List<SelectListItem>();

        //    foreach (var item in lista)
        //    {
        //        SelectListItem Usuario = new SelectListItem
        //        {
        //            Value = item.Codigo.ToString(),
        //            Text = item.Descricao
        //        };
        //        retorno.Add(Usuario);
        //    }

        //    return retorno;
        //}

    }
}
