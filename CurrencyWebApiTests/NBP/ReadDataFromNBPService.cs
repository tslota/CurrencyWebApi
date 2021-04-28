using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using CurrencyWebApi;
using CurrencyWebApi.Model;
using NUnit.Framework;

namespace CurrencyWebApiTests.NBP
{
    [TestFixture]
    public class ReadDataFromNBPService
    {
        private string _url;

        [SetUp]
        public void Setup()
        {
            _url = $"http://api.nbp.pl/api/exchangerates/rates/c/EUR/2013-01-28/2013-01-31/";
        }

        [Test]
       
        public async Task ReadDataFromNBP()
        {
            var reader = new RestReader();
            var ret = await reader.ReadDataAsync<NBPCurrencyResponse>(_url);
            Assert.That(ret, Is.Not.Null);
            Assert.That(ret.Code.ToLower(),Is.EqualTo("EUR".ToLower()));
        }

    }
}