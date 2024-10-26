using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using SavingAccount_BE.Model;
using SavingAccount_BE.Service.Users.Cards;
using SavingAccount_BE.Service.Users.Histories;
using SavingAccount_BE.Service.Users.Profile;
using SavingAccount_BE.Service.Users.SavingAccounts;

namespace SavingAccount_BE.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserCard _userCardService;
        private readonly IUserHistory _userHistoryService;
        private readonly IUserSavingAccountService _userSavingAccountService;
        private readonly IUserProfile  _userProfileService;
        public UsersController(IUserCard userCardService,IUserHistory userHistory, IUserSavingAccountService userSavingAccountService , IUserProfile userProfile)
        {
            _userCardService = userCardService;
            _userHistoryService = userHistory;
            _userSavingAccountService = userSavingAccountService;
            _userProfileService = userProfile;
        }

        [HttpGet("Wallet")]
        //[Authorize(Roles = "User")]
        public IActionResult GetListCards([FromQuery] string userId)
        {
            return Ok(_userCardService.GetListCards(userId));
        }

        [HttpGet("History")]
        //[Authorize(Roles = "User")]
        public IActionResult GetListHistory([FromQuery] string userId)
        {
            return Ok(_userHistoryService.GetHistory(userId));
        }

        [HttpGet("ListSavingAccounts")]
        //[Authorize(Roles = "User")]
        public IActionResult GetListSavingAccounts([FromQuery] string userId)
        {
            return Ok(_userSavingAccountService.GetListSavingAccounts(userId));
        }
        [HttpGet("Profile")]
        //[Authorize(Roles = "Admin")]
        public IActionResult GetProfile([FromQuery] string userId)
        {
            return Ok(_userProfileService.GetProfile(userId));
        }


        // POST api/<ValuesController>
        [HttpPost("update-profile")]
        public IActionResult UpdateProfile([FromQuery] string id, [FromBody] UserDTO updatedUser)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest("User ID is required.");
            }

            if (updatedUser == null)
            {
                return BadRequest("Invalid user data.");
            }

            // Gọi hàm updateProfile từ service
            bool isUpdated = _userProfileService.updateProfile(id, updatedUser);

            if (isUpdated)
            {
                return Ok("Profile updated successfully.");
            }
            else
            {
                return StatusCode(500, "Failed to update profile.");
            }
        }


        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
