using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplicationServiceTestProject
{
    [TestClass]
    public class BankServiceTestClass
    {
        [TestMethod]
        public void GetUserAccountListForUserIdTest()
        {
            BankService bankService = new BankService(new BankDALLayer());
            var result = bankService.GetUserAccountList(1);
            Assert.IsNotNull(result);
        }
        
        [TestMethod]
        public void CreateUserAccountForUserIdTest()
        {
            BankService bankService = new BankService(new BankDALLayer());
            var result = bankService.CreateUserAccount(1,123);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Any(x=>x.Balance == 123));
        }
        
        [TestMethod]
        public void DeleteUserAccountForUserIdTest()
        {
            BankService bankService = new BankService(new BankDALLayer());
            var result = bankService.DeleteUserAccount(1,1);
            Assert.IsNotNull(result);
            //Original number of accounts in mock data is 3,after deletion number of accounts => 2
            Assert.IsTrue(result.Count == 2);
            Assert.IsFalse(result.Any(x=>x.AccountId == 1));
        }

    }
}
