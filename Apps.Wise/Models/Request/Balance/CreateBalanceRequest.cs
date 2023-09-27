using Apps.Wise.DataSourceHandlers;
using Apps.Wise.DataSourceHandlers.EnumHandlers;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.Wise.Models.Request.Balance;

public class CreateBalanceRequest
{
    public string Name { get; set; }
    
    [DataSource(typeof(CurrencyDataHandler))]
    public string Currency { get; set; }
    
    [DataSource(typeof(BalanceTypeDataHandler))]
    public string Type { get; set; }
}