using Apps.Wise.Api;
using Apps.Wise.Constants;
using Apps.Wise.Invocables;
using Apps.Wise.Models.Entities;
using Apps.Wise.Models.Request.Balance;
using Apps.Wise.Models.Request.Profile;
using Apps.Wise.Models.Response.Balance;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.Sdk.Utils.Extensions.Http;
using RestSharp;

namespace Apps.Wise.Actions;

[ActionList]
public class BalanceActions : WiseInvocable
{
    public BalanceActions(InvocationContext invocationContext) : base(invocationContext)
    {
    }
    
    [Action("List balances", Description = "List all balances for a profile")]
    public async Task<ListBalancesResponse> ListBalances([ActionParameter] ProfileRequest profile)
    {
        var endpoint = $"/v4/profiles/{profile.ProfileId}/balances?types=STANDARD";
        var request = new WiseRestRequest(endpoint, Method.Get, Creds);
       
        var response = await Client.ExecuteWithErrorHandling<BalanceEntity[]>(request);
        return new(response);
    }    
    
    [Action("Get balance", Description = "Get details of a specific balance")]
    public Task<BalanceEntity> GetBalnce([ActionParameter] BalanceRequest balance)
    {
        var endpoint = $"/v4/profiles/{balance.ProfileId}/balances/{balance.BalanceId}";
        var request = new WiseRestRequest(endpoint, Method.Get, Creds);
       
        return Client.ExecuteWithErrorHandling<BalanceEntity>(request);
    }    
    
    [Action("Create balance", Description = "Create a new balance")]
    public Task<BalanceEntity> CreateBalance([ActionParameter] ProfileRequest profile,
        [ActionParameter] CreateBalanceRequest input)
    {
        var endpoint = $"/v4/profiles/{profile.ProfileId}/balances";
        var request = new WiseRestRequest(endpoint, Method.Post, Creds)
            .AddHeader("X-idempotence-uuid", Guid.NewGuid().ToString())
            .WithJsonBody(input, JsonConfig.Settings);

        return Client.ExecuteWithErrorHandling<BalanceEntity>(request);
    }
    
    [Action("Delete balance", Description = "Delete specific balance")]
    public Task DeleteBalance([ActionParameter] BalanceRequest balance)
    {
        var endpoint = $"/v4/profiles/{balance.ProfileId}/balances/{balance.BalanceId}";
        var request = new WiseRestRequest(endpoint, Method.Delete, Creds);

        return Client.ExecuteWithErrorHandling(request);
    }
}