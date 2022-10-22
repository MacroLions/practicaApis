using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiViajes.Models
{
    public class InformePaquete
    {
        public int Id_InformePaquete { get; set; }
        public String CodigoPaquete { get; set; }
        public int Id_Cliente { get; set; }
        public int Id_Transporte { get; set; }
        public DateTime FechaEnvio { get; set; }
        public DateTime FechaRecibo { get; set; }
        public int Id_SucursalOrigen { get; set; }
        public int Id_SucursalDestino { get; set; }
        public int Id_StatusPaquete { get; set; }
    }
}