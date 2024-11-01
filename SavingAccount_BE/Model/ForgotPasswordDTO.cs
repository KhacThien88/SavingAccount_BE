using System.ComponentModel.DataAnnotations;

namespace SavingAccount_BE.Model
{
    public class ForgotPasswordDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string ClientURI { get; set; }
    }

}
