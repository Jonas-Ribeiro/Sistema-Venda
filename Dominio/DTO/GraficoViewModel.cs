using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaVenda.Dominio.DTO
{
    public class GraficoViewModel
    {
        public int CodigoProduto { get; set; }
        public string Descricao { get; set; }
        public double TotalVendido { get; set; }
    }
}
