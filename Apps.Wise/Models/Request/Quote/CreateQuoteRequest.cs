using Blackbird.Applications.Sdk.Utils.Json.Converters;
using Newtonsoft.Json;

namespace Apps.Wise.Models.Request.Quote;

public class CreateQuoteRequest
{
    public string SourceCurrency { get; set; }

    public string TargetCurrency { get; set; }

    public decimal? SourceAmount { get; set; }

    public decimal? TargetAmount { get; set; }

    [JsonConverter(typeof(StringToIntConverter), nameof(TargetAccount))]
    public string? TargetAccount { get; set; }

    public string? PayOut { get; set; }

    public string? PreferredPayIn { get; set; }
    
    public CreateQuoteRequest(CreateQuoteInput quoteInput, string targetAccount)
    {
        SourceCurrency = quoteInput.SourceCurrency;
        TargetCurrency = quoteInput.TargetCurrency;
        SourceAmount = quoteInput.SourceAmount;
        TargetAmount = quoteInput.TargetAmount;
        PayOut = quoteInput.PayOut;
        PreferredPayIn = quoteInput.PreferredPayIn;
        TargetAccount = TargetAccount;
    }
}