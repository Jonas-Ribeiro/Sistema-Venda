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
    public class ServicoAplicacaoCategoria : IServicoAplicacaoCategoria
    {
        private IServicoCategoria ServicoCategoria;
        public ServicoAplicacaoCategoria(IServicoCategoria servicoCategoria)
        {
            ServicoCategoria = servicoCategoria;
        }

        public void Cadastrar(CategoriaViewModel categoriaViewModel)
        {
            Categoria categoria = new Categoria
            {
                Codigo = categoriaViewModel.Codigo,
                Descricao = categoriaViewModel.Descricao
            };
            ServicoCategoria.Cadastrar(categoria);
        }

        public CategoriaViewModel CarregarRegistro(int codigoCategoria)
        {            
            Categoria categoria = ServicoCategoria.CarregarRegistro(codigoCategoria);

            CategoriaViewModel categoriaViewModel = new CategoriaViewModel
            {
                Codigo = categoria.Codigo,
                Descricao = categoria.Descricao
            };

            return categoriaViewModel;
        }

        public void Excluir(int id)
        {
            ServicoCategoria.Excluir(id);
        }

        public IEnumerable<CategoriaViewModel> Listagem()
        {
            IEnumerable<Categoria> lista = ServicoCategoria.Listagem();
            List<CategoriaViewModel> listaCategoria = new List<CategoriaViewModel>();

            foreach (var item in lista)
            {
                CategoriaViewModel categoria = new CategoriaViewModel
                {
                    Codigo = item.Codigo,
                    Descricao = item.Descricao
                };

                listaCategoria.Add(categoria);

            }
                return listaCategoria;
        }

        public IEnumerable<SelectListItem> ListarCategoriasDropDownList()
        {
            IEnumerable<Categoria> lista = ServicoCategoria.Listagem();

            List<SelectListItem> retorno = new List<SelectListItem>();

            foreach (var item in lista)
            {
                SelectListItem categoria = new SelectListItem
                {
                    Value = item.Codigo.ToString(),
                    Text = item.Descricao
                };
                retorno.Add(categoria);
            }

            return retorno;
        }
    }
}
