using System.ComponentModel.DataAnnotations;

namespace Asp.NetCore.IdentityDemo.Models.AccountViewModels
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
