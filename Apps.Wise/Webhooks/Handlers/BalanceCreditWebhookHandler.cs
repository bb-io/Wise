using Apps.Wise.Models.Request.Profile;
using Apps.Wise.Webhooks.Handlers.Base;
using Blackbird.Applications.Sdk.Common.Webhooks;

namespace Apps.Wise.Webhooks.Handlers;

public class BalanceCreditWebhookHandler : WiseWebhookHandler
{
    protected override string Event => "balances#credit";

    public BalanceCreditWebhookHandler([WebhookParameter] ProfileRequest profile) : base(profile)
    {
    }
}