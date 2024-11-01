using System.ComponentModel.DataAnnotations;

namespace SavingAccount_BE.Model
{
    public class ResetPasswordDTO
    {
        [Required]
        public string Token { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Mật khẩu phải có độ dài tối thiểu {2} ký tự.", MinimumLength = 6)]
        public string NewPassword { get; set; }
    }
}
