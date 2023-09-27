using Blackbird.Applications.Sdk.Utils.Sdk.DataSourceHandlers;

namespace Apps.Wise.DataSourceHandlers.EnumHandlers;

public class PayOutDataHandler : EnumDataHandler
{
    protected override Dictionary<string, string> EnumValues => new()
    {
        { "BANK_TRANSFER", "Bank transfer" },
        { "BALANCE", "Balance" },
        { "SWIFT", "Swift" },
        { "SWIFT_OUR", "Swift our" },
        { "INTERAC", "Interac" }
    };
}