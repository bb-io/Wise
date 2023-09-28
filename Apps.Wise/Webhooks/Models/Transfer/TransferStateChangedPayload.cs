using Blackbird.Applications.Sdk.Common;

namespace Apps.Wise.Webhooks.Models.Transfer;

public class TransferStateChangedPayload
{
    public TransferResource Resource { get; set; }
    
    [Display("Current state")]
    public string CurrentState { get; set; }
    
    [Display("Previous state")]
    public string PreviousState { get; set; }
    
    [Display("Occurred at")] public DateTime OccurredAt { get; set; }
}