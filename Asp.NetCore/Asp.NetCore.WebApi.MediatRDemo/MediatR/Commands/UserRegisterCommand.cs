
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Asp.NetCore.WebApi.MediatRDemo{

    /* 没有返回值
        public class VoidCommand:IRequest{
            
        }
     */

    //请求/响应模式
    public class UserRegisterCommand:IRequest<bool>{
        public string EmailAddress{get;set;}
        public string Password{get;set;}
        public UserRegisterCommand(string email,string password){
            this.EmailAddress=email;
            this.Password=password;
        }
    }
}