
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Asp.NetCore.WebApi.MediatRDemo{

    //发布模式
    public class UserRegisterCommandNew:INotification{
        public string EmailAddress{get;set;}
        public string Password{get;set;}
        public UserRegisterCommandNew(string email,string password){
            this.EmailAddress=email;
            this.Password=password;
        }
    }
}