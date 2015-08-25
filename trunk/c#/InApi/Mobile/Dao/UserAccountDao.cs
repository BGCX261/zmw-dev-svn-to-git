using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mobile.Dao.Holders;

namespace Mobile.Dao
{
    public class UserAccountDao : AbstractDao<UserAccount>
    {
        /// <summary>
        /// 账户情报取得
        /// </summary>
        /// <param name="account">账户名</param>
        /// <returns></returns>
        public UserAccount FindByAccount(string account)
        {
            var query = from entity in ObjectContextHolder.ObjectContext().UserAccount
                        where entity.Account.Equals(account)
                        select entity;
            return query.FirstOrDefault();

        }
    }
}