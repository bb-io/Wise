using Blackbird.Applications.Sdk.Common;

namespace Apps.Wise.Webhooks.Models.Swift;

public class SwiftInCreditPayload
{
    public SwiftAction Action { get; set; }
    
    public SwiftResource Resource { get; set; }
    
    [Display("Occurred at")] public DateTime OccurredAt { get; set; }
    
}