using Apps.Wise.Models.Entities;
using Blackbird.Applications.Sdk.Common;

namespace Apps.Wise.Webhooks.Models.Swift;

public class SwiftResource
{
    [Display("UETR")] public string Uetr { get; set; }

    public UserPayload Recipient { get; set; }
    
    public UserPayload Sender { get; set; }
    
    [Display("Instructed amount")]
    public MoneyAmountEntity InstructedAmount { get; set; }
    
    [Display("Received amount")]
    public MoneyAmountEntity ReceivedAmount { get; set; }
    
    [Display("Credited amount")]
    public MoneyAmountEntity CreditedAmount { get; set; }
    
    public MoneyAmountEntity Fee { get; set; }
    
    public string Reference { get; set; }

    [Display("Exchange rate")] public decimal ExchangeRate { get; set; }

    [Display("Transaction time")] public DateTime TransactionTime { get; set; }
}