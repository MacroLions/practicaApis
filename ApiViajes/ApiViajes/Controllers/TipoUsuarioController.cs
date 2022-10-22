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
    public class TipoUsuarioController : ApiController
    {

        // GET para Select(Un elemento)
        public TipoUsuario Get(int id)
        {
            return TipoUsuarioData.Select(id);
        }

        // GET para Select(Varios elementos)
        public List<TipoUsuario> Get()
        {
            return TipoUsuarioData.SelectAll();
        }


        // POST para Save
        public bool Post([FromBody]TipoUsuario oTipoUsuario)
        {
            return TipoUsuarioData.Save(oTipoUsuario);
        }

        // PUT api/<controller>/5
        public bool Put([FromBody]TipoUsuario oTipoUsuario)
        {
            return TipoUsuarioData.Edit(oTipoUsuario);
        }

        // DELETE api/<controller>/5
        public bool Delete(int id)
        {
            return TipoUsuarioData.Delete(id);
        }
    }
}