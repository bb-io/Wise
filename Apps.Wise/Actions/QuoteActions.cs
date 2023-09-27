using Apps.Wise.Api;
using Apps.Wise.Constants;
using Apps.Wise.Invocables;
using Apps.Wise.Models.Entities;
using Apps.Wise.Models.Request.Profile;
using Apps.Wise.Models.Request.Quote;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.Sdk.Utils.Extensions.Http;
using RestSharp;

namespace Apps.Wise.Actions;

[ActionList]
public class QuoteActions : WiseInvocable
{
    public QuoteActions(InvocationContext invocationContext) : base(invocationContext)
    {
    }
    
    [Action("Create quote", Description = "List all user profiles")]
    public Task<QuoteEntity> CreateQuote(
        [ActionParameter] ProfileRequest profile,
        [ActionParameter] CreateQuoteRequest input)
    {
        var endpoint = $"/v3/profiles/{profile.ProfileId}/quotes";
        var request = new WiseRestRequest(endpoint, Method.Post, Creds)
            .WithJsonBody(input, JsonConfig.Settings);
        
        return Client.ExecuteWithErrorHandling<QuoteEntity>(request);
    }    
    
    [Action("Get quote", Description = "Get details of a specific quote")]
    public Task<QuoteEntity> GetQuote([ActionParameter] QuoteRequest quote)
    {
        var endpoint = $"/v3/profiles/{quote.ProfileId}/quotes/{quote.QuoteId}";
        var request = new WiseRestRequest(endpoint, Method.Get, Creds);
        
        return Client.ExecuteWithErrorHandling<QuoteEntity>(request);
    }
}