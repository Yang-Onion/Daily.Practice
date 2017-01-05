using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Asp.Net.JWT.Token.TokenBaseAuth;
using Microsoft.ApplicationInsights.AspNetCore.TelemetryInitializers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace Asp.Net.JWT.Token.Controllers
{
    [Route("api/[controller]")]
    public class TokenAuthController : Controller
    {
        [HttpPost]
        public string GetAuthToken(User user)
        {
            var existUser =
                UserStorage.Users.FirstOrDefault(
                    g => g.Username.Equals(user.Username) && g.Password.Equals(user.Password));
            if (existUser!= null)
            {
                var requestAt = DateTime.Now;
                var expiresIn = requestAt + TokenAuthOption.ExpireSpan;
                var token = GenerateToken(existUser, expiresIn);


                return
                    JsonConvert.SerializeObject(
                        new
                        {
                            stateCode = 1,
                            requestAt = requestAt,
                            expiresIn = TokenAuthOption.ExpireSpan.TotalSeconds,
                            accessToken = token
                        });
            }
           return JsonConvert.SerializeObject(new { stateCode = -1, errors = "Username or password is invalid" });
        }


        private string GenerateToken(User user, DateTime expires)
        {
            var handler = new JwtSecurityTokenHandler();
            ClaimsIdentity identity = new ClaimsIdentity(
                new GenericIdentity(user.Username, "TokenAuth"),
                new[]
                {
                    new Claim("ID",user.ID.ToString()),
                }
            );

            var securityToken = handler.CreateToken(new SecurityTokenDescriptor()
            {
                Issuer = TokenAuthOption.Issuer,
                Audience = TokenAuthOption.Audience,
                SigningCredentials = TokenAuthOption.SigningCredentials,
                Subject = identity,
                Expires = expires
            });
            return handler.WriteToken(securityToken);
        }
    }
}
