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
    public class InformePaqueteController : ApiController
    {
        // GET para Select(Un elemento)
        public InformePaquete Get(int id)
        {
            return InformePaqueteData.Select(id);
        }

        // GET para Select(Varios elementos)
        public List<InformePaquete> Get()
        {
            return InformePaqueteData.SelectAll();
        }


        // POST para Save
        public bool Post([FromBody]InformePaquete oInformePaquete)
        {
            return InformePaqueteData.Save(oInformePaquete);
        }

        // PUT api/<controller>/5
        public bool Put([FromBody]InformePaquete oInformePaquete)
        {
            return InformePaqueteData.Edit(oInformePaquete);
        }

        // DELETE api/<controller>/5
        public bool Delete(int id)
        {
            return InformePaqueteData.Delete(id);
        }
    }
}