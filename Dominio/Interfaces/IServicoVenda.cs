using SistemaVenda.Dominio.DTO;
using SistemaVenda.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaVenda.Dominio.Interfaces
{
    public interface IServicoVenda : IServicoCrud<Venda>
    {
        IEnumerable<GraficoViewModel> ListaGrafico();
    }
}
