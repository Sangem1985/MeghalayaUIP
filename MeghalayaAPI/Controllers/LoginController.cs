using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MeghalayaAPI.Controllers
{
    public class LoginController : ApiController
    {

        [AllowAnonymous]
        [HttpPost]
        [Route("api/data/forall")]
        public IHttpActionResult Get()
        {
            return Ok("Now server time is: " + DateTime.Now.ToString());
        }
    }
}