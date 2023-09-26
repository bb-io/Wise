using Apps.Wise.Constants;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Common.Connections;

namespace Apps.Wise.Connection;

public class ConnectionDefinition : IConnectionDefinition
{
    public IEnumerable<ConnectionPropertyGroup> ConnectionPropertyGroups => new List<ConnectionPropertyGroup>()
    {
        new()
        {
            Name = "API Token",
            AuthenticationType = ConnectionAuthenticationType.Undefined,
            ConnectionUsage = ConnectionUsage.Webhooks,
            ConnectionProperties = new List<ConnectionProperty>()
            {
                new(CredsNames.ApiToken) { DisplayName = "API token", Sensitive = true },
            }
        }
    };

    public IEnumerable<AuthenticationCredentialsProvider> CreateAuthorizationCredentialsProviders(
        Dictionary<string, string> values)
    {
        yield return new(
            AuthenticationCredentialsRequestLocation.None,
            CredsNames.ApiToken, values[CredsNames.ApiToken]
        );
    }
}