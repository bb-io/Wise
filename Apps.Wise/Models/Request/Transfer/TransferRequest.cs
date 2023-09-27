using Apps.Wise.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.Wise.Models.Request.Transfer;

public class TransferRequest
{
    [Display("Transfer")]
    [DataSource(typeof(TransferDataHandler))]
    public string TransferId { get; set; }
}