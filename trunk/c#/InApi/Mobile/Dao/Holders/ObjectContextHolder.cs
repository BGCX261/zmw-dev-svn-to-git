using System;
using Mobile.Dao.Context;

namespace Mobile.Dao.Holders
{
    public sealed class ObjectContextHolder
    {
        [ThreadStatic]
        private static DatabaseContext _dbContext;

        private ObjectContextHolder()
        {
        }

        public static DatabaseContext ObjectContext()
        {
            if (_dbContext == null)
            {
                _dbContext = new DatabaseContext();
            }
            return _dbContext;
        }

        public static void Dispose()
        {
            _dbContext.Dispose();
            _dbContext = null;
        }

    }
}
