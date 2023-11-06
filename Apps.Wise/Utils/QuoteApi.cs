using Apps.Wise.Api;
using Apps.Wise.Constants;
using Apps.Wise.Invocables;
using Apps.Wise.Models.Entities;
using Apps.Wise.Models.Request.Profile;
using Apps.Wise.Models.Request.Quote;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.Sdk.Utils.Extensions.Http;
using RestSharp;

namespace Apps.Wise.Utils;

public class QuoteApi : WiseInvocable
{
    public QuoteApi(InvocationContext invocationContext) : base(invocationContext)
    {
    }

    public Task<QuoteEntity> CreateQuote(
        [ActionParameter] ProfileRequest profile,
        [ActionParameter] CreateQuoteRequest input)
    {
        var endpoint = $"/v3/profiles/{profile.ProfileId}/quotes";
        var request = new WiseRestRequest(endpoint, Method.Post, Creds)
            .WithJsonBody(input, JsonConfig.CamelCaseSettings);

        return Client.ExecuteWithErrorHandling<QuoteEntity>(request);
    }
}