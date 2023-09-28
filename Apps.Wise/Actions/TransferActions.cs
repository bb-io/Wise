using System.Net.Mime;
using Apps.Wise.Api;
using Apps.Wise.Constants;
using Apps.Wise.Invocables;
using Apps.Wise.Models.Entities;
using Apps.Wise.Models.Request.Transfer;
using Apps.Wise.Models.Response;
using Apps.Wise.Models.Response.Transfer;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.Sdk.Utils.Extensions.Http;
using Blackbird.Applications.Sdk.Utils.Extensions.String;
using RestSharp;

namespace Apps.Wise.Actions;

[ActionList]
public class TransferActions : WiseInvocable
{
    public TransferActions(InvocationContext invocationContext) : base(invocationContext)
    {
    }

    [Action("List transfers", Description = "List all transfer info")]
    public async Task<ListTransfersResponse> ListTransfers([ActionParameter] ListTransfersRequest input)
    {
        var endpoint = ApiEndpoints.Transfers.WithQuery(input);
        var request = new WiseRestRequest(endpoint, Method.Get, Creds);

        var items = await Client.PaginateViaOffset<TransferEntity>(request);
        return new(items);
    }

    [Action("Create transfer", Description = "Create a new transfer")]
    public Task<TransferEntity> CreateTransfer([ActionParameter] CreateTransferInput input)
    {
        var payload = new CreateTransferRequest(input);
        var request = new WiseRestRequest(ApiEndpoints.Transfers, Method.Post, Creds)
            .WithJsonBody(payload, JsonConfig.CamelCaseSettings);

        return Client.ExecuteWithErrorHandling<TransferEntity>(request);
    }

    [Action("Get transfer", Description = "Get details of a specific transfer")]
    public Task<TransferEntity> GetTransfer([ActionParameter] TransferRequest transfer)
    {
        var endpoint = $"{ApiEndpoints.Transfers}/{transfer.TransferId}";
        var request = new WiseRestRequest(endpoint, Method.Get, Creds);

        return Client.ExecuteWithErrorHandling<TransferEntity>(request);
    }

    [Action("Cancel transfer", Description = "Cancel specific transfer")]
    public Task<TransferEntity> CancelTransfer([ActionParameter] TransferRequest transfer)
    {
        var endpoint = $"{ApiEndpoints.Transfers}/{transfer.TransferId}/cancel";
        var request = new WiseRestRequest(endpoint, Method.Put, Creds);

        return Client.ExecuteWithErrorHandling<TransferEntity>(request);
    }

    [Action("Get transfer receipt as PDF", Description = "Get receipt of a specific transfer as PDF")]
    public async Task<FileResponse> GetTransferReceipt([ActionParameter] TransferRequest transfer)
    {
        var endpoint = $"{ApiEndpoints.Transfers}/{transfer.TransferId}/receipt.pdf";
        var request = new WiseRestRequest(endpoint, Method.Get, Creds);

        var response = await Client.ExecuteWithErrorHandling(request);
        return new(new(response.RawBytes)
        {
            Name = $"{transfer.TransferId}.pdf",
            ContentType = MediaTypeNames.Application.Pdf
        });
    }
}