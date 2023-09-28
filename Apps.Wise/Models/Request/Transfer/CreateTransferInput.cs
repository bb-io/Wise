using Apps.Wise.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.Wise.Models.Request.Transfer;

public class CreateTransferInput
{
    [Display("Target account")]
    [DataSource(typeof(AccountDataHandler))]
    public string TargetAccount { get; set; }

    [Display("Transaction identifier")] public string? TransactionIdentifier { get; set; }

    [Display("Source account ID")]
    [DataSource(typeof(AccountDataHandler))]
    public string? SourceAccount { get; set; }

    public string? Reference { get; set; }

    [Display("Transfer purpose")] public string? TransferPurpose { get; set; }

    [Display("Transfer purpose sub transfer purpose")]
    public string? TransferPurposeSubTransferPurpose { get; set; }

    [Display("Source of funds")] public string? SourceOfFunds { get; set; }
}