using Blackbird.Applications.Sdk.Common;

namespace Apps.Wise.Models.Entities;

public class CardEntity
{
    public string Token { get; set; }
    
    [Display("Profile ID")]
    public string ProfileId { get; set; }
    
    [Display("Client ID")]
    public string ClientId { get; set; }
    
    [Display("Card holder name")]
    public string CardHolderName { get; set; }
    
    [Display("Expiry date")]
    public DateTime ExpiryDate { get; set; }
    
    [Display("Last four digits")]
    public string LastFourDigits { get; set; }
    
    [Display("Bank identification number")]
    public string BankIdentificationNumber { get; set; }
    
    [Display("Phone number")]
    public string PhoneNumber { get; set; }
    
    [Display("Creation time")]
    public DateTime CreationTime { get; set; }
}