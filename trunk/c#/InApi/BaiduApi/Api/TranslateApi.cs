using System.Collections.Generic;
using System.Collections.Specialized;
using System.Reflection;
using System.Text;
using BaiduApi.Models;
using BaiduApi.Models.Conditions;
using BaiduApi.Properties;
using CommonUtils.Extensions;
using CommonUtils.Utils;

namespace BaiduApi.Api
{
    public class TranslateApi : Abstract
    {
        public TranslateApi(string key) : base(key)
        {
        }

        public Translate Translate(TranslateCondition condition)
        {
            if (string.IsNullOrEmpty(condition.Client_Id)) { condition.Client_Id = Key; }
            NameValueCollection param = condition.ConvertToCollection(null, BindingFlags.Public);
            var result = GetApiResult<Translate>(Settings.Default.GeocoderAPIURL, RequestUtils.ToQueryString(param), Encoding.UTF8);
            return result;
        }
    }
}