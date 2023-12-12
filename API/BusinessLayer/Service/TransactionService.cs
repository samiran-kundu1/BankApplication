using BusinessLayer.Interface;
using DAL.DAL;
using DAL.IDAL;
using SharedData.TestData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Service
{
    public class TransactionService : ITransactionService
    {
        #region Private Members
        
        private decimal maxAmountAllowed = 10000.00M;

        TransactionDALLayer transactionDALLayer = new TransactionDALLayer();

        ITransactionDALLayer _transactionDALLayer;

        #endregion

       

        public TransactionService(ITransactionDALLayer _transactionDALLayer)
        {
            this._transactionDALLayer = _transactionDALLayer;
        }

        public decimal DepositAmountInAccount(int userId, int acctId, decimal amount)
        {
            if (IsValidTransactionAmountToBeDeposited(amount))
            {
                var balance = _transactionDALLayer.DepositAmountInAccount(userId, acctId, amount);
                return balance;
            }
            return -1;
        }

       

        public decimal WithDrawAmountInAccount(int userId, int acctId, decimal amount)
        {
                var balance = _transactionDALLayer.WithDrawAmountInAccount(userId, acctId, amount);
                return balance;
        }

        #region Helper Methods
        private bool IsValidTransactionAmountToBeDeposited(decimal amount)
        {
            return amount < maxAmountAllowed;
        } 
        #endregion

    }
}
