using ApiViajes.Data;
using ApiViajes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiViajes.Controllers
{
    public class TransporteController : ApiController
    {
        // GET para Select(Un elemento)
        public Transporte Get(int id)
        {
            return TransporteData.Select(id);
        }

        // GET para Select(Varios elementos)
        public List<Transporte> Get()
        {
            return TransporteData.SelectAll();
        }


        // POST para Save
        public bool Post([FromBody]Transporte oTransporte)
        {
            return TransporteData.Save(oTransporte);
        }

        // PUT api/<controller>/5
        public bool Put([FromBody]Transporte oTransporte)
        {
            return TransporteData.Edit(oTransporte);
        }

        // DELETE api/<controller>/5
        public bool Delete(int id)
        {
            return TransporteData.Delete(id);
        }
    }
}