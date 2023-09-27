using Apps.Wise.Api;
using Apps.Wise.Models.Entities;
using Apps.Wise.Models.Request.Profile;
using Apps.Wise.Models.Request.Webhook;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Common.Webhooks;
using Blackbird.Applications.Sdk.Utils.Extensions.Http;
using Newtonsoft.Json.Serialization;
using RestSharp;

namespace Apps.Wise.Webhooks.Handlers.Base;

public abstract class WiseWebhookHandler : IWebhookEventHandler
{
    protected abstract string Event { get; }

    private WiseRestClient Client { get; }
    private string ProfileId { get; }

    protected WiseWebhookHandler([WebhookParameter] ProfileRequest profile)
    {
        Client = new();
        ProfileId = profile.ProfileId;
    }

    public Task SubscribeAsync(IEnumerable<AuthenticationCredentialsProvider> creds,
        Dictionary<string, string> values)
    {
        var payload = new CreateWebhookRequest(Event, values["payloadUrl"]);

        var endpoint = $"/v3/profiles/{ProfileId}/subscriptions";
        var request = new WiseRestRequest(endpoint, Method.Post, creds)
            .WithJsonBody(payload, new()
            {
                ContractResolver = new DefaultContractResolver()
                {
                    NamingStrategy = new SnakeCaseNamingStrategy()
                }
            });

        return Client.ExecuteWithErrorHandling(request);
    }

    public async Task UnsubscribeAsync(IEnumerable<AuthenticationCredentialsProvider> creds,
        Dictionary<string, string> values)
    {
        var allWebhooks = await GetAllWebhooks(creds);
        var webhookToDelete = allWebhooks
            .FirstOrDefault(x => x.Delivery.Url == values["payloadUrl"]);

        if (webhookToDelete is null)
            return;

        var endpoint = $"v3/profiles/{ProfileId}/subscriptions/{webhookToDelete.Id}";
        var request = new WiseRestRequest(endpoint, Method.Delete, creds);

        await Client.ExecuteWithErrorHandling(request);
    }

    private Task<WebhookEntity[]> GetAllWebhooks(IEnumerable<AuthenticationCredentialsProvider> creds)
    {
        var endpoint = $"/v3/profiles/{ProfileId}/subscriptions";
        var request = new WiseRestRequest(endpoint, Method.Get, creds);

        return Client.ExecuteWithErrorHandling<WebhookEntity[]>(request);
    }
}