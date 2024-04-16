using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Metadata;

namespace Apps.Wise;

public class WiseApplication : IApplication, ICategoryProvider
{
    public IEnumerable<ApplicationCategory> Categories
    {
        get => [ApplicationCategory.Fintech];
        set { }
    }
    
    public string Name
    {
        get => "Wise";
        set { }
    }

    public T GetInstance<T>()
    {
        throw new NotImplementedException();
    }
}