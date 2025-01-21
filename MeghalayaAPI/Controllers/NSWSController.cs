using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MeghalayaAPI.Controllers
{
    public class NSWSController : ApiController
    {
        // GET: api/NSWS
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/NSWS/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/NSWS
        public void Post([FromBody]string value)
        {

        }

        // PUT: api/NSWS/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/NSWS/5
        public void Delete(int id)
        {
        }
    }
}
