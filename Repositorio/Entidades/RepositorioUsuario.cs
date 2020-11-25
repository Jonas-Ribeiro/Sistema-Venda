using Microsoft.EntityFrameworkCore;
using SistemaVenda.Dominio.Entidades;
using SistemaVenda.Dominio.Interfaces;
using SistemaVenda.Dominio.Repositorio;
using SistemaVenda.Repositorio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaVenda.Repositorio.Entidades
{
    public class RepositorioUsuario : Repositorio<Usuario>, IRepositorioUsuario
    {
        public RepositorioUsuario(ApplicationDBContext dbContext) : base(dbContext)
        {

        }

        public bool ValidarLogin(string email, string senha)
        {
            return DbSetContext.Where(x => x.Email == email
            && x.Senha == senha).FirstOrDefault() != null;
        }
    }
}
