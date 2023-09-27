using Apps.Wise.Models.Request.Profile;
using Apps.Wise.Webhooks.Handlers.Base;
using Blackbird.Applications.Sdk.Common.Webhooks;

namespace Apps.Wise.Webhooks.Handlers;

public class TransferStatusChangedWebhookHandler : WiseWebhookHandler
{
    protected override string Event => "transfers#state-change";

    public TransferStatusChangedWebhookHandler([WebhookParameter] ProfileRequest profile) : base(profile)
    {
    }
}