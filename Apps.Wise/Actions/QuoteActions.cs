using Apps.Wise.Invocables;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Invocation;

namespace Apps.Wise.Actions;

[ActionList]
public class QuoteActions : WiseInvocable
{
    public QuoteActions(InvocationContext invocationContext) : base(invocationContext)
    {
    }
}