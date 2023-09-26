using Apps.Wise.Invocables;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Invocation;

namespace Apps.Wise.Actions;

[ActionList]
public class BalanceActions : WiseInvocable
{
    public BalanceActions(InvocationContext invocationContext) : base(invocationContext)
    {
    }
}