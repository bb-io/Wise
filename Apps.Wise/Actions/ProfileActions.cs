using Apps.Wise.Invocables;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Invocation;

namespace Apps.Wise.Actions;

[ActionList]
public class ProfileActions : WiseInvocable
{
    public ProfileActions(InvocationContext invocationContext) : base(invocationContext)
    {
    }
}