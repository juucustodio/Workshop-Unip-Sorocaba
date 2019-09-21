using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DemoApp.Models;
using Newtonsoft.Json;

namespace DemoApp.Services
{

    public class RestClient
    {
        public TimeSpan Timeout { get; set; }
        public string UrlBase { get; set; }

        public RestClient()
        {
            Timeout = new TimeSpan(0, 0, 0, 30); // 30 segundos

            UrlBase = "https://dog.ceo/api/breed/hound/images/random";
        }


        public async Task<T> Get<T>(string url = null, Dictionary<string, string> headers = null, Dictionary<string, string> parameters = null)
        {
            using (var client = new HttpClient())
            {
                client.Timeout = Timeout;

                var request = CreateRequest(HttpMethod.Get, url, headers, parameters);
                var result = await client.SendAsync(request);

                if (!result.IsSuccessStatusCode)
                    throw new Exception(result.Content.ReadAsStringAsync().Result);

                var json = result.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<T>(json);

                return data;
            }
        }

        public async Task<IList<T>> GetList<T>(string url = null, Dictionary<string, string> headers = null, Dictionary<string, string> parameters = null)
        {
            using (var client = new HttpClient())
            {
                client.Timeout = Timeout;

                var request = CreateRequest(HttpMethod.Get, url, headers, parameters);
                var result = await client.SendAsync(request);

                if (!result.IsSuccessStatusCode)
                    throw new Exception(result.Content.ReadAsStringAsync().Result);

                var json = result.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<IEnumerable<T>>(json);

                return data.ToList();
            }
        }

        public async Task<T> Post<T>(T objectToPost, string url = null, Dictionary<string, string> headers = null)
        {
            using (var client = new HttpClient())
            {
                client.Timeout = Timeout;

                var request = CreateRequest(HttpMethod.Post, url, headers);

                request.Content = new StringContent(JsonConvert.SerializeObject(objectToPost), Encoding.UTF8, "application/json");

                var result = await client.SendAsync(request);

                if (!result.IsSuccessStatusCode)
                    throw new Exception(result.Content.ReadAsStringAsync().Result);

                var json = result.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<T>(json);

                return data;
            }
        }

        public async Task<T> Post<T>(string url = null, Dictionary<string, string> headers = null)
        {
            using (var client = new HttpClient())
            {
                client.Timeout = Timeout;

                var request = CreateRequest(HttpMethod.Post, url, headers);

                var result = await client.SendAsync(request);

                if (!result.IsSuccessStatusCode)
                    throw new Exception(result.Content.ReadAsStringAsync().Result);

                var json = result.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<T>(json);

                return data;
            }
        }

        public async Task<T> Put<T>(T objectToPut, string url = null, Dictionary<string, string> headers = null)
        {
            using (var client = new HttpClient())
            {
                client.Timeout = Timeout;

                var request = CreateRequest(HttpMethod.Put, url, headers);

                request.Content = new StringContent(JsonConvert.SerializeObject(objectToPut), Encoding.UTF8, "application/json");

                var result = await client.SendAsync(request);

                if (!result.IsSuccessStatusCode)
                    throw new Exception(result.Content.ReadAsStringAsync().Result);

                var json = result.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<T>(json);

                return data;
            }
        }

        public async Task<T> Put<T>(string url = null, Dictionary<string, string> headers = null)
        {
            using (var client = new HttpClient())
            {
                client.Timeout = Timeout;

                var request = CreateRequest(HttpMethod.Put, url, headers);

                var result = await client.SendAsync(request);

                if (!result.IsSuccessStatusCode)
                    throw new Exception(result.Content.ReadAsStringAsync().Result);

                var json = result.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<T>(json);

                return data;
            }
        }

        public async Task<bool> Delete(string url, Dictionary<string, string> headers = null)
        {
            using (var client = new HttpClient())
            {
                client.Timeout = Timeout;

                var request = CreateRequest(HttpMethod.Delete, url, headers);
                var result = await client.SendAsync(request);

                if (!result.IsSuccessStatusCode)
                    throw new Exception(result.Content.ReadAsStringAsync().Result);

                return result.IsSuccessStatusCode;
            }
        }

        #region Create Request

        protected HttpRequestMessage CreateRequest(HttpMethod method, string url = null, Dictionary<string, string> headers = null, Dictionary<string, string> parameters = null)
        {
            if (url != null && !UrlBase.EndsWith("/") && !url.StartsWith("/"))
                url = "/" + url;

            var request = new HttpRequestMessage
            {
                RequestUri = new Uri(UrlBase + url + BuildQueryString(parameters)),
                Method = method
            };

            AddHeaders(request, headers);
            return request;
        }

        private static void AddHeaders(HttpRequestMessage request, Dictionary<string, string> headers)
        { 

            if (headers == null)
                return;

            foreach (var h in headers)
                request.Headers.Add(h.Key, h.Value);
        }

        private static string BuildQueryString(Dictionary<string, string> parameters)
        {
            if (parameters == null || !parameters.Any())
                return null;

            var list = parameters.Select(item => item.Key + "=" + item.Value).ToList();
            var queryString = "?" + string.Join("&", list);
            return queryString;
        }

        #endregion
    }
}