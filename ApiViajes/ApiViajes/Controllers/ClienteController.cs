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
    public class ClienteController : ApiController
    {

        // GET para Select(Un elemento)
        public Cliente Get(int id)
        {
            return ClienteData.Select(id);
        }

        // GET para Select(Varios elementos)
        public List<Cliente> Get()
        {
            return ClienteData.SelectAll();
        }


        // POST para Save
        public bool Post([FromBody]Cliente oCliente)
        {
            return ClienteData.Save(oCliente);
        }

        // PUT api/<controller>/5
        public bool Put([FromBody]Cliente oCliente)
        {
            return ClienteData.Edit(oCliente);
        }

        // DELETE api/<controller>/5
        public bool Delete(int id)
        {
            return ClienteData.Delete(id);
        }
    }
}