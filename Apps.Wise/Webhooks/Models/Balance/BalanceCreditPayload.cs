using Blackbird.Applications.Sdk.Common;

namespace Apps.Wise.Webhooks.Models.Balance;

public class BalanceCreditPayload
{
    public BalanceResource Resource { get; set; }
    
    [Display("Transaction type")]
    public string TransactionType { get; set; }
    
    public decimal Amount { get; set; }
    
    public string Currency { get; set; }
    
    [Display("Post transaction balance amount")]
    public decimal PostTransactionBalanceAmount { get; set; }
    
    [Display("Occurred at")]
    public DateTime OccurredAt { get; set; }
}