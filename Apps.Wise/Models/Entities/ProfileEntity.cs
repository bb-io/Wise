using Blackbird.Applications.Sdk.Common;

namespace Apps.Wise.Models.Entities;

public class ProfileEntity
{
    [Display("Profile ID")]
    public string Id { get; set; }
    
    [Display("Full name")]
    public string FullName { get; set; }
    
    [Display("User ID")]
    public string UserId { get; set; }
    
    public string Type { get; set; }
    
    public string Email { get; set; }
    
    [Display("Created at")]
    public DateTime CreatedAt { get; set; }
    
    [Display("Current state")]
    public string CurrentState { get; set; }
}