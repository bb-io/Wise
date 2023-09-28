using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Apps.Wise.Constants;

public static class JsonConfig
{
    public static JsonSerializerSettings CamelCaseSettings => new()
    {
        ContractResolver = new DefaultContractResolver()
        {
            NamingStrategy = new CamelCaseNamingStrategy()
        }
    };
    
    public static JsonSerializerSettings SnakeCaseSettings => new()
    {
        ContractResolver = new DefaultContractResolver()
        {
            NamingStrategy = new SnakeCaseNamingStrategy()
        }
    };
}