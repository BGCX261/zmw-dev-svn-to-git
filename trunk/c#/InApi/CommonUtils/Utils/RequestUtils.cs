using System.Collections.Specialized;
using System.Linq;
using System.Security.Policy;
using System.Web;
using CommonUtils.Extensions;

namespace CommonUtils.Utils
{
    public static class RequestUtils
    {
        public static string ToQueryString(NameValueCollection param)
        {
            return param.AllKeys.Where(key => !string.IsNullOrEmpty(param.Get(key))).Aggregate("", (current, key) => current + ("&" + key.Lowercase() + "=" + HttpUtility.UrlEncode(param.Get(key))));
        }
    }
}