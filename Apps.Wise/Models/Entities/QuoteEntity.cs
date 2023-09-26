using Blackbird.Applications.Sdk.Common;

namespace Apps.Wise.Models.Entities;

public class QuoteEntity
{
    [Display("Quote ID")]
    public string Id { get; set; }
    
    [Display("Source currency")]
    public string SourceCurrency { get; set; }
    
    [Display("Target currency")]
    public string TargetCurrency { get; set; }
    
    public double Rate { get; set; }
    
    [Display("Rate type")]
    public string RateType { get; set; }
    
    public string Status { get; set; }
    
    [Display("Created time")]
    public DateTime CreatedTime { get; set; }
    
    [Display("Rate expiration time")]
    public DateTime RateExpirationTime { get; set; }
    
    [Display("Expiration time")]
    public DateTime ExpirationTime { get; set; }
    
    [Display("Profile ID")]
    public string Profile { get; set; }
    
    [Display("User ID")]
    public string User { get; set; }
    
    public IEnumerable<NoticeEntity> Notices { get; set; }
}