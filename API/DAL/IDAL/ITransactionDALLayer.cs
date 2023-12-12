using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IDAL
{
    public interface ITransactionDALLayer
    {
        public decimal DepositAmountInAccount(int userId, int acctId, decimal amount);

        public decimal WithDrawAmountInAccount(int userId, int acctId, decimal amount);
    }
}
