using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiViajes.Models
{
    public class Tarifa
    {
        public int Id_Tarifa { get; set; }
        public int Id_TipoCliente { get; set; }
        public int Id_Transporte { get; set; }
        public String NombreTarifa { get; set; }
        public float costoCiudad { get; set; }
        public float costoMunicipio { get; set; }
        public float costoInteriorPais { get; set; }
    }
}