using BusinessLayer.Interface;
using BusinessLayer.Service;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace BankApplicationApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BankController : ControllerBase
    {
        #region Private Members

        //Dependency Injection
        IBankService _bankService;

        #endregion

        public BankController(IBankService bankService)
        {
            _bankService = bankService;
        }

        [HttpGet(Name = "GetBankUsers")]
        public IActionResult GetUsers()
        {
            return Ok(_bankService.GetUserList());
            //return Ok(bankService.GetUserList());
        }

        [HttpGet]
        //[HttpGet("{id}")]
        [Route("GetUserAccount")]
        public IActionResult GetUserAccount(int userId)
        {
            return Ok(_bankService.GetUserAccountList(userId));
        }
        
        [HttpPost]
        //[HttpGet("{id}")]
        [Route("CreateAccount")]
        public IActionResult CreateUserAccount(int userId,decimal amount = 100)
        {
            return Ok(_bankService.CreateUserAccount(userId, amount));
        }
        
        [HttpDelete]
        //[HttpGet("{id}")]
        [Route("DeleteAccount")]
        public IActionResult DeleteUserAccount([FromBody] Account account)
        {
            return Ok(_bankService.DeleteUserAccount(account.UserId, account.AccountId));
        }
    }
}
