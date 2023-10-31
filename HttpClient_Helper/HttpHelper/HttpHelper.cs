using HttpClient_Helper.Model;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HttpClient_Helper.HttpHelper
{
    public class HttpHelper<T> : IHttpHelper<T> where T : class
    {
        public string BaseAddress;
        public HttpHelper(string _baseAddress) 
        {
            this.BaseAddress = _baseAddress;
        }
        public async Task<HttpRequestResponse> DeleteRequest(string url, string token = null, Dictionary<string, string> queryParam = null)
        {
            HttpRequestResponse httpResponse = new HttpRequestResponse();
            try
            {
                var clientHandler = new HttpClientHandler();

                var client = new HttpClient(clientHandler);

                if (token != null)
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                }
                client.BaseAddress = new Uri(this.BaseAddress);
                if (queryParam == null)
                {
                    queryParam = new Dictionary<string, string>();
                }
                var newUrl = new Uri(QueryHelpers.AddQueryString(this.BaseAddress + url, queryParam));
                string[] uri = newUrl.ToString().Split(this.BaseAddress);
                var response = await client.DeleteAsync(uri[1]);
                if (response.IsSuccessStatusCode)
                {
                    httpResponse.Success = true;
                }
                else throw new Exception();
            }
            catch (Exception ex)
            {
                httpResponse.Success = false;
                httpResponse.Error = ex.Message;
            }
            return httpResponse;
        }

        public async Task<HttpRequestResponse> GetRequest(string url, string token = null, Dictionary<string, string> queryParam=null)
        {
            HttpRequestResponse httpResponse = new HttpRequestResponse();
            try
            {
                var clientHandler = new HttpClientHandler();

                var client = new HttpClient(clientHandler);
                if (token != null)
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                }
                client.BaseAddress = new Uri(this.BaseAddress);
                if(queryParam == null)
                {
                    queryParam = new Dictionary<string, string>();
                }
                var newUrl = new Uri(QueryHelpers.AddQueryString(this.BaseAddress+url, queryParam));
                string[] uri = newUrl.ToString().Split(this.BaseAddress);
                var response = await client.GetAsync(uri[1]);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {

                    var jsonStringData = await response.Content.ReadAsStringAsync();

                    object jsonObj = JsonConvert.DeserializeObject<object>(jsonStringData);

                    if (jsonObj is JObject)
                    {
                        T responseObjectData = JsonConvert.DeserializeObject<T>(jsonStringData);
                        httpResponse.Data = responseObjectData;
                    }
                    else if (jsonObj is JArray)
                    {
                        List<T> responseDataList = JsonConvert.DeserializeObject<List<T>>(jsonStringData);
                        httpResponse.Data = responseDataList;
                    }
                    httpResponse.Success = true;
                }
                else throw new Exception();
            }
            catch (Exception ex)
            {
                httpResponse.Success = false;
                httpResponse.Error = ex.Message;
            }
            return httpResponse;
        }

        public async Task<HttpRequestResponse> PatchRequest(string url, object data, string contentType, string token = null, Dictionary<string, string> queryParam = null)
        {
            HttpRequestResponse httpResponse = new HttpRequestResponse();
            try
            {
                var clientHandler = new HttpClientHandler();

                var client = new HttpClient(clientHandler);

                if (token != null)
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                }
                var serializeData = JsonConvert.SerializeObject(data);
                var postData = new StringContent(serializeData, Encoding.UTF8, contentType);
                client.BaseAddress = new Uri(this.BaseAddress);
                if (queryParam == null)
                {
                    queryParam = new Dictionary<string, string>();
                }
                var newUrl = new Uri(QueryHelpers.AddQueryString(this.BaseAddress + url, queryParam));
                string[] uri = newUrl.ToString().Split(this.BaseAddress);
                var response = await client.PatchAsync(uri[1], postData);
                if (response.IsSuccessStatusCode)
                {
                    httpResponse.Success = true;
                }
                else throw new Exception();
            }
            catch (Exception ex)
            {
                httpResponse.Success = false;
                httpResponse.Error = ex.Message;
            }
            return httpResponse;
        }

        public async Task<HttpRequestResponse> PostRequest(string url, object data, string contentType, string token = null, Dictionary<string, string> queryParam = null)
        {
            HttpRequestResponse httpResponse = new HttpRequestResponse();
            try
            {
                var clientHandler = new HttpClientHandler();

                var client = new HttpClient(clientHandler);

                if (token != null)
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                }
                var serializeData = JsonConvert.SerializeObject(data);
                var postData = new StringContent(serializeData, Encoding.UTF8, contentType);
                client.BaseAddress = new Uri(this.BaseAddress);
                if (queryParam == null)
                {
                    queryParam = new Dictionary<string, string>();
                }
                var newUrl = new Uri(QueryHelpers.AddQueryString(this.BaseAddress + url, queryParam));
                string[] uri = newUrl.ToString().Split(this.BaseAddress);
                var response = await client.PostAsync(uri[1], postData);
                if (response.IsSuccessStatusCode)
                {
                    httpResponse.Success = true;
                }
                else throw new Exception();
            }
            catch (Exception ex)
            {
                httpResponse.Success = false;
                httpResponse.Error = ex.Message;
            }
            return httpResponse;
        }

        public async Task<HttpRequestResponse> PutRequest(string url, object data, string contentType, string token = null, Dictionary<string, string> queryParam = null)
        {
            HttpRequestResponse httpResponse = new HttpRequestResponse();
            try
            {
                var clientHandler = new HttpClientHandler();

                var client = new HttpClient(clientHandler);

                if (token != null)
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                }
                var serializeData = JsonConvert.SerializeObject(data);
                var postData = new StringContent(serializeData, Encoding.UTF8, contentType);
                client.BaseAddress = new Uri(this.BaseAddress);
                if (queryParam == null)
                {
                    queryParam = new Dictionary<string, string>();
                }
                var newUrl = new Uri(QueryHelpers.AddQueryString(this.BaseAddress + url, queryParam));
                string[] uri = newUrl.ToString().Split(this.BaseAddress);
                var response = await client.PutAsync(uri[1], postData);
                if (response.IsSuccessStatusCode)
                {
                    httpResponse.Success = true;
                }
                else throw new Exception();
            }
            catch (Exception ex)
            {
                httpResponse.Success = false;
                httpResponse.Error = ex.Message;
            }
            return httpResponse;
        }
    }
}
