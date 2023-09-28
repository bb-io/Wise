using Blackbird.Applications.Sdk.Common;

namespace Apps.Wise.Webhooks.Models.Transfer;

public class TransferActiveCasesPayload
{
    public TransferResource Resource { get; set; }

    [Display("Active cases")]
    public IEnumerable<string> ActiveCases { get; set; }
}