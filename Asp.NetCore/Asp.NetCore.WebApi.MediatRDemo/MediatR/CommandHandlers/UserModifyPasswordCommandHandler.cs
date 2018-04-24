using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;

namespace Asp.NetCore.WebApi.MediatRDemo{
    public class UserModifyPasswordCommandHandler : IRequestHandler<UserModifyPasswordCommand, bool>
    {
        private readonly IDistributedCache _cache;
        public  UserModifyPasswordCommandHandler(IDistributedCache cache){
            _cache =cache;
        }
        public async Task<bool> Handle(UserModifyPasswordCommand request, CancellationToken cancellationToken)
        {
            var value =await _cache.GetStringAsync(request.EmailAddress);
            //can't find user
            if(string.IsNullOrWhiteSpace(value)){
                 return false;   
            }
            //oldpassword different
            if (!value.Equals(request.OldPassword)){
                return false;
            }

            //set new password
            await _cache.SetStringAsync(request.EmailAddress,request.Password);

            return true;
        }
    }
}