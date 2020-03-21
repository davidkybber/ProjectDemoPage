using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjectDemoPage.Models;

namespace ProjectDemoPage.Controllers
{
    public class CurrencyController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CurrencyController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult Converter()
        {
            return View(new CurrencyConverterModel());
        }

        [HttpPost]
        public IActionResult Converter(CurrencyConverterModel model)
        {
            if (model.CurrencyFrom == model.CurrencyTo)
            {
                ModelState.AddModelError(string.Empty, "Cannot convert currency to itself");
            }

            if (string.IsNullOrEmpty(model.CurrencyFrom) || string.IsNullOrEmpty(model.CurrencyTo))
            {
                ModelState.AddModelError(string.Empty, "Cannot convert empty currencies");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }           

            var response = Get(model.CurrencyFrom);

            model.rate = (double)GetPropValue(response.Result.rates, model.CurrencyTo);
            model.ConvertedValue = model.Quantity * model.rate; 

            return View(model);
        }

        public async Task<CurrencyApiModel> Get(string currencyFrom)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, 
                "https://api.exchangeratesapi.io/latest?base=" + currencyFrom);
            var client = _httpClientFactory.CreateClient();

            var response = await client.SendAsync(request);

            var task = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<CurrencyApiModel>(task);
        }

        public static object GetPropValue(object src, string propName)
        {
            return src.GetType().GetProperty(propName).GetValue(src, null);
        }
    }
}