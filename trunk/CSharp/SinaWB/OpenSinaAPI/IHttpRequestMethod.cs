

namespace OpenSinaAPI
{
    public interface IHttpRequestMethod
    {
        string Request(string uri, string postData);
    }
}
