using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CurrencyWebApi.Extensions;
using CurrencyWebApi.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Filters;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CurrencyWebApi.Controllers
{

    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly IRestReader _reader;
        private readonly ILogger<CurrencyController> _logger;
        private readonly string _nbpUrl;

        public CurrencyController(IConfiguration configuration, IRestReader reader, ILogger<CurrencyController> logger)
        {
            _reader = reader;
            _logger = logger;
            _nbpUrl = configuration["NBPUrl"];
        }
      
        /// <summary>
        /// Method for reading an average and standard deviation for ask currencies values from NBP
        /// </summary>
        /// <param name="currency">Currency name, ir EUR, USD</param>
        /// <param name="startdate">Start date in format YYYY-MM-DD</param>
        /// <param name="enddate">End date in format YYYY-MM-DD</param>
        /// <returns>Retuns JSON in format:
        /// {
        ///  average_price : 'decimal'
        ///  standard_deviation: 'decimal'
        /// 
        /// }</returns>
        [HttpGet("{currency}/{startdate}/{enddate}")]

        public async Task<IActionResult> Get(string currency, string startdate, string enddate)
        {
            try
            {
                var url = $"{_nbpUrl}/{currency}/{startdate}/{enddate}";
                var result = await _reader.ReadDataAsync<NBPCurrencyResponse>(url);

                var avg = result.Rates.Average(a => a.Ask);
                var stdDev = result.Rates.StandardDeviation(a => a.Ask);

                return Ok(new ResponseModel()
                {
                    AveragePrice = Math.Round(avg, 4),
                    StandardDeviation = Math.Round(stdDev, 4)
                });
            }
            catch (Exception e)
            {
                _logger.LogError("Cannot read currency data.",e);
                return BadRequest();
            }
        }




    }







}
