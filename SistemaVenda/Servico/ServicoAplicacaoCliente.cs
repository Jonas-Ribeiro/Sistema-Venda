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
    public class ServicoAplicacaoCliente : IServicoAplicacaoCliente
    {
        private IServicoCliente ServicoCliente;
        public ServicoAplicacaoCliente(IServicoCliente servicoCliente)
        {
            ServicoCliente = servicoCliente;
        }

        public void Cadastrar(ClienteViewModel ClienteViewModel)
        {
            Cliente Cliente = new Cliente
            {
                Codigo = ClienteViewModel.Codigo,
                Nome = ClienteViewModel.Nome,
                Celular = ClienteViewModel.Celular,
                Email = ClienteViewModel.Email,
                CNPJ_CPF = ClienteViewModel.CNPJ_CPF
            };
            ServicoCliente.Cadastrar(Cliente);
        }

        public ClienteViewModel CarregarRegistro(int codigoCliente)
        {            
            Cliente Cliente = ServicoCliente.CarregarRegistro(codigoCliente);

            ClienteViewModel ClienteViewModel = new ClienteViewModel
            {
                Codigo = Cliente.Codigo,
                Nome = Cliente.Nome,
                Email = Cliente.Email,
                CNPJ_CPF = Cliente.CNPJ_CPF,
                Celular = Cliente.Celular
            };

            return ClienteViewModel;
        }

        public void Excluir(int id)
        {
            ServicoCliente.Excluir(id);
        }

        public IEnumerable<ClienteViewModel> Listagem()
        {
            IEnumerable<Cliente> lista = ServicoCliente.Listagem();
            List<ClienteViewModel> listaCliente = new List<ClienteViewModel>();

            foreach (var item in lista)
            {
                ClienteViewModel Cliente = new ClienteViewModel
                {
                    Codigo = item.Codigo,
                    Nome = item.Nome,
                    Email = item.Email,
                    CNPJ_CPF = item.CNPJ_CPF,
                    Celular = item.Celular
                };

                listaCliente.Add(Cliente);
            }
                return listaCliente;
        }

        public IEnumerable<SelectListItem> ListarClientesDropDownList()
        {
            IEnumerable<Cliente> lista = ServicoCliente.Listagem();

            List<SelectListItem> retorno = new List<SelectListItem>();

            foreach (var item in lista)
            {
                SelectListItem Cliente = new SelectListItem
                {
                    Value = item.Codigo.ToString(),
                    Text = item.Nome
                };
                retorno.Add(Cliente);
            }

            return retorno;
        }
    }
}
