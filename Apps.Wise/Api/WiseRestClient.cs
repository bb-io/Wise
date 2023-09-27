using Apps.Wise.Constants;
using Apps.Wise.Models.Response.Base;
using Apps.Wise.Models.Response.Error;
using Blackbird.Applications.Sdk.Utils.Extensions.String;
using Blackbird.Applications.Sdk.Utils.RestSharp;
using Newtonsoft.Json;
using RestSharp;

namespace Apps.Wise.Api;

public class WiseRestClient : BlackBirdRestClient
{
    public WiseRestClient() : base(new()
    {
        BaseUrl = Urls.Api.ToUri()
    })
    {
    }

    public async Task<TV[]> PaginateViaPageNumber<T, TV>(RestRequest request) where T : PaginationResponse<TV>
    {
        var pageSize = 50;
        var page = 1;

        var baseUrl = request.Resource.SetQueryParameter("pageSize", pageSize.ToString());

        var result = new List<TV>();
        T response;
        do
        {
            request.Resource = baseUrl.SetQueryParameter("pageNumber", (page++).ToString());
            response = await ExecuteWithErrorHandling<T>(request);

            result.AddRange(response.Items);
        } while (result.Count < response.TotalCount);

        return result.ToArray();
    }    
    
    public async Task<T[]> PaginateViaOffset<T>(RestRequest request)
    {
        var limit = 50;
        var offset = 0;

        var baseUrl = request.Resource.SetQueryParameter("limit", limit.ToString());

        var result = new List<T>();
        T[] response;
        do
        {
            request.Resource = baseUrl.SetQueryParameter("offset", offset.ToString());
            response = await ExecuteWithErrorHandling<T[]>(request);

            result.AddRange(response);
            offset += limit;
        } while (response.Any());

        return result.ToArray();
    }
    
    protected override Exception ConfigureErrorException(RestResponse response)
    {
        var json = response.Content!;
        
        var error = JsonConvert.DeserializeObject<ErrorResponse>(json);
        if(error?.Error is not null)
            return new(error.ToString());

        var errors = JsonConvert.DeserializeObject<MultipleErrorsResponse>(json);
        if(errors?.Errors is not null) 
            return new(string.Join("; ", errors.Errors.Select(x => x.ToString())));

        var codeError = JsonConvert.DeserializeObject<CodeError>(json)!;
        return new(codeError.ToString());
    }
}