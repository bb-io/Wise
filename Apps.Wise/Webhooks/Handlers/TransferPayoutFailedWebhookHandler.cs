using Apps.Wise.Models.Request.Profile;
using Apps.Wise.Webhooks.Handlers.Base;
using Blackbird.Applications.Sdk.Common.Webhooks;

namespace Apps.Wise.Webhooks.Handlers;

public class TransferPayoutFailedWebhookHandler : WiseWebhookHandler
{
    protected override string Event => "transfers#payout-failure";

    public TransferPayoutFailedWebhookHandler([WebhookParameter] ProfileRequest profile) : base(profile)
    {
    }
}