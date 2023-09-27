using Apps.Wise.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.Wise.Models.Request.Profile;

public class ProfileRequest
{
    [Display("Profile")]
    [DataSource(typeof(ProfileDataHandler))]
    public string ProfileId { get; set; }
}