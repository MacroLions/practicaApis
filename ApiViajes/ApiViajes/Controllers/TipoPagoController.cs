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
    public class TipoPagoController : ApiController
    {// GET para Select(Un elemento)
        public TipoPago Get(int id)
        {
            return TipoPagoData.Select(id);
        }

        // GET para Select(Varios elementos)
        public List<TipoPago> Get()
        {
            return TipoPagoData.SelectAll();
        }


        // POST para Save
        public bool Post([FromBody]TipoPago oTipoPago)
        {
            return TipoPagoData.Save(oTipoPago);
        }

        // PUT api/<controller>/5
        public bool Put([FromBody]TipoPago oTipoPago)
        {
            return TipoPagoData.Edit(oTipoPago);
        }

        // DELETE api/<controller>/5
        public bool Delete(int id)
        {
            return TipoPagoData.Delete(id);
        }
    }
}