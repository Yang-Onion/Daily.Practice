using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;

namespace Asp.NetCore.WebApi.MediatRDemo{

    public class UserRegisterCommandHandler : IRequestHandler<UserRegisterCommand, bool>
    {
        private readonly IDistributedCache _cache;
        public UserRegisterCommandHandler(IDistributedCache cache){
            _cache=cache;
        }
        public async Task<bool> Handle(UserRegisterCommand request, CancellationToken cancellationToken)
        {
            var value = await _cache.GetStringAsync(request.EmailAddress);
            
            //user had  existed
            if(!string.IsNullOrWhiteSpace(value)){
                return false;
            }
            
            await _cache.SetStringAsync(request.EmailAddress,request.Password);
            
            return true;
        }
    }
}