using System.ComponentModel.DataAnnotations;

namespace Asp.NetCore.IdentityDemo.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress(ErrorMessage = "邮件格式不正确")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "密码长度必须大于6个字符", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "密码和确认密码不一样")]
        public string ConfirmPassword { get; set; }
    }
}
