using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;

namespace Asp.NetCore.WebApi.MediatRDemo.Controllers
{
    [Route("api/[controller]")]
    public class HomeController : Controller
    {
        private readonly IMediator _mediator;
        public HomeController(IMediator mediator){
            _mediator = mediator;
        }

        [HttpPost]
        [Route("register")]
        public async Task<bool> UserRegisterAsync(UserRegisterDto userRegisterDto)
        {
           var userRegisterCommand= new UserRegisterCommand(userRegisterDto.EmailAddress,userRegisterDto.Password);
           return   await _mediator.Send(userRegisterCommand);
        }

        [HttpPost]
        [Route("modifypassword")]
        public async Task<bool> UserModifyPasswordAsync(UserModifyPasswordDto userModifyPasswordDto)
        {
           var userModifyPasswordCommand= new UserModifyPasswordCommand(userModifyPasswordDto.EmailAddress,userModifyPasswordDto.Password,userModifyPasswordDto.OldPassword);
           return   await _mediator.Send(userModifyPasswordCommand);
        }

    }
}
