using System.Linq;
using System;
using System.Collections.Generic;

namespace zmw.dev.Dao.Holders
{
    public static class CurrentInfoHolder
    {
        [ThreadStatic]
        private static IDictionary<string, object> _dict = new Dictionary<string, object>();

        private const string KeyTimestamp = "KEY_TIMESTAMP";
        private const string KeyUserid = "KEY_USERID";

        public static void Init()
        {
            _dict = new Dictionary<string, object>();
        }

        public static void Clear()
        {
            _dict.Clear();
        }

        public static DateTime? GetBoundDateTime()
        {
            if (_dict.ContainsKey(KeyTimestamp))
            {
                return (DateTime?)_dict[KeyTimestamp];
            }
            return null;
        }

        public static string GetBoundUser()
        {
            if (_dict.ContainsKey(KeyUserid))
            {
                return (string)_dict[KeyUserid];
            }
            return null;
        }


        public static void BindUserToThread(String user)
        {
            _dict.Add(KeyUserid, user);
        }

        public static void BindDateTimeToThread(DateTime datetime)
        {
            _dict.Add(KeyTimestamp, datetime);
        }
    }
}