using Blackbird.Applications.Sdk.Common;

namespace Apps.Wise.Webhooks.Models.Payment;

public class BatchPaymentStateChangedPayload
{
    public BatchPaymentStateChangedResource Resource { get; set; }

    [Display("Previous status")] public string PreviousStatus { get; set; }

    [Display("New status")] public string NewStatus { get; set; }

    [Display("Return code")] public string ReturnCode { get; set; }

    [Display("Occurred at")] public DateTime OccurredAt { get; set; }
}