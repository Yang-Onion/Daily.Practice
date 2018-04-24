
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Asp.NetCore.WebApi.MediatRDemo{
    public class UserRegisterCommand:IRequest<bool>{
        public string EmailAddress{get;set;}
        public string Password{get;set;}
        public UserRegisterCommand(string email,string password){
            this.EmailAddress=email;
            this.Password=password;
        }
    }
}