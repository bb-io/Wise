using Apps.Wise.Api;
using Apps.Wise.Invocables;
using Apps.Wise.Models.Entities;
using Apps.Wise.Models.Request.Card;
using Apps.Wise.Models.Request.Transaction;
using Apps.Wise.Models.Response.Transaction;
using Apps.Wise.Utils;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Invocation;
using RestSharp;

namespace Apps.Wise.Actions;

[ActionList]
public class TransactionActions : WiseInvocable
{
    public TransactionActions(InvocationContext invocationContext) : base(invocationContext)
    {
    }

    [Action("List transactions", Description = "List all card transactions")]
    public async Task<ListTransactionsResponse> ListTransactions([ActionParameter] CardRequest card)
    {
        var endpoint = $"/v3/spend/profiles/{card.ProfileId}/cards/{card.CardToken}/transactions";
        var request = new WiseRestRequest(endpoint, Method.Get, Creds);

        var items = await SensitiveHandler
            .HandleSensisitiveRequest(() =>
                Client.PaginateViaPageNumber<TransactionsPaginationResponse, TransactionEntity>(request));

        return new(items);
    }

    [Action("Get transaction", Description = "Get details of a specific transaction")]
    public Task<TransactionEntity> GetTransaction([ActionParameter] TransactionRequest transac)
    {
        var endpoint = $"/v3/spend/profiles/{transac.ProfileId}/cards/transactions/{transac.TransactionId}";
        var request = new WiseRestRequest(endpoint, Method.Get, Creds);

        return SensitiveHandler
            .HandleSensisitiveRequest(() => Client.ExecuteWithErrorHandling<TransactionEntity>(request));
    }
}