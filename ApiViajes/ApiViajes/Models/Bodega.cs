using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiViajes.Models
{
    public class Bodega
    {
        public int Id_Bodega { get; set; }
        public String NombreBodega { get; set; }
        public int Id_Sucursal { get; set; }
    }
}