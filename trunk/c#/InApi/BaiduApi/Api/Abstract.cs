using System;
using System.IO;
using System.Net;
using System.Text;
using BaiduApi.Models;
using Newtonsoft.Json;
using Exception = BaiduApi.Exceptions.Exception;

namespace BaiduApi.Api
{
    public abstract class Abstract
    {
        protected string Key;

        protected Abstract(string key)
        {
            Key = key;
        }


        /// <summary>
        /// GET
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="dataEncode"></param>
        /// <returns></returns>
        protected static T GetApiResult<T>(string url, Encoding dataEncode)
        {
            var result = GetWebRequest(url, dataEncode);
            var returnResult = JsonConvert.DeserializeObject<T>(result);
            return returnResult;
        }


        /// <summary>
        /// POST
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="postUrl"></param>
        /// <param name="paramData"></param>
        /// <param name="dataEncode"></param>
        /// <returns></returns>
        protected static T GetApiResult<T>(string postUrl, string paramData, Encoding dataEncode)
        {
            var result = PostWebRequest(postUrl, paramData, dataEncode);
            var returnResult = JsonConvert.DeserializeObject<T>(result);
            return returnResult;
        }

        private static string GetWebRequest(string url, Encoding dataEncode)
        {
            var webClient = new WebClient { Encoding = dataEncode };
            var result = webClient.DownloadString(url);
            webClient.Dispose();
            return result;
        }


        private static string PostWebRequest(string postUrl, string paramData, Encoding dataEncode)
        {
            string ret;
            try
            {
                byte[] byteArray = dataEncode.GetBytes(paramData); //转化
                var webReq = (HttpWebRequest)WebRequest.Create(new Uri(postUrl));
                webReq.Method = "POST";
                webReq.ContentType = "application/x-www-form-urlencoded";

                webReq.ContentLength = byteArray.Length;
                Stream newStream = webReq.GetRequestStream();
                newStream.Write(byteArray, 0, byteArray.Length);//写入参数
                newStream.Close();
                var response = (HttpWebResponse)webReq.GetResponse();
                var sr = new StreamReader(response.GetResponseStream(), Encoding.Default);
                ret = sr.ReadToEnd();
                sr.Close();
                response.Close();
                newStream.Close();
            }
            catch (Exception ex)
            {
                ret = string.Empty;
            }
            return ret;
        }

    }
}