using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Serilog;

namespace smpc_admin.Helpers
{
    public static class HttpClientHelper
    {

        private static readonly HttpClient client = new HttpClient
        {
            BaseAddress = new Uri($"{Program.Configuration["AppSettings:ApiBaseUrl"]}") 
        };

        public static async Task<T> Get<T>(string url)
        {
            try
            {
                var response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(content);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "GET request failed: {Url}", url);
                return default;
            }
        }

        public static async Task<T> Post<T>(string url, object payload)
        {
            try
            {
                string json = JsonConvert.SerializeObject(payload);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(url, content);

                response.EnsureSuccessStatusCode();

                string responseContent = await response.Content.ReadAsStringAsync();
            
                return JsonConvert.DeserializeObject<T>(responseContent);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "POST request failed: {Url}", url);
                return default;
            }
        }

        public static async Task<T> Put<T>(string url, object payload)
        {
            try
            {
                string json = JsonConvert.SerializeObject(payload);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PutAsync(url, content);
                response.EnsureSuccessStatusCode();

                string responseContent = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(responseContent);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "PUT request failed: {Url}", url);
                return default;
            }
        }

        public static async Task<T> Delete<T>(string url, object payload = null)
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Delete, url);

                if (payload != null)
                {
                    string json = JsonConvert.SerializeObject(payload);
                    request.Content = new StringContent(json, Encoding.UTF8, "application/json");
                }

                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();

                string responseContent = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(responseContent);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "DELETE request failed: {Url}", url);
                return default;
            }
        }
    }
}
