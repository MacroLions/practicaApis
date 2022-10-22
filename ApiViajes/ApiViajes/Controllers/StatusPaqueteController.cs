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
    public class StatusPaqueteController : ApiController
    {// GET para Select(Un elemento)
        public StatusPaquete Get(int id)
        {
            return StatusPaqueteData.Select(id);
        }

        // GET para Select(Varios elementos)
        public List<StatusPaquete> Get()
        {
            return StatusPaqueteData.SelectAll();
        }


        // POST para Save
        public bool Post([FromBody]StatusPaquete oStatusPaquete)
        {
            return StatusPaqueteData.Save(oStatusPaquete);
        }

        // PUT api/<controller>/5
        public bool Put([FromBody]StatusPaquete oStatusPaquete)
        {
            return StatusPaqueteData.Edit(oStatusPaquete);
        }

        // DELETE api/<controller>/5
        public bool Delete(int id)
        {
            return StatusPaqueteData.Delete(id);
        }
    }
}