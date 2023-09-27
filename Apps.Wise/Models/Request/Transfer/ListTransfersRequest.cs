using Apps.Wise.DataSourceHandlers;
using Apps.Wise.DataSourceHandlers.EnumHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.Wise.Models.Request.Transfer;

public class ListTransfersRequest
{
    [Display("Profile")]
    [DataSource(typeof(ProfileDataHandler))]
    public string? ProfileId { get; set; }
    
    [DataSource(typeof(TransferStatusDataHandler))]
    public string? Status { get; set; }

    [Display("Source currency")]
    [DataSource(typeof(CurrencyDataHandler))]
    public string? SourceCurrency { get; set; }

    [Display("Target currency")]
    [DataSource(typeof(CurrencyDataHandler))]
    public string? TargetCurrency { get; set; }
}