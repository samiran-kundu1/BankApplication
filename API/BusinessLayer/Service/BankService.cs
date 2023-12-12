using BusinessLayer.Interface;
using DAL.DAL;
using DAL.IDAL;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Service
{
    public class BankService : IBankService
    {
        #region Private Members


        BankDALLayer bankDalLayer = new BankDALLayer();

        IBankDAL _bankDALService; 
        #endregion

        public BankService(IBankDAL bankDALService)
        {
            _bankDALService = bankDALService;
        }
        public List<User> GetUserList()
        {
            return _bankDALService.GetUserList();
        }

        public List<Account> GetUserAccountList(int userId)
        {
            return _bankDALService.GetUserAccountList(userId);
        }

        public List<Account> CreateUserAccount(int userId, decimal amount)
        {
            return _bankDALService.CreateUserAccount(userId, amount);
        }

        public List<Account> DeleteUserAccount(int userId, int accntId)
        {
            return _bankDALService.DeleteUserAccount(userId, accntId);
        }
    }
}


