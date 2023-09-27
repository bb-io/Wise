using Blackbird.Applications.Sdk.Utils.Sdk.DataSourceHandlers;

namespace Apps.Wise.DataSourceHandlers.EnumHandlers;

public class TransferStatusDataHandler : EnumDataHandler
{
    protected override Dictionary<string, string> EnumValues => new()
    {
        { "incoming_payment_waiting", "Incoming payment waiting" },
        { "incoming_payment_initiated", "Incoming payment initiated" },
        { "processing", "Processing" },
        { "funds_converted", "Funds converted" },
        { "outgoing_payment_sent", "Outgoing payment sent" },
        { "cancelled", "Cancelled" },
        { "funds_refunded", "Funds refunded" },
        { "bounced_back", "Bounced back" },
        { "charged_back", "Charged back" },
        { "unknown", "Unknown" },
    };
}