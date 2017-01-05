using System.ComponentModel.DataAnnotations;

namespace Asp.NetCore.IdentityDemo.Models.AccountViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
