using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http.Filters;
using System.Data;
using System.Threading;
using System.Security.Principal;
using MeghalayaAPI.BAL;

namespace MeghalayaAPI
{
    public class BasicAuthentication : AuthorizationFilterAttribute
    {
        NSWSBAL ObjNswsbal = new NSWSBAL();
        public override void OnAuthorization(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
            else
            {
                // Gets header parameters  
                string authenticationString = actionContext.Request.Headers.Authorization.Parameter;
                string DecodedoriginalString = Encoding.UTF8.GetString(Convert.FromBase64String(authenticationString));

                // Gets username and password  
                string Username = DecodedoriginalString.Split(':')[0];
                string Password = DecodedoriginalString.Split(':')[1];

                // Validate username and password  
                DataTable dt_validate = ObjNswsbal.NSWSUserAuthentication(Username, Password);
                if (dt_validate != null && dt_validate.Rows.Count > 0)
                {
                    Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(Username), null);
                }
                else
                {
                    // returns unauthorized error  
                    // actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                    actionContext.Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Forbidden);
                }
            }

            base.OnAuthorization(actionContext);
        }
    }
}