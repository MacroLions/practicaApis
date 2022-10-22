using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiViajes.Models
{
    public class Cliente
    {
        public int Id_Cliente { get; set; }
        public int Id_TipoCliente { get; set; }
        public String NombreCliente { get; set; }
        public String ApellidoCliente { get; set; }
    }
}