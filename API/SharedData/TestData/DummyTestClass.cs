using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedData.TestData
{
    public static class DummyTestClass
    {
        public static List<User> users = new List<User>()
        {
            new User()
            {
                 Accounts= new List<Account>()
                 {
                     new Account()
                     {
                            AccountId= 1,
                            AccountNumber = 1,
                            Balance=100,
                             UserId= 1
                     },
                     new Account()
                     {
                            AccountId= 2,
                            AccountNumber = 2,
                            Balance=1000,
                            UserId= 1
                     },
                     new Account()
                     {
                            AccountId= 3,
                            AccountNumber = 3,
                            Balance=1001,
                             UserId= 1
                     },

                 },
                  UserId= 1,
                   Username = "Test User 1"
            },
            new User()
            {
                 Accounts= new List<Account>()
                 {
                     new Account()
                     {
                            AccountId= 6,
                            AccountNumber = 1,
                            Balance=200,
                             UserId= 2
                     },
                     new Account()
                     {
                            AccountId= 7,
                            AccountNumber = 2,
                            Balance=20000,
                            UserId= 2
                     },
                     new Account()
                     {
                            AccountId= 8,
                            AccountNumber = 3,
                            Balance=20001,
                             UserId= 2
                     },

                 },
                  UserId= 2,
                   Username = "Test User 2"
            }
        };

        public static List<Account> GetAccounts(int userId) 
        {
            
            return users.SelectMany(x => x.Accounts).Where(u => u.UserId == userId).ToList();

        }

    }
}
