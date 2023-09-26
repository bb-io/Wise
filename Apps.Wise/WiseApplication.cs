using Blackbird.Applications.Sdk.Common;

namespace Apps.Wise;

public class WiseApplication : IApplication
{
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