using System.ComponentModel.DataAnnotations;

namespace SavingAccount_BE.Model
{
    public class MessageSendModel
    {
        [Required]
        public string Message { get; set; }
    }
}
