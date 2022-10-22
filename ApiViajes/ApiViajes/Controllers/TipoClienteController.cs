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
    public class TipoClienteController : ApiController
    {

        // GET para Select(Un elemento)
        public TipoCliente Get(int id)
        {
            return TipoClienteData.Select(id);
        }

        // GET para Select(Varios elementos)
        public List<TipoCliente> Get()
        {
            return TipoClienteData.SelectAll();
        }


        // POST para Save
        public bool Post([FromBody]TipoCliente oTipoCliente)
        {
            return TipoClienteData.Save(oTipoCliente);
        }

        // PUT api/<controller>/5
        public bool Put([FromBody]TipoCliente oTipoCliente)
        {
            return TipoClienteData.Edit(oTipoCliente);
        }

        // DELETE api/<controller>/5
        public bool Delete(int id)
        {
            return TipoClienteData.Delete(id);
        }
    }
}