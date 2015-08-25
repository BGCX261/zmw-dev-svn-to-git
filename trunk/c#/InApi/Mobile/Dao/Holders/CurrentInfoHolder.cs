using System;
using System.Collections.Generic;

namespace Mobile.Dao.Holders
{
    public sealed class CurrentInfoHolder
    {
        [ThreadStatic]
        private static IDictionary<string, object> _dict = new Dictionary<string, object>();

        private static readonly string KEY_TIMESTAMP = "KEY_TIMESTAMP";

        private CurrentInfoHolder()
        {
        }

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
            if (_dict.ContainsKey(KEY_TIMESTAMP))
            {
                return (DateTime?)_dict[KEY_TIMESTAMP];
            }
            return null;
        }

        public static void BindDateTimeToThread(DateTime datetime)
        {
            _dict.Add(KEY_TIMESTAMP, datetime);
        }

    }
}
