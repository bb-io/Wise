using Apps.Wise.Constants;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Utils.Extensions.Sdk;
using Blackbird.Applications.Sdk.Utils.RestSharp;
using RestSharp;

namespace Apps.Wise.Api;

public class WiseRestRequest : BlackBirdRestRequest
{
    public WiseRestRequest(string resource, Method method, IEnumerable<AuthenticationCredentialsProvider> creds) : base(
        resource, method, creds)
    {
    }

    protected override void AddAuth(IEnumerable<AuthenticationCredentialsProvider> creds)
    {
        var token = creds.Get(CredsNames.ApiToken).Value;
        this.AddHeader("Authorization", $"Bearer {token}");
    }
}