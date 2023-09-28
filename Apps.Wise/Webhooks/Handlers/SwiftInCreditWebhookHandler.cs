using Apps.Wise.Models.Request.Profile;
using Apps.Wise.Webhooks.Handlers.Base;
using Blackbird.Applications.Sdk.Common.Webhooks;

namespace Apps.Wise.Webhooks.Handlers;

public class SwiftInCreditWebhookHandler : WiseWebhookHandler
{
    protected override string Event => "swift-in#credit";

    public SwiftInCreditWebhookHandler([WebhookParameter] ProfileRequest profile) : base(profile)
    {
    }
}