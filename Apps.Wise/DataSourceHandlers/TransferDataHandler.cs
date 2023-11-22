using Apps.Wise.Api;
using Apps.Wise.Constants;
using Apps.Wise.Invocables;
using Apps.Wise.Models.Entities;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Blackbird.Applications.Sdk.Common.Invocation;
using RestSharp;

namespace Apps.Wise.DataSourceHandlers;

public class TransferDataHandler : WiseInvocable, IAsyncDataSourceHandler
{
    public TransferDataHandler(InvocationContext invocationContext) : base(invocationContext)
    {
    }

    public async Task<Dictionary<string, string>> GetDataAsync(DataSourceContext context,
        CancellationToken cancellationToken)
    {
        var request = new WiseRestRequest(ApiEndpoints.Transfers, Method.Get, Creds);
        var response = await Client.PaginateViaOffset<TransferEntity>(request);

        return response
            .Where(x => context.SearchString is null ||
                        x.GetDynamicDisplay().Contains(context.SearchString, StringComparison.OrdinalIgnoreCase) is true)
            .ToDictionary(x => x.Id, x => x.GetDynamicDisplay());
    }
}