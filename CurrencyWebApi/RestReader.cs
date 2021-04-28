using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace CurrencyWebApi
{
    public interface IRestReader
    {
        Task<T> ReadDataAsync<T>(string url);
    }

    public class RestReader : IRestReader
    {
        public async Task<T> ReadDataAsync<T>(string url)
        {
            try
            {
                var client = new HttpClient();
                using var result = await client.GetAsync(url);
                if (result.IsSuccessStatusCode == false)
                {
                    throw new Exception("Cannot read data from server");
                }

                var json = await result.Content.ReadAsStringAsync();
                var obj = JsonSerializer.Deserialize<T>(json, new JsonSerializerOptions { IgnoreNullValues = true, PropertyNameCaseInsensitive = true });

                return obj;
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}