using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaVenda.Dominio.Entidades;
using SistemaVenda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaVenda.Aplicacao.Servico.Interfaces
{
    public interface IServicoAplicacaoUsuario
    {
        IEnumerable<UsuarioViewModel> Listagem();
        IEnumerable<SelectListItem> ListarUsuariosDropDownList();

        UsuarioViewModel CarregarRegistro(int codigoUsuario);
        void Cadastrar(UsuarioViewModel Usuario);
        void Excluir(int id);

        bool ValidarLogin(string email, string senha);

        Usuario RetornarDadosUsuario(string email, string senha);
    }
}
