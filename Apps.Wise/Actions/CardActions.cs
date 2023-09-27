using Apps.Wise.Api;
using Apps.Wise.Invocables;
using Apps.Wise.Models.Entities;
using Apps.Wise.Models.Request.Profile;
using Apps.Wise.Models.Response.Card;
using Apps.Wise.Utils;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Invocation;
using RestSharp;

namespace Apps.Wise.Actions;

[ActionList]
public class CardActions : WiseInvocable
{
    public CardActions(InvocationContext invocationContext) : base(invocationContext)
    {
    }

    [Action("List cards", Description = "List all profile cards")]
    public async Task<ListCardsResponse> ListCards([ActionParameter] ProfileRequest profile)
    {
        var endpoint = $"/v3/spend/profiles/{profile.ProfileId}/cards";
        var request = new WiseRestRequest(endpoint, Method.Get, Creds);

        var items = await SensitiveHandler
            .HandleSensisitiveRequest(() => Client.PaginateViaPageNumber<CardsPaginationResponse, CardEntity>(request));

        return new(items);
    }
}