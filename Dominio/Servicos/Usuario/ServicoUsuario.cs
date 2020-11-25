using SistemaVenda.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using SistemaVenda.Dominio.Entidades;
using SistemaVenda.Dominio.Repositorio;

namespace SistemaVenda.Dominio.Servicos
{
    public class ServicoUsuario : IServicoUsuario
    {
        IRepositorioUsuario RepositorioUsuario;

        public ServicoUsuario(IRepositorioUsuario repositorioUsuario)
        {
            RepositorioUsuario = repositorioUsuario;
        }
        public void Cadastrar(Usuario Usuario)
        {
            RepositorioUsuario.Create(Usuario);
        }

        public Usuario CarregarRegistro(int id)
        {
            return RepositorioUsuario.Read(id);
        }

        public void Excluir(int id)
        {
            RepositorioUsuario.Delete(id);
        }

        public IEnumerable<Usuario> Listagem()
        {
            return RepositorioUsuario.Read();
        }

        public bool ValidarLogin(string email, string senha)
        {
            return RepositorioUsuario.ValidarLogin(email, senha);
        }
    }
}
