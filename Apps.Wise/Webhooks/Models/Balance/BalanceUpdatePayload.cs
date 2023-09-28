using Blackbird.Applications.Sdk.Common;

namespace Apps.Wise.Webhooks.Models.Balance;

public class BalanceUpdatePayload
{
    public BalanceResource Resource { get; set; }

    [Display("Transaction type")] public string TransactionType { get; set; }

    [Display("Transfer reference")] public string TransferReference { get; set; }

    [Display("Channel name")] public string ChannelName { get; set; }

    public decimal Amount { get; set; }

    public string Currency { get; set; }

    [Display("Occurred at")] public DateTime OccurredAt { get; set; }
}