using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SavingAccount_BE.Data;
using SavingAccount_BE.Model;
using SavingAccount_BE.Service.MailSender;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SavingAccount_BE.Controllers
{
    [Route("api/forgot-password")]
    [ApiController]
    public class ForgotPasswordController : ControllerBase
    {
        private readonly UserManager<ApplicationUser>  _userManager;
        private readonly SavingAccountDbContext _dbContext;
        private readonly IEmailSender _emailSender;

        public ForgotPasswordController(UserManager<ApplicationUser> userManager, IEmailSender emailSender, SavingAccountDbContext dbContext)
        {
            _userManager = userManager;
            _emailSender = emailSender;
            _dbContext = dbContext;
        }
        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDTO model)
        {
            
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return BadRequest("Email không hợp lệ.");
            }
            var result = await _userManager.ResetPasswordAsync(user, model.Token, model.NewPassword);
            if (!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                return BadRequest(errors);
            }
            await _dbContext.SaveChangesAsync();

            return Ok("Đặt lại mật khẩu thành công.");
        }
        [HttpPost("ForgotPassword")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return Ok("Email không tồn tai");
            }

            var resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);

            var resetPasswordUrl = $"{model.ClientURI}/reset-password?token={resetToken}&email={user.Email}";

            await _emailSender.SendEmailAsync(
                model.Email,
                "Reset Password",
                $"Please reset your password by <a href='{resetPasswordUrl}'>clicking here</a>.");

            return Ok("Đã gửi lại đường dẫn đặt mật khẩu.");
        }
    }

}
