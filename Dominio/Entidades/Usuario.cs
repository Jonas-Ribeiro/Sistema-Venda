﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaVenda.Dominio.Entidades
{
    public class Usuario : EntityBase
    {        
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
