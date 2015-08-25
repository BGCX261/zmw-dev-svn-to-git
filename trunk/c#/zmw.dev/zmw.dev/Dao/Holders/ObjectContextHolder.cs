using System.Linq;
using System;
using System.Transactions;
using zmw.dev.Dao.Context;

namespace zmw.dev.Dao.Holders
{
    public static class ObjectContextHolder
    {
        [ThreadStatic]
        private static ObjectContext _dbContext;

        /// <summary>
        /// セッションスレッド内でユニークとなるトランザクションスコープ
        /// </summary>
        [ThreadStatic]
        private static TransactionScope _transactionScope;

        public static ObjectContext ObjectContext()
        {
            return _dbContext ?? (_dbContext = new ObjectContext());
        }

        public static void Dispose()
        {
            _dbContext.Dispose();
            _dbContext = null;
        }

        /// <summary>
        /// トランザクションスコープを取得＆開始します
        /// </summary>
        /// <returns>トランザクションスコープ</returns>
        public static TransactionScope GetTransactionScope()
        {
            if (_transactionScope != null)
            {
                _transactionScope.Dispose();
            }
            _transactionScope = new TransactionScope();
            return _transactionScope;
        }

        /// <summary>
        /// トランザクションスコープを完了します
        /// </summary>
        public static void CompleteTransactionScope()
        {
            if (_transactionScope != null)
            {
                _transactionScope.Complete();
            }
        }

        /// <summary>
        /// トランザクションスコープを解放します
        /// </summary>
        public static void DisposeTransactionScope()
        {
            if (_transactionScope != null)
            {
                _transactionScope.Dispose();
                _transactionScope = null;
            }
        }
    }
}