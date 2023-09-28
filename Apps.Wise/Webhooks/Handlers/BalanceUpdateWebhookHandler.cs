using Apps.Wise.Models.Request.Profile;
using Apps.Wise.Webhooks.Handlers.Base;
using Blackbird.Applications.Sdk.Common.Webhooks;

namespace Apps.Wise.Webhooks.Handlers;

public class BalanceUpdateWebhookHandler : WiseWebhookHandler
{
    protected override string Event => "balances#update";

    public BalanceUpdateWebhookHandler([WebhookParameter] ProfileRequest profile) : base(profile)
    {
    }
}