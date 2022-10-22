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
    public class TarifaController : ApiController
    {
        // GET para Select(Un elemento)
        public Tarifa Get(int id)
        {
            return TarifaData.Select(id);
        }

        // GET para Select(Varios elementos)
        public List<Tarifa> Get()
        {
            return TarifaData.SelectAll();
        }


        // POST para Save
        public bool Post([FromBody]Tarifa oTarifa)
        {
            return TarifaData.Save(oTarifa);
        }

        // PUT api/<controller>/5
        public bool Put([FromBody]Tarifa oTarifa)
        {
            return TarifaData.Edit(oTarifa);
        }

        // DELETE api/<controller>/5
        public bool Delete(int id)
        {
            return TarifaData.Delete(id);
        }
    }
}