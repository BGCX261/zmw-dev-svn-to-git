using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CommonUtils.Extensions;
using Mobile.Dao;

namespace Mobile.Logic
{
    public class UserAccountLogic
    {
        public UserAccountDao UserAccountDao = new UserAccountDao();

        public void Register(string account, string password)
        {
            var userAccount = new UserAccount();
            userAccount.Account = account;
            userAccount.Password = password.ToBinary();
            userAccount.DelFlag = 0;

            UserAccountDao.Save(userAccount);


        }

        public UserAccount GetUserAccount(string account)
        {
            return UserAccountDao.FindByAccount(account);
        }
    }
}