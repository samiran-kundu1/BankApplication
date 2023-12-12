using DAL.IDAL;
using Entities.Models;
using SharedData.TestData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAL
{
    public class TransactionDALLayer: ITransactionDALLayer
    {
        public decimal DepositAmountInAccount(int userId ,int acctId,decimal amount)
        {
                var balance = DummyTestClass.GetAccounts(userId).FirstOrDefault(acct => acct.AccountId == acctId).Balance + amount;

                return balance;
        }
        
        public decimal WithDrawAmountInAccount(int userId ,int acctId,decimal amount)
        {

            var balance = DummyTestClass.GetAccounts(userId).FirstOrDefault(acct=>acct.AccountId == acctId).Balance;
            if(IsValidTransactionAmountToBeWithdrawn(balance,amount))
            {
                return balance - amount;
            }

            return -1;
        }

        //To Do: Remove this logic from Dal and put it in service layer
        private bool IsValidTransactionAmountToBeWithdrawn(decimal balance ,decimal amount)
        {
            return balance > amount && (balance *.9M) >amount ;
        }
    }
}
