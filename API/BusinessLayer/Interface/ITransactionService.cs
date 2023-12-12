using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface ITransactionService
    {
        decimal DepositAmountInAccount(int userId, int acctId, decimal amount);

        decimal WithDrawAmountInAccount(int userId, int acctId, decimal amount);
    }
}
