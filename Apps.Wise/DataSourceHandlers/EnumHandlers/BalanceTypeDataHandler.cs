using Blackbird.Applications.Sdk.Utils.Sdk.DataSourceHandlers;

namespace Apps.Wise.DataSourceHandlers.EnumHandlers;

public class BalanceTypeDataHandler : EnumDataHandler
{
    protected override Dictionary<string, string> EnumValues => new()
    {
        { "STANDARD", "Standard" },
        { "SAVINGS", "Savings" }
    };
}