using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiViajes.Models
{
    public class TipoCliente
    {
        public int Id_TipoCliente { get; set; }
        public String NombreTipoCliente { get; set; }
        public int CantidadMaxPaquetes { get; set; }


    }
}