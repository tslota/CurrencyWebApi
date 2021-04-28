using System;

namespace CurrencyWebApi.Model
{
    public class CurrencyRateModel

    {
        public string No { get; set; }
        public string EffectiveDate { get; set; }
        public double Bid { get; set; }
        public double Ask { get; set; }

    }
}