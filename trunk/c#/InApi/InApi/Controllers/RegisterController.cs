using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace InApi.Controllers
{
    public class RegisterController : ApiController
    {
        //
        // GET: /Register/

        public object Index()
        {
            string url = "http://www.thinkpage.cn/weather/api.svc/getWeather?city=101010100&language=zh-chs&provider=smart&unit=c&format=json&key=";
            var obj = GetValue<Res>(url);
            return new { param1 = "value1", param2 = "value2" };
        }

        private static T GetValue<T>(string url)
        {
            var webClient = new WebClient();
            var downloadString = webClient.DownloadString(url);
            webClient.Dispose();
            var obj = JsonConvert.DeserializeObject<T>(downloadString);
            return obj;
        }

        private struct Res
        {
            public string Stat;
            public string Weathers;
        }

    }
}
