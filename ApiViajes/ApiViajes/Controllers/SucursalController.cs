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
    public class SucursalController : ApiController
    {
        // GET para Select(Un elemento)
        public Sucursal Get(int id)
        {
            return SucursalData.Select(id);
        }

        // GET para Select(Varios elementos)
        public List<Sucursal> Get()
        {
            return SucursalData.SelectAll();
        }


        // POST para Save
        public bool Post([FromBody]Sucursal oSucursal)
        {
            return SucursalData.Save(oSucursal);
        }

        // PUT api/<controller>/5
        public bool Put([FromBody]Sucursal oSucursal)
        {
            return SucursalData.Edit(oSucursal);
        }

        // DELETE api/<controller>/5
        public bool Delete(int id)
        {
            return SucursalData.Delete(id);
        }
    }
}