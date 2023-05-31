using System.ComponentModel;
using System.Net;
using System.Text;
using System.Text.Json;
using Checklist.Core;

namespace Checklist.Client;

public class HttpClientChecklistService : IChecklistService
{
    private readonly HttpClient _client;

    public HttpClientChecklistService(HttpClient client)
    {
        _client = client;
    }

    public async Task<Result> Create(CreateChecklistRequest request)
    {
        var response = await _client.PostAsync("/checklists", HttpContent(request));
        return await ResultFromHttpResponse(response);
    }

    public async Task<Result> ById(int id)
    {
        var response = await _client.GetAsync("/checklists");
        return await ResultFromHttpResponse(response);
    }

    private static async Task<Result> ResultFromHttpResponse(HttpResponseMessage response) =>
        response.StatusCode switch
        {
            HttpStatusCode.OK => new ValueResult<int>(await Deserialize(response)),
            _ => throw new InvalidEnumArgumentException(response.ToString())
        };

    private static HttpContent HttpContent(CreateChecklistRequest red)
    {
        var json = JsonSerializer.Serialize(red);
        HttpContent httpContent = new StringContent(json, Encoding.UTF8, "application/json");
        return httpContent;
    }

    private static async Task<int> Deserialize(HttpResponseMessage response) => 
        JsonSerializer.Deserialize<int>(await response.Content.ReadAsStringAsync());
}