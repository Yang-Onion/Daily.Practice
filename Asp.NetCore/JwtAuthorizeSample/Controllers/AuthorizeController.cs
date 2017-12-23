using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace JwtAuthorizeSample.Controllers
{
    [Route("api/[controller]")]
    public class AuthorizeController : Controller
    {
        private readonly JwtSetting _jwtSetting;
        public AuthorizeController(IOptions<JwtSetting> jwtSetting)
        {
            _jwtSetting = jwtSetting.Value;
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Token(LoginViewModel model)
        {
           if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (model.UserName=="yangonion" && model.Password=="123456")
            {
                var claims = new Claim[]
                {
                    new Claim(ClaimTypes.Name,"yangonion"),
                    new Claim(ClaimTypes.Role,"admin")
                };
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("qrcode_auto_login"));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    "http://localhost:5000",
                    "http://localhost:5000",
                    //_jwtSetting.Isuuer,
                    //_jwtSetting.Audience,
                    claims, 
                    DateTime.Now,
                    DateTime.Now.AddMinutes(30),
                    creds);
                return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
            }

            return BadRequest();
        }

    }
}