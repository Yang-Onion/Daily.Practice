using AspNetCoreQRCodeLogin.Extenstions;
using AspNetCoreQRCodeLogin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Net.WebSockets;
namespace AspNetCoreQRCodeLogin.Controllers
{
    [Route("api/[controller]")]
    public class AuthorizeController : Controller
    {
        private readonly IDistributedCache _cache;

        private readonly JwtSetting _jwtSetting;

        public AuthorizeController(IDistributedCache cache,IOptions<JwtSetting> jwtSetting)
        {
            _cache=cache??throw new ArgumentNullException("IDistributeCache is null");
            _jwtSetting = jwtSetting.Value;
        }

        [HttpPost]
        [Route("token")]
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

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSetting.SecrectKey));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    _jwtSetting.Issure,
                    _jwtSetting.Audience,
                    claims, 
                    DateTime.Now,
                    DateTime.Now.AddMinutes(30),
                    creds);
                var ticket = new JwtSecurityTokenHandler().WriteToken(token);

                return Ok(new { token = ticket });
            }

            return BadRequest();
        }

        [Authorize]
        [Route("scanlogin")]
        public async Task<IActionResult> EnSureScanLoginAsync(string qrcode)
        {
            if (string.IsNullOrEmpty(qrcode))
            {
                return BadRequest();
            }
            var qrStatus =_cache.GetString(qrcode);
            if (string.IsNullOrEmpty(qrStatus))
            {
                return BadRequest();
            }
            try
            {
                if (HttpContext.WebSockets.IsWebSocketRequest)
                {
                    var token = HttpContext.Request.Headers["Authorization"];
                    var socket = await HttpContext.WebSockets.AcceptWebSocketAsync();

                    var socketHandler = new SocketHandler(socket)
                    {
                        Key = qrcode
                    };
                    await socketHandler.SendAsync();

                    _cache.SetString(qrcode, $"{QRCodeStatus.CONFIRMED}");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            

            return Ok();
        }


    }
}
