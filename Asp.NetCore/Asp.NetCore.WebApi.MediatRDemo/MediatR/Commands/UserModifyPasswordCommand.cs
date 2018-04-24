using MediatR;

namespace Asp.NetCore.WebApi.MediatRDemo{
    public class UserModifyPasswordCommand:IRequest<bool>{
        public string EmailAddress{get;set;}
        public string Password{get;set;}
        public string OldPassword{get;set;}
        public UserModifyPasswordCommand(string email,string password,string oldpassword){
            EmailAddress=email;
            Password=password;
            OldPassword=oldpassword;
        }
    }
}