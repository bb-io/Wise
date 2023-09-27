using Apps.Wise.Api;
using Apps.Wise.Constants;
using Apps.Wise.Invocables;
using Apps.Wise.Models.Entities;
using Apps.Wise.Models.Response.Profile;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Invocation;
using RestSharp;

namespace Apps.Wise.Actions;

[ActionList]
public class ProfileActions : WiseInvocable
{
    public ProfileActions(InvocationContext invocationContext) : base(invocationContext)
    {
    }

    [Action("List profiles", Description = "List all user profiles")]
    public async Task<ListProfilesResponse> ListProfiles()
    {
        var request = new WiseRestRequest(ApiEndpoints.Profiles, Method.Get, Creds);
        var response = await Client.ExecuteWithErrorHandling<ProfileEntity[]>(request);

        return new(response);
    }
}