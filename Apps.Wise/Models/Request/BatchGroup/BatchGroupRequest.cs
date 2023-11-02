using Blackbird.Applications.Sdk.Common;

namespace Apps.Wise.Models.Request.BatchGroup;

public class BatchGroupRequest
{
    [Display("Batch group ID")]
    public string BatchGroupId { get; set; }
}