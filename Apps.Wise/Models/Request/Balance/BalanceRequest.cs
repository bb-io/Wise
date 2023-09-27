using Apps.Wise.Models.Request.Profile;
using Blackbird.Applications.Sdk.Common;

namespace Apps.Wise.Models.Request.Balance;

public class BalanceRequest : ProfileRequest
{
    [Display("Balance ID")]
    public string BalanceId { get; set; }
}