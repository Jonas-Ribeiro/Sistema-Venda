﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaVenda.Dominio.Entidades
{
    public class Categoria : EntityBase
    {
        public string Descricao { get; set; }
        public ICollection<Produto> Produtos { get; set; }
    }
}
