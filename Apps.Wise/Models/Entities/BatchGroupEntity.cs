using Blackbird.Applications.Sdk.Common;

namespace Apps.Wise.Models.Entities;

public class BatchGroupEntity
{
    [Display("Batch group ID")]
    public string Id { get; set; }
    
    public int Version { get; set; }
    
    public string Name { get; set; }
    
    [Display("Source currency")]
    public string SourceCurrency { get; set; }
    
    public string Status { get; set; }
    
    [Display("Transfer IDs")]
    public IEnumerable<string> TransferIds { get; set; }
}