using Apps.Wise.Models.Request.Profile;
using Apps.Wise.Webhooks.Handlers.Base;
using Blackbird.Applications.Sdk.Common.Webhooks;

namespace Apps.Wise.Webhooks.Handlers;

public class TransferActiveCasesWebhookHandler : WiseWebhookHandler
{
    protected override string Event => "transfers#active-cases";

    public TransferActiveCasesWebhookHandler([WebhookParameter] ProfileRequest profile) : base(profile)
    {
    }
}