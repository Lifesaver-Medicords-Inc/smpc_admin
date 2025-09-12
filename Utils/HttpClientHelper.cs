using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using smpc_admin.Pages.Shared;

namespace smpc_admin.Utils
{
    class HttpClientHelper
    {
        private static readonly CookieContainer cookieContainer = new CookieContainer();

        public static string SessionToken { get; set; } = "";

        private static readonly HttpClientHandler handler = new HttpClientHandler
        {
            CookieContainer = cookieContainer
        };

        private static readonly HttpClient client = new HttpClient(handler)
        {
            BaseAddress = new Uri($"{Program.Configuration["AppSettings:ApiBaseUrl"]}")
        };

        private static async Task<T> SendRequestAsync<T>(string url, HttpMethod method, string body = null)
        {
            try
            {
                LoaderIndicatorOverlay.ShowOverlay();
                HttpContent content = null;

                if (!string.IsNullOrEmpty(body) && method != HttpMethod.Get)
                {
                    content = new StringContent(body, Encoding.UTF8, "application/json");
                }

                var requestMessage = new HttpRequestMessage(method, url)
                {
                    Content = content
                };

                // Add Authorization header if token is present
                if (!string.IsNullOrWhiteSpace(SessionToken))
                {
                    if (client.DefaultRequestHeaders.Contains("Authorization"))
                        client.DefaultRequestHeaders.Remove("Authorization");

                    client.DefaultRequestHeaders.Add("Authorization", SessionToken);
                }

                var response = await client.SendAsync(requestMessage);

                string responseContent = await response.Content.ReadAsStringAsync();

                // If not authenticated yet, try to get token from cookie
                if (string.IsNullOrEmpty(SessionToken) && response.Headers.Contains("Set-Cookie"))
                {
                    var cookies = response.Headers.GetValues("Set-Cookie").ToList();
                    string token = ExtractToken(cookies.FirstOrDefault());
                    SessionToken = token;
                }

                if (response.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<T>(responseContent);
                }
                else
                {
                    Log.Warning("API request failed: {Url}, StatusCode: {StatusCode}, Response: {Response}",
                        url, response.StatusCode, responseContent);
                    return JsonConvert.DeserializeObject<T>(responseContent);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Exception during API request: {Url}", url);
                return default;
            }
            finally
            {
                LoaderIndicatorOverlay.HideOverlay();
            }
        }

        public static async Task<T> PostMultipartAsync<T>(string url, HttpContent content)
        {
            try
            {
                LoaderIndicatorOverlay.ShowOverlay();

                var requestMessage = new HttpRequestMessage(HttpMethod.Post, url)
                {
                    Content = content
                };

                if (!string.IsNullOrWhiteSpace(SessionToken))
                {
                    if (client.DefaultRequestHeaders.Contains("Authorization"))
                        client.DefaultRequestHeaders.Remove("Authorization");

                    client.DefaultRequestHeaders.Add("Authorization", SessionToken);
                }

                var response = await client.SendAsync(requestMessage);

                string responseContent = await response.Content.ReadAsStringAsync();

                if (string.IsNullOrEmpty(SessionToken) && response.Headers.Contains("Set-Cookie"))
                {
                    var cookies = response.Headers.GetValues("Set-Cookie").ToList();
                    string token = ExtractToken(cookies.FirstOrDefault());
                    SessionToken = token;
                }

                if (response.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<T>(responseContent);
                }
                else
                {
                    Log.Warning("API request failed: {Url}, StatusCode: {StatusCode}, Response: {Response}",
                        url, response.StatusCode, responseContent);
                    return JsonConvert.DeserializeObject<T>(responseContent);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Exception during API request: {Url}", url);
                return default;
            }
            finally
            {
                LoaderIndicatorOverlay.HideOverlay();
            }
        }



        public static async Task<T> Get<T>(string url) => await SendRequestAsync<T>(url, HttpMethod.Get);

        public static async Task<T> Post<T>(string url, object payload)
        {
            string json = JsonConvert.SerializeObject(payload);
            return await SendRequestAsync<T>(url, HttpMethod.Post, json);
        }

        public static async Task<T> Put<T>(string url, object payload)
        {
            string json = JsonConvert.SerializeObject(payload);
            return await SendRequestAsync<T>(url, HttpMethod.Put, json);
        }

        public static async Task<T> Delete<T>(string url, object payload = null)
        {
            string json = payload != null ? JsonConvert.SerializeObject(payload) : null;
            return await SendRequestAsync<T>(url, HttpMethod.Delete, json);
        }

        private static string ExtractToken(string cookieString)
        {
            if (string.IsNullOrEmpty(cookieString))
                return "";

            int tokenStartIndex = cookieString.IndexOf("Authorization=") + "Authorization=".Length;
            if (tokenStartIndex < "Authorization=".Length) return "";

            int tokenEndIndex = cookieString.IndexOf(";", tokenStartIndex);

            if (tokenEndIndex == -1)
                return cookieString.Substring(tokenStartIndex);

            return cookieString.Substring(tokenStartIndex, tokenEndIndex - tokenStartIndex);
        }
    }
}
