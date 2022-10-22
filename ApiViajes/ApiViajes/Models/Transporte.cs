using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiViajes.Models
{
    public class Transporte
    {
        public int Id_Transporte { get; set; }
        public String NombreTransporte { get; set; }
        public int Id_Sucursal { get; set; }
    }
}