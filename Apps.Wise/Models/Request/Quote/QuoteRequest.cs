using Apps.Wise.Models.Request.Profile;
using Blackbird.Applications.Sdk.Common;

namespace Apps.Wise.Models.Request.Quote;

public class QuoteRequest : ProfileRequest
{
    [Display("Quote ID")]
    public string QuoteId { get; set; }
}