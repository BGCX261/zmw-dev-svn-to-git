using System.Collections.Generic;
using System.Collections.Specialized;
using System.Reflection;
using System.Text;
using BaiduApi.Exceptions;
using BaiduApi.Models;
using BaiduApi.Models.Conditions;
using BaiduApi.Properties;
using CommonUtils.Extensions;
using CommonUtils.Utils;
using Newtonsoft.Json;

namespace BaiduApi.Api
{
    public class PlaceApi : Abstract
    {
        public PlaceApi(string key)
            : base(key)
        {
        }

        public List<Place> Place(PlaceCondition condition)
        {
            if (string.IsNullOrEmpty(condition.Key)) { condition.Key = Key; }
            NameValueCollection param = condition.ConvertToCollection(null, BindingFlags.Public);
            var url = Settings.Default.PlaceAPIURL + RequestUtils.ToQueryString(param);
            var returnResult = GetApiResult<ReturnResult>(url, Encoding.UTF8);

            if (returnResult == null) throw new Exception();
            if (!"OK".Equals(returnResult.Status)) throw new Exception(returnResult.Status);

            var rtn = JsonConvert.DeserializeObject<List<Place>>(returnResult.Results.ToString());
            return rtn;
        }


    }
}
