using Apps.Wise.Models.Request.Profile;
using Blackbird.Applications.Sdk.Common;

namespace Apps.Wise.Models.Request.Card;

public class CardRequest : ProfileRequest
{
    [Display("Card token")]
    public string CardToken { get; set; }
}