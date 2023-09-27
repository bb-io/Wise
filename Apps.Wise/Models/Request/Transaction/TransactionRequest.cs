using Apps.Wise.Models.Request.Profile;
using Blackbird.Applications.Sdk.Common;

namespace Apps.Wise.Models.Request.Transaction;

public class TransactionRequest : ProfileRequest
{
    [Display("Transaction ID")]
    public string TransactionId { get; set; }   
}