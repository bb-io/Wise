using Blackbird.Applications.Sdk.Common;

namespace Apps.Wise.Webhooks.Models.Transfer;

public class TransferResource
{
    [Display("Transfer ID")]
    public string Id { get; set; }
    
    [Display("Profile ID")]
    public string ProfileId { get; set; }
    
    [Display("Account ID")]
    public string AccountId { get; set; }
    
    public string Type { get; set; }
}