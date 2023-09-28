using Blackbird.Applications.Sdk.Common;

namespace Apps.Wise.Webhooks.Models.Payment;

public class BatchPaymentStateChangedResource
{
    [Display("Payment initiation ID")] public string Id { get; set; }

    [Display("Batch group ID")] public string BatchGroupId { get; set; }

    [Display("Profile ID")] public string ProfileId { get; set; }
}