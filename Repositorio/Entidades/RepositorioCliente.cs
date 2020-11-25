using Microsoft.EntityFrameworkCore;
using SistemaVenda.Dominio.Entidades;
using SistemaVenda.Dominio.Interfaces;
using SistemaVenda.Dominio.Repositorio;
using SistemaVenda.Repositorio.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaVenda.Repositorio.Entidades
{
    public class RepositorioCliente : Repositorio<Cliente>, IRepositorioCliente
    {
        public RepositorioCliente(ApplicationDBContext dbContext) : base(dbContext)
        {

        }
    }
}
