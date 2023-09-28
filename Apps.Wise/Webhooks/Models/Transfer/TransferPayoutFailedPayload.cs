using Blackbird.Applications.Sdk.Common;

namespace Apps.Wise.Webhooks.Models.Transfer;

public class TransferPayoutFailedPayload
{
    [Display("Transfer ID")] public string TransferId { get; set; }

    [Display("Profile ID")] public string ProfileId { get; set; }

    [Display("Failure reason code")] public string FailureReasonCode { get; set; }

    [Display("Failure description")] public string FailureDescription { get; set; }

    [Display("Occurred at")] public DateTime OccurredAt { get; set; }
}