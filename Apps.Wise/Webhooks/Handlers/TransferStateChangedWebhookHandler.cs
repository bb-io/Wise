using Apps.Wise.Models.Request.Profile;
using Apps.Wise.Webhooks.Handlers.Base;
using Blackbird.Applications.Sdk.Common.Webhooks;

namespace Apps.Wise.Webhooks.Handlers;

public class TransferStateChangedWebhookHandler : WiseWebhookHandler
{
    protected override string Event => "transfers#state-change";

    public TransferStateChangedWebhookHandler([WebhookParameter] ProfileRequest profile) : base(profile)
    {
    }
}