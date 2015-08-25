using System.Net;
using System.Web;
using System.Collections.Specialized;

namespace OpenSinaAPI
{
    public class HttpGet : BaseHttpRequest
    {
        private const string GET = "GET";
        private const string AccessToken = "http://api.t.sina.com.cn/oauth/access_token";
        private const string AUTHORIZE = "http://api.t.sina.com.cn/oauth/authorize";
        private const string RequestToken = "http://api.t.sina.com.cn/oauth/request_token";
        private const string OauthToken = "oauth_token";
        private const string OauthTokenSecret = "oauth_token_secret";
        private const string Oauthuserid = "user_id";

        public override string Request(string uri, string postData)
        {
            string outUrl;
            string queryString = AppendSignatureString(GET, uri, out outUrl);
            if (queryString.Length > 0)
            {
                outUrl += "?";
            }
            return WebRequest(GET, outUrl + queryString);
        }

        public void GetAccessToken()
        {
            SetTokenAndTokenSecret(AccessToken);
        }

        private void SetTokenAndTokenSecret(string url)
        {
            string response = Request(url, string.Empty);

            if (response.Length <= 0) return;
            NameValueCollection queryString = HttpUtility.ParseQueryString(response);
            if (queryString[OauthToken] != null)
            {
                Token = queryString[OauthToken];
            }
            if (queryString[OauthTokenSecret] != null)
            {
                TokenSecret = queryString[OauthTokenSecret];
            }
            if (queryString[Oauthuserid] != null)
            {
                userid = queryString[Oauthuserid];
            }
        }

        public void GetRequestToken()
        {
            SetTokenAndTokenSecret(RequestToken);
        }

        public string GetAuthorizationUrl()
        {
            string ret = string.Format("{0}?oauth_token={1}", AUTHORIZE, Token);
            return ret;
        }


        private string WebRequest(string method, string url)
        {
            HttpWebRequest httpWebRequest = System.Net.WebRequest.Create(url) as HttpWebRequest;
            httpWebRequest.Method = method;
            httpWebRequest.ServicePoint.Expect100Continue = false;
            SetRemoteIPInHeader(httpWebRequest);
            return GetHttpWebResponse(httpWebRequest);
        }
    }
}
