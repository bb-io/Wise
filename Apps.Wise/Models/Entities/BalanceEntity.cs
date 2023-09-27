using Blackbird.Applications.Sdk.Common;

namespace Apps.Wise.Models.Entities;

public class BalanceEntity
{
    [Display("Balance ID")]
    public string Id { get; set; }
    
    public string Currency { get; set; }
    
    public string Type { get; set; }
    
    [Display("Investment state")]
    public string InvestmentState { get; set; }
    
    public string? Name { get; set; }
    
    public bool Visible { get; set; }
    
    public bool Primary { get; set; }
    
    [Display("Creation time")]
    public DateTime CreationTime { get; set; }
    
    public MoneyAmountEntity Amount { get; set; }
    
    [Display("Reserved amount")]
    public MoneyAmountEntity ReservedAmount { get; set; }
    
    [Display("Cash amount")]
    public MoneyAmountEntity CashAmount { get; set; }
    
    [Display("Total amount")]
    public MoneyAmountEntity TotalWorth { get; set; }
}