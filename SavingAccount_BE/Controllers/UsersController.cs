using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using SavingAccount_BE.Service.Users.Cards;
using SavingAccount_BE.Service.Users.Histories;
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
        public UsersController(IUserCard userCardService,IUserHistory userHistory, IUserSavingAccountService userSavingAccountService)
        {
            _userCardService = userCardService;
            _userHistoryService = userHistory;
            _userSavingAccountService = userSavingAccountService;
        }

        [HttpGet("Wallet")]
        public IActionResult GetListCards([FromQuery] string userId)
        {
            return Ok(_userCardService.GetListCards(userId));
        }

        [HttpGet("History")]
        public IActionResult GetListHistory([FromQuery] string userId)
        {
            return Ok(_userHistoryService.GetHistory(userId));
        }

        [HttpGet("ListSavingAccounts")]
        public IActionResult GetListSavingAccounts([FromQuery] string userId)
        {
            return Ok(_userSavingAccountService.GetListSavingAccounts(userId));
        }


        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
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
