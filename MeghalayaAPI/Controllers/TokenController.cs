using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Web.Http;
using Microsoft.IdentityModel.Tokens;

namespace MeghalayaAPI.Controllers
{
    [RoutePrefix("api/token")]
    public class TokenController : ApiController
    {
        private static readonly Dictionary<string, string> Clients = new Dictionary<string, string>
        {
            { "V204mtm9", "e2BHkN7Z" },
            { "V204mtn9", "e2BHkN7Y" }
        };
        [HttpPost]
        [Route("generatetoken")]
        public IHttpActionResult GetToken(ClientCredentials credentials)
        {
            if (Clients.TryGetValue(credentials.ClientId, out var secret) && secret == credentials.ClientSecret)
            {
                var token = GenerateJwtToken(credentials.ClientId);
                return Ok(new { token });
            }
            return Unauthorized();
        }

        private string GenerateJwtToken(string clientId)
        {
            var secret = ConfigurationManager.AppSettings["JwtSecretKey"];
            var key = Encoding.UTF8.GetBytes(secret);
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, clientId) }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }

    public class ClientCredentials
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
    }
}