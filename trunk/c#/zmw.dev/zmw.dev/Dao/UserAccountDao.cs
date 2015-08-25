using zmw.dev.Dao.Context;
using zmw.dev.Dao.Holders;
using System.Linq;

namespace zmw.dev.Dao
{
    public class UserAccountDao : AbstractDao<UserAccount>
    {
        public UserAccount FindByAccountId(string accountId)
        {
            var query = from entity in ObjectContextHolder.ObjectContext().UserAccount
                        where entity.AccountId == accountId
                        select entity;
            return query.SingleOrDefault();

        }
    }
}