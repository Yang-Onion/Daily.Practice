namespace Asp.NetCore.WebApi.MediatRDemo{
    public class UserModifyPasswordDto{
        public string EmailAddress {get;set;}
        public string Password{get;set;}
        public string OldPassword{get;set;}
    }
}