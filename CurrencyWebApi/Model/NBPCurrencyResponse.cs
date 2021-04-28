using System.Collections.Generic;

namespace CurrencyWebApi.Model
{
    public class NBPCurrencyResponse
    {
        public string Table { get; set; }
        public string Currency { get; set; }
        public string Code { get; set; }
        public List<CurrencyRateModel> Rates { get; set; }
    }
}