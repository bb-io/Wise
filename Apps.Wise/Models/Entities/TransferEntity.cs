using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Utils.Extensions.String;

namespace Apps.Wise.Models.Entities;

public class TransferEntity
{
    [Display("Transfer ID")] public string Id { get; set; }

    [Display("User ID")] public string User { get; set; }

    [Display("Customer transaction ID")] public string CustomerTransactionId { get; set; }

    [Display("Target account ID")] public string? TargetAccount { get; set; }

    //[Display("Source account ID")] public string? SourceAccount { get; set; }

    //[Display("Quote ID (v1)")] public string? Quote { get; set; }

    [Display("Quote UUID (v2)")] public string? QuoteUuid { get; set; }

    public string? Status { get; set; }

    public string? Reference { get; set; }

    public double? Rate { get; set; }

    [Display("Created date")] public DateTime? Created { get; set; }

    [Display("Source currency")] public string SourceCurrency { get; set; }

    [Display("Target currency")] public string TargetCurrency { get; set; }

    [Display("Source value")] public double SourceValue { get; set; }

    [Display("Target value")] public double TargetValue { get; set; }

    [Display("Has active issues")] public bool HasActiveIssues { get; set; }

    public string GetDynamicDisplay() =>
        string.IsNullOrWhiteSpace(Reference) ? $"{SourceCurrency}->{TargetCurrency} {Status?.ToPascalCase()}" : Reference;
}