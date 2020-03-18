using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProjectDemoPage.Models
{
    public class CurrencyConverterModel
    {
        [Required]
        [Range(1, 100000000000)]
        public double Quantity { get; set; }

        [Required]
        [StringLength(3, MinimumLength = 3)]
        [CurrencyCode("EUR", "NOK","CAD","HKD","ISK","PHP","DKK","HUF","CZK","GBP","RON","SEK",
"IDR","INR","BRL","RUB","HRK","JPY","THB","CHF","EUR","MYR","BGN","TRY","CNY","NOK","NZD","ZAR","USD","MXN",
"SGD", "AUD","ILS", "KRW", "PLN")]
        [Display(Name = "Currency From")]
        public string CurrencyFrom { get; set; }

        [Required]
        [StringLength(3, MinimumLength = 3)]
        [CurrencyCode("EUR", "NOK","CAD","HKD","ISK","PHP","DKK","HUF","CZK","GBP","RON","SEK",
"IDR","INR","BRL","RUB","HRK","JPY","THB","CHF","EUR","MYR","BGN","TRY","CNY","NOK","NZD","ZAR","USD","MXN",
"SGD", "AUD","ILS", "KRW", "PLN")]
        [Display(Name = "Currency To")]
        public string CurrencyTo { get; set; }

        public double rate { get; set; } 

        public double ConvertedValue { get; set; } = 0;

        public bool IsValid { get; set; }

        public SelectListItem[] CurrencyCodes { get; } = 
        {
            new SelectListItem{Text="CAD", Value="CAD"},
            new SelectListItem{Text="HKD", Value="HKD"},
            new SelectListItem{Text="ISK", Value="ISK"},
            new SelectListItem{Text="PHP", Value="PHP"},
            new SelectListItem{Text="DKK", Value="DKK"},
            new SelectListItem{Text="HUF", Value="HUF"},
            new SelectListItem{Text="CZK", Value="CZK"},
            new SelectListItem{Text="GBP", Value="GBP"},
            new SelectListItem{Text="RON", Value="RON"},
            new SelectListItem{Text="SEK", Value="SEK"},
            new SelectListItem{Text="IDR", Value="IDR"},
            new SelectListItem{Text="INR", Value="INR"},
            new SelectListItem{Text="BRL", Value="BRL"},
            new SelectListItem{Text="RUB", Value="RUB"},
            new SelectListItem{Text="HRK", Value="HRK"},
            new SelectListItem{Text="JPY", Value="JPY"},
            new SelectListItem{Text="THB", Value="THB"},
            new SelectListItem{Text="CHF", Value="CHF"},
            new SelectListItem{Text="EUR", Value="EUR"},
            new SelectListItem{Text="MYR", Value="MYR"},
            new SelectListItem{Text="BGN", Value="BGN"},
            new SelectListItem{Text="TRY", Value="TRY"},
            new SelectListItem{Text="CNY", Value="CNY"},
            new SelectListItem{Text="NOK", Value="NOK"},
            new SelectListItem{Text="NZD", Value="NZD"},
            new SelectListItem{Text="ZAR", Value="ZAR"},
            new SelectListItem{Text="USD", Value="USD"},
            new SelectListItem{Text="MXN", Value="MXN"},
            new SelectListItem{Text="SGD", Value="SGD"},
            new SelectListItem{Text="AUD", Value="AUD"},
            new SelectListItem{Text="ILS", Value="ILS"},
            new SelectListItem{Text="KRW", Value="KRW"},
            new SelectListItem{Text="PLN", Value="PLN"},
        };
    }
}