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
    public class BodegaController : ApiController
    {
        // GET para Select(Un elemento)
        public Bodega Get(int id)
        {
            return BodegaData.Select(id);
        }

        // GET para Select(Varios elementos)
        public List<Bodega> Get()
        {
            return BodegaData.SelectAll();
        }


        // POST para Save
        public bool Post([FromBody]Bodega oBodega)
        {
            return BodegaData.Save(oBodega);
        }

        // PUT api/<controller>/5
        public bool Put([FromBody]Bodega oBodega)
        {
            return BodegaData.Edit(oBodega);
        }

        // DELETE api/<controller>/5
        public bool Delete(int id)
        {
            return BodegaData.Delete(id);
        }
    }
}