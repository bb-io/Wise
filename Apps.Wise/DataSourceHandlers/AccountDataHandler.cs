using Apps.Wise.Api;
using Apps.Wise.Constants;
using Apps.Wise.Invocables;
using Apps.Wise.Models.Entities;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Blackbird.Applications.Sdk.Common.Invocation;
using RestSharp;

namespace Apps.Wise.DataSourceHandlers;

public class AccountDataHandler : WiseInvocable, IAsyncDataSourceHandler
{
    public AccountDataHandler(InvocationContext invocationContext) : base(invocationContext)
    {
    }

    public async Task<Dictionary<string, string>> GetDataAsync(DataSourceContext context,
        CancellationToken cancellationToken)
    {
        var request = new WiseRestRequest(ApiEndpoints.Accounts, Method.Get, Creds);
        var response = await Client.ExecuteWithErrorHandling<AccountEntity[]>(request);

        return response
            .Where(x => context.SearchString is null ||
                        x.AccountHolderName.Contains(context.SearchString, StringComparison.OrdinalIgnoreCase))
            .ToDictionary(x => x.Id, x => x.AccountHolderName);
    }
}