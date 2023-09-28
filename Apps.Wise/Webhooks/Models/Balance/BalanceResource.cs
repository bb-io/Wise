using Blackbird.Applications.Sdk.Common;

namespace Apps.Wise.Webhooks.Models.Balance;

public class BalanceResource
{
    [Display("Account ID")]
    public string Id { get; set; }
    
    [Display("Profile ID")]
    public string ProfileId { get; set; }
    
    public string Type { get; set; }
}