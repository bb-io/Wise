using Apps.Wise.Api;
using Apps.Wise.Constants;
using Apps.Wise.Invocables;
using Apps.Wise.Models.Entities;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Blackbird.Applications.Sdk.Common.Invocation;
using RestSharp;

namespace Apps.Wise.DataSourceHandlers;

public class ProfileDataHandler : WiseInvocable, IAsyncDataSourceHandler
{
    public ProfileDataHandler(InvocationContext invocationContext) : base(invocationContext)
    {
    }

    public async Task<Dictionary<string, string>> GetDataAsync(DataSourceContext context,
        CancellationToken cancellationToken)
    {
        var request = new WiseRestRequest(ApiEndpoints.Profiles, Method.Get, Creds);
        var response = await Client.ExecuteWithErrorHandling<ProfileEntity[]>(request);

        return response
            .Where(x => context.SearchString is null ||
                        x.FullName.Contains(context.SearchString, StringComparison.OrdinalIgnoreCase))
            .ToDictionary(x => x.Id, x => x.FullName);
    }
}