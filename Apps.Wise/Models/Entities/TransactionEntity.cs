using Blackbird.Applications.Sdk.Common;

namespace Apps.Wise.Models.Entities;

public class TransactionEntity
{
    [Display("Transaction ID")]
    public string Id { get; set; }
    
    [Display("Card token")]
    public string CardToken { get; set; }
    
    public string Type { get; set; }
    
    public string State { get; set; }
    
    [Display("Created date")]
    public DateTime CreatedDate { get; set; }
}