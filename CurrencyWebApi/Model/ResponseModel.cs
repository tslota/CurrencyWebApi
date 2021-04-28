using System.Text.Json.Serialization;

namespace CurrencyWebApi.Model
{
    public class ResponseModel
    {
        [JsonPropertyName("standard_deviation")]
        public double StandardDeviation { get; set; }


        [JsonPropertyName("average_price")]
        public double AveragePrice { get; set; }


    }
}