using Blackbird.Applications.Sdk.Common;

namespace Apps.Wise.Models.Request.Transfer;

public class CreateTransferRequest
{
    [Display("Target account ID")] public string TargetAccount { get; set; }

    [Display("Quote UUID")] public string QuoteUuid { get; set; }
    
    [Display("Customer transaction ID")] public string CustomerTransactionId { get; set; }

    [Display("Source account ID")] public string? SourceAccount { get; set; }
    
    public TransferDetails? Details { get; set; }
}