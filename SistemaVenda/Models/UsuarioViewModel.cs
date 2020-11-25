using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaVenda.Models
{
    public class UsuarioViewModel
    {
        public int? Codigo { get; set; }
        
        [Required(ErrorMessage = "Informe a descrição da Usuario")]
        public string Email { get; set; }
        public string  Senha { get; set; }
    }
}
