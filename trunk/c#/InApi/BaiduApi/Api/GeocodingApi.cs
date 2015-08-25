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
    public class GeocodingApi : Abstract
    {
        public GeocodingApi(string key)
            : base(key)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="condition">address和location两个字段如果同时出现，则优先选择address执行地理编码功能。对于address字段可能会出现中文或其它一些特殊字符（如：空格），所以对于类似的字符都要进行编码处理，编码成 UTF-8 字符的二字符十六进制值，凡是不在下表中的字符都要进行编码。</param>
        /// <returns></returns>
        public Geocoder Geocoding(GeocodingCondition condition)
        {
            if (string.IsNullOrEmpty(condition.Key)) { condition.Key = Key; }

            NameValueCollection param = condition.ConvertToCollection(null, BindingFlags.Public);
            var returnResult = GetApiResult<ReturnResult>(Settings.Default.GeocoderAPIURL, RequestUtils.ToQueryString(param), Encoding.UTF8);
            if (returnResult == null) throw new Exception();
            if (!"OK".Equals(returnResult.Status)) throw new Exception(returnResult.Status);

            var rtn = JsonConvert.DeserializeObject<Geocoder>(returnResult.Results.ToString());
            return rtn;
        }


    }
}
