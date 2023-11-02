using Apps.Wise.Api;
using Apps.Wise.Constants;
using Apps.Wise.Invocables;
using Apps.Wise.Models.Entities;
using Apps.Wise.Models.Request.BatchGroup;
using Apps.Wise.Models.Request.Profile;
using Apps.Wise.Models.Request.Quote;
using Apps.Wise.Models.Request.Transfer;
using Apps.Wise.Models.Response.Card;
using Apps.Wise.Utils;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.Sdk.Utils.Extensions.Http;
using RestSharp;

namespace Apps.Wise.Actions;

[ActionList]
public class BatchGroupActions : WiseInvocable
{
    public BatchGroupActions(InvocationContext invocationContext) : base(invocationContext)
    {
    }

    [Action("Create batch group", Description = "Create a new batch group")]
    public Task<BatchGroupEntity> CreateBatchGroup(
        [ActionParameter] ProfileRequest profile,
        [ActionParameter] CreateBatchGroupRequest input)
    {
        var endpoint = $"/v3/profiles/{profile.ProfileId}/batch-groups";
        var request = new WiseRestRequest(endpoint, Method.Post, Creds)
            .WithJsonBody(input, JsonConfig.CamelCaseSettings);

        return Client.ExecuteWithErrorHandling<BatchGroupEntity>(request);
    }

    [Action("Create batch group transfer", Description = "Create a new transfer for the batch group")]
    public async Task<TransferEntity> CreateBatchGroupTransfer(
        [ActionParameter] ProfileRequest profile,
        [ActionParameter] BatchGroupRequest batchGroup,
        [ActionParameter] CreateBatchGroupTransferInput transferInput,
        [ActionParameter] CreateQuoteInput quoteInput)
    {
        var quote = await new QuoteApi(InvocationContext).CreateQuote(profile,
            new(quoteInput, transferInput.TargetAccount));

        var payload = new CreateBatchGroupTransferRequest(transferInput, quote.Id);
        var endpoint = $"/v3/profiles/{profile.ProfileId}/batch-groups/{batchGroup.BatchGroupId}/transfers";

        var request = new WiseRestRequest(endpoint, Method.Post, Creds)
            .WithJsonBody(payload, JsonConfig.CamelCaseSettings);

        return await Client.ExecuteWithErrorHandling<TransferEntity>(request);
    }
}