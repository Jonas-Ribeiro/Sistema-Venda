using SistemaVenda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaVenda.Aplicacao.Servico.Interfaces
{
    public interface IServicoAplicacaoVenda
    {
        IEnumerable<VendaViewModel> Listagem();
        VendaViewModel CarregarRegistro(int codigoVenda);
        void Cadastrar(VendaViewModel Venda);
        void Excluir(int id);
        IEnumerable<GraficoViewModel> ListaGrafico();
    }
}
