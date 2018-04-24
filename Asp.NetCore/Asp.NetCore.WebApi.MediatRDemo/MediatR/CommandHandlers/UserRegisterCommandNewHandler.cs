using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;

namespace Asp.NetCore.WebApi.MediatRDemo{

    public class UserRegisterCommandNewHandler : INotificationHandler<UserRegisterCommandNew>
    {
        private readonly IDistributedCache _cache;
        public UserRegisterCommandNewHandler(IDistributedCache cache){
            _cache=cache;
        }

        public async Task Handle(UserRegisterCommandNew notification, CancellationToken cancellationToken)
        {
            var value = await _cache.GetStringAsync(notification.EmailAddress);
            //user had  existed
            if(!string.IsNullOrWhiteSpace(value)){
               throw new Exception("user had  existed");
            }
            
            await _cache.SetStringAsync(notification.EmailAddress,notification.Password);
        }
    }


    public class UserRegisterSendSMSHandler : INotificationHandler<UserRegisterCommandNew>
    {
        private readonly IDistributedCache _cache;
        public UserRegisterSendSMSHandler(IDistributedCache cache){
            _cache=cache;
        }

        public Task Handle(UserRegisterCommandNew notification, CancellationToken cancellationToken)
        {
            Debugger.Log(1,"error",$"auto send sms to {notification.EmailAddress}");
            return Task.CompletedTask;
        }
    }
}