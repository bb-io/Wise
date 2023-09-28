using Apps.Wise.DataSourceHandlers;
using Apps.Wise.DataSourceHandlers.EnumHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Blackbird.Applications.Sdk.Utils.Json.Converters;
using Newtonsoft.Json;

namespace Apps.Wise.Models.Request.Quote;

public class CreateQuoteRequest
{
    [Display("Source currency")]
    [DataSource(typeof(CurrencyDataHandler))]
    public string SourceCurrency { get; set; }
    
    [Display("Target currency")]
    [DataSource(typeof(CurrencyDataHandler))]
    public string TargetCurrency { get; set; }
    
    [Display("Source amount")]
    public decimal? SourceAmount { get; set; }
    
    [Display("Target amount")]
    public decimal? TargetAmount { get; set; }
    
    [Display("Target account")]
    [JsonConverter(typeof(StringToIntConverter), nameof(TargetAccount))]
    [DataSource(typeof(AccountDataHandler))]
    public string? TargetAccount { get; set; }
    
    [Display("Pay out")]
    [DataSource(typeof(PayOutDataHandler))]
    public string? PayOut { get; set; }
    
    [Display("Preferred pay in")]
    public string? PreferredPayIn { get; set; }
}