using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaiduApi.Exceptions
{
    public class Exception : SystemException
    {
        public string Name;

        public Exception()
        {
        }

        public Exception(string name)
        {
            Name = name;
        }
    }
}
