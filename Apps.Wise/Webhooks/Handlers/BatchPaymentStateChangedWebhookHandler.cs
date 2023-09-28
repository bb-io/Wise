using Apps.Wise.Models.Request.Profile;
using Apps.Wise.Webhooks.Handlers.Base;
using Blackbird.Applications.Sdk.Common.Webhooks;

namespace Apps.Wise.Webhooks.Handlers;

public class BatchPaymentStateChangedWebhookHandler : WiseWebhookHandler
{
    protected override string Event => "batch-payment-initiations#state-change";

    public BatchPaymentStateChangedWebhookHandler([WebhookParameter] ProfileRequest profile) : base(profile)
    {
    }
}