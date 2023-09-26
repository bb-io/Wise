using Apps.Wise.Api;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Common.Invocation;

namespace Apps.Wise.Invocables;

public class WiseInvocable : BaseInvocable
{
    protected AuthenticationCredentialsProvider[] Creds
        => InvocationContext.AuthenticationCredentialsProviders.ToArray();

    protected WiseRestClient Client { get; }

    public WiseInvocable(InvocationContext invocationContext) : base(invocationContext)
    {
        Client = new();
    }
}