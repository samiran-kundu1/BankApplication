using BusinessLayer.Interface;
using BusinessLayer.Service;
using DAL.DAL;
using Microsoft.AspNetCore.Mvc;

namespace BankApplicationApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TranSactionController : ControllerBase
    {
        #region Private Members

        //TransactionService transactionService = new TransactionService();
        ITransactionService _transactionService;
        #endregion

        public TranSactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpPut]
        [Route("Deposit")]
        public IActionResult DepositAmountInAccount(int userId, int acctId, decimal amount)
        {
                var balance = _transactionService.DepositAmountInAccount(userId, acctId, amount);
                return Ok(balance);
        }
        
        [HttpPut]
        [Route("WithDraw")]
        public IActionResult WithDrawAmountInAccount(int userId, int acctId, decimal amount)
        {
                var balance = _transactionService.WithDrawAmountInAccount(userId, acctId, amount);
                return Ok(balance);
        }
    }
}
