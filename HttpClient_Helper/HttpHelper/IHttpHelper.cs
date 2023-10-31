using HttpClient_Helper.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpClient_Helper.HttpHelper
{
    public interface IHttpHelper<T> where T : class
    {

        Task<HttpRequestResponse> GetRequest(string url, string token = null, Dictionary<string, string> queryParam = null);
        Task<HttpRequestResponse> PostRequest(string url, object data, string contentType, string token = null, Dictionary<string, string> queryParam = null);
        Task<HttpRequestResponse> DeleteRequest(string url, string token = null, Dictionary<string, string> queryParam = null);
        Task<HttpRequestResponse> PutRequest(string url, object data, string contentType, string token = null, Dictionary<string, string> queryParam = null);
        Task<HttpRequestResponse> PatchRequest(string url, object data, string contentType, string token = null, Dictionary<string, string> queryParam = null);
    }
}
