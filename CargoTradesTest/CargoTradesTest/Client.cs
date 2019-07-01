using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Shared;

namespace CargoTradesTest
{
    public class Client
    {
        private HttpClient httpClient = new HttpClient();
        private Settings settings = new Settings();

        public Client()
        {
            httpClient.BaseAddress = new Uri(settings.Host);
        }

        public void SendData(MyData data)
        {
            var content = new StringContent(JObject.FromObject(data).ToString(Formatting.None), Encoding.UTF8, "application/json");
            var res = httpClient.PostAsync(settings.SendDataMethod, content).GetAwaiter().GetResult();
        }

        public async Task<string> GetData()
        {
            var result = await httpClient.GetAsync(settings.GetDataMethod);
            if (result.IsSuccessStatusCode)
                return await result.Content.ReadAsStringAsync();

            return null;
        }
    }
}