using Apps.Wise.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.Wise.Models.Request.BatchGroup;

public class CreateBatchGroupRequest
{
    public string Name { get; set; }
    
    [Display("Source currency")]
    [DataSource(typeof(CurrencyDataHandler))]
    public string SourceCurrency { get; set; }
}