using SistemaVenda.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaVenda.Dominio.Interfaces
{
    public interface IServicoUsuario : IServicoCrud<Usuario>
    {
        bool ValidarLogin(string email, string senha);
    }
}
