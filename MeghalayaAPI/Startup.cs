using System.Text;
using System.Web.Http;
using Microsoft.Owin;
using Microsoft.Owin.Security.Jwt;
using Microsoft.Owin.Security;
using Microsoft.IdentityModel.Tokens;
using Owin;
using System.Configuration;
[assembly: OwinStartup(typeof(MeghalayaAPI.Startup))]
namespace MeghalayaAPI
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var secret = ConfigurationManager.AppSettings["JwtSecretKey"];
            var key = Encoding.UTF8.GetBytes(secret);

            app.UseJwtBearerAuthentication(new JwtBearerAuthenticationOptions
            {
                AuthenticationMode = AuthenticationMode.Active,
                TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateLifetime = true
                }
            });

            HttpConfiguration config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            app.UseWebApi(config);
            
        }
        
    }
}