using Blackbird.Applications.Sdk.Common;

namespace Apps.Wise.Models.Request.Transfer;

public class TransferDetails
{
    public string? Reference { get; set; }

    [Display("Transfer purpose")] public string? TransferPurpose { get; set; }

    [Display("Transfer purpose sub transfer purpose")]
    public string? TransferPurposeSubTransferPurpose { get; set; }

    [Display("Source of funds")] public string? SourceOfFunds { get; set; }
}